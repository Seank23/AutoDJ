using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDJ
{
    public partial class frmAutoDJ : Form
    {
        string html;
        string videoHTML;

        public frmAutoDJ()
        {
            InitializeComponent();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            RequestSong();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCriteria.Clear();
            txtName.Clear();
            txtDuration.Clear();

            html = "";
            videoHTML = "";
        }



        private void RequestSong()
        {
            string searchURL = GetSearchQuery();

            html = GetHTML(searchURL);
            videoHTML = FindFromSource(html, "watch?", "div class", 2);

            string videoURL = GetVideoURL();

            DisplayInfo();
            
            System.Diagnostics.Process.Start(videoURL);
        }

        private string GetSearchQuery()
        {
            string criteria = txtCriteria.Text;
            criteria.Replace(' ', '+');
            return "http://www.youtube.com/results?search_query=" + criteria;
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

        private string GetVideoURL()
        {
            return "http://www.youtube.com/" + FindFromSource(videoHTML, "watch?", '"'.ToString(), 1);
        }

        private string FindFromSource(string source, string startTerm, string endTerm, int occurence)
        {
            int start, end;
            string text = "";

            if(source.Contains(startTerm))
            {
                start = source.IndexOf(startTerm, 0);

                while(occurence > 1)
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
            txtName.Text = GetSongName();
            txtDuration.Text = (string)GetSongDuration(true);
        }
    }
}
