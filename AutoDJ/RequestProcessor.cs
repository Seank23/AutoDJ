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
        string searchHTML;
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
            if(html != null)
            {
                MessageBox.Show("Please reset before requesting a new song");
                return;
            }

            string searchURL = GetSearchQuery();
            if (searchURL == "") { ui.Reset(); return; }

            html = await GetHTMLAsync(searchURL);
            if (html == "") { ui.Reset(); return; }

            searchHTML = FindFromSource(html, "watch?", "div class", 2);
            string videoURL = GetVideoURL();

            videoHTML = await GetHTMLAsync(videoURL);
            if (videoHTML == "") { ui.Reset(); return; }

            if (IsMusic())
            {
                RequestSuccessful(videoURL);
            }
            else
            {
                MessageBox.Show("Request is not a song. Please enter the name of a song");
                ui.Reset();
                return;
            } 
        }

        private async void RequestSuccessful(string videoURL)
        {
            bool songStarted, songFinished = false;

            DisplayInfo();

            songStarted = await player.PlaySongAsync(videoURL);

            if (songStarted)
            {
                songFinished = await player.StartTimerAsync((int)GetSongDuration(false));
            }

            if (songFinished)
            {
                Console.WriteLine("Song Finished");
            }
        }

        private string GetSearchQuery()
        {
            string search = ui.GetSearchInput();
            if(search == "")
            {
                MessageBox.Show("Search criteria must be entered before requesting a song.");
                return "";
            }
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
                try
                {
                    html = client.DownloadString(url);
                }
                catch(Exception e)
                {
                    MessageBox.Show("Could not request song. Please try again later.\n" + e.ToString());
                    return "";
                }
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
            if(html.Result == "") { return; }
            InvokeUI(() => ui.SetRequestStatus("Request Successful!\nPlaying Song:"));
            InvokeUI(() => ui.EndProgressBar());
        }

        private string GetVideoURL()
        {
            return "http://www.youtube.com/" + FindFromSource(searchHTML, "watch?", '"'.ToString(), 1);
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

        private bool IsMusic()
        {
            string category = FindFromSource(videoHTML, "Category", "</a>", 1);
            if (category.Contains("Music"))
                return true;
            else
                return false;
        }

        private string GetSongName()
        {
            string songName = FindFromSource(searchHTML, "dir", '<'.ToString(), 1);
            songName = songName.Substring(10, songName.Length - 10);
            return songName;
        }

        private Object GetSongDuration(bool inMinutes)
        {
            string songDuration = FindFromSource(searchHTML, "Duration: ", '.'.ToString(), 1);
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
            html = null;
            searchHTML = null;
            videoHTML = null;
            player.ClearPlayerData();
        }
    }
}
