using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace AutoDJ
{
    class RequestProcessor
    {
        Player player;
        frmAutoDJ ui;

        string html;
        string videoHTML;

        public RequestProcessor(frmAutoDJ ui)
        {
            this.ui = ui;
            player = new Player(ui);
        }

        private void InvokeUI(Action a)
        {
            IAsyncResult uiCall = ui.BeginInvoke(new MethodInvoker(a));
            ui.EndInvoke(uiCall);
        }

        public async void RequestSong()
        {
            bool songStarted, songFinished = false;

            string searchURL = GetSearchQuery();

            html = await GetHTMLAsync(searchURL);

            videoHTML = FindFromSource(html, "watch?", "div class", 2);

            string videoURL = GetVideoURL();

            DisplayInfo();

            songStarted = await player.PlaySongAsync(videoURL);

            if (songStarted)
            {
                songFinished = await player.StartTimerAsync((int)GetSongDuration(false));
            }

            if(songFinished)
            {
                Console.WriteLine("Song Finished");
            }
        }

        private string GetSearchQuery()
        {
            string search = ui.GetSearchInput();
            search.Replace(' ', '+');
            return "http://www.youtube.com/results?search_query=" + search;
        }

        private Task<string> GetHTMLAsync(string url)
        {
            Task<string> html = Task.Factory.StartNew(() => GetHTML(url));
            Task.Factory.StartNew(() => WhileGetHTML(html));
            return html;
        }

        private string GetHTML(string url)
        {
            string html = "";

            using (WebClient client = new WebClient())
            {
                html = client.DownloadString(url);
            }

            return html;
        }

        private void WhileGetHTML(Task<string> html)
        {
            bool started = false;
            while (!html.IsCompleted)
            {
                if(!started)
                {
                    InvokeUI(() => ui.SetRequestStatus("Processing Request..."));
                    InvokeUI(() => ui.StartProgressBar());
                    started = true;
                }
            }
            InvokeUI(() => ui.SetRequestStatus("Request Successful!\nPlaying Song:"));
            InvokeUI(() => ui.EndProgressBar());
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

        public void ClearProcessData()
        {
            html = "";
            videoHTML = "";
            player.ClearPlayerData();
        }
    }
}
