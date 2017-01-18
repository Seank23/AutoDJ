using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace AutoDJ
{
    class RequestProcessor
    {
        Player player = new Player();
        frmAutoDJ ui;

        string html;
        string videoHTML;

        public RequestProcessor(frmAutoDJ form)
        {
            this.ui = form;
        }

        public async void RequestSong()
        {
            string searchURL = GetSearchQuery();

            html =  await GetHTMLAsync(searchURL);
            videoHTML = FindFromSource(html, "watch?", "div class", 2);

            string videoURL = GetVideoURL();

            DisplayInfo();

            bool songStarted = await player.PlaySongAsync(videoURL);

            if (songStarted)
            {
                bool songFinished = await StartTimerAsync((int)GetSongDuration(false));
            }
        }

        private string GetSearchQuery()
        {
            string search = ui.GetSearchInput();
            search.Replace(' ', '+');
            return "http://www.youtube.com/results?search_query=" + search;
        }

        private Task<string> GetHTMLAsync(string url) { return Task.Factory.StartNew(() => GetHTML(url)); }
        private string GetHTML(string url)
        {
            string html = "";

            using (WebClient client = new WebClient())
            {
                html = client.DownloadString(url);
            }

            return html;
        }

        private string GetVideoURL()
        {
            return "http://www.youtube.com/" + FindFromSource(videoHTML, "watch?", '"'.ToString(), 1);
        }

        private string FindFromSource(string source, string startTerm, string endTerm, int occurence)
        {
            int start, end;
            string text = "";

            if (source.Contains(startTerm))
            {
                start = source.IndexOf(startTerm, 0);

                while (occurence > 1)
                {
                    start = source.IndexOf(startTerm, start + 1);
                    occurence--;
                }

                end = source.IndexOf(endTerm, start);
                text = source.Substring(start, end - start);
            }

            return text;
        }

        private string GetSongName()
        {
            string songName = FindFromSource(videoHTML, "dir", '<'.ToString(), 1);
            songName = songName.Substring(10, songName.Length - 10);
            return songName;
        }

        private Object GetSongDuration(bool inMinutes)
        {
            string songDuration = FindFromSource(videoHTML, "Duration: ", '.'.ToString(), 1);
            songDuration = songDuration.Substring(10, songDuration.Length - 10);
            string[] time = songDuration.Split(':');
            int seconds = Convert.ToInt32(time[0]) * 60 + Convert.ToInt32(time[1]);

            if (inMinutes)
                return songDuration;
            else
                return seconds;
        }

        private void DisplayInfo()
        {
            ui.SetSongName(GetSongName());
            ui.SetSongDuration((string)GetSongDuration(true));
        }

        private Task<bool> StartTimerAsync(int songDuration) { return Task.Factory.StartNew(() => StartTimer(songDuration)); }
        private bool StartTimer(int songDuration)
        {
            Stopwatch songTimer = new Stopwatch();
            songTimer.Start();

            while(songTimer.ElapsedMilliseconds < songDuration * 1000)
            {
                Console.WriteLine((int)songTimer.ElapsedMilliseconds / 1000);
                //UpdateTimer((int)songTimer.ElapsedMilliseconds / 1000);
                Thread.Sleep(1000);
            }

            return true;
        }

        private void UpdateTimer(int songDuration)
        {
            ui.SetSongTimer(songDuration);
        }
    }
}
