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
        public frmAutoDJ()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string criteria = txtCriteria.Text;
            criteria.Replace(' ', '+');
            string searchURL = "http://www.youtube.com/results?search_query=" + criteria;
            string html = GetHTML(searchURL);
            string videoHTML = FindFromSource(html, "watch?", "div class", 2);
            string videoURL = "http://www.youtube.com/" + FindFromSource(videoHTML, "watch?", '"'.ToString(), 1);
            string songName = FindFromSource(videoHTML, "dir", '<'.ToString(), 1);
            songName = songName.Substring(10, songName.Length - 10);
            string songDuration = FindFromSource(videoHTML, "Duration: ", '.'.ToString(), 1);
            songDuration = songDuration.Substring(10, songDuration.Length - 10);

            txtName.Text = songName;
            txtDuration.Text = songDuration;
            System.Diagnostics.Process.Start(videoURL);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCriteria.Clear();
            txtName.Clear();
            txtDuration.Clear();
        }
    }
}
