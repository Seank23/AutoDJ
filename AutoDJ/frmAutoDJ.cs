using System;
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
        RequestProcessor processor;
        QueueManager queue;

        private int songMinutes = 0;

        public frmAutoDJ()
        {
            InitializeComponent();
            queue = new QueueManager(this);
            processor = new RequestProcessor(this, queue);
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            processor.RequestSong();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
             ResetRequest();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            queue.PlayQueue();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (Player.songStarted)
            {
                Player.songPaused = !Player.songPaused;

                if (Player.songPaused)
                    btnPause.Text = "Resume";
                else
                    btnPause.Text = "Pause";
            }
        }

        private void btnClearPlaylist_Click(object sender, EventArgs e)
        {
            queue.ClearQueue();
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            if (Player.songStarted)
                queue.NextSong();
        }

        public string GetSearchInput() { return txtCriteria.Text; }

        public void SetSongName(string name) { txtName.Text = name; }

        public void SetSongDuration(string time) { txtDuration.Text = time; }

        public void SetSongTimer(int seconds)
        {
            if(seconds < 60) { songMinutes = 0; }

            if (seconds % 60 == 0 && seconds != 0) { songMinutes++; }

            if(songMinutes > 0) { seconds -= 60 * songMinutes; }

            if (seconds < 10)
            {
                txtTimer.Text = songMinutes + ":0" + seconds;
            }
            else
            {
                txtTimer.Text = songMinutes + ":" + seconds;
            }
        }

        public void SetRequestStatus(string status)
        {
            lblRequestStatus.Text = status;
        }

        public void StartProgressBar()
        {
            pgbStatusBar.Style = ProgressBarStyle.Marquee;
        }

        public void EndProgressBar()
        {
            pgbStatusBar.Style = ProgressBarStyle.Blocks;
        }

        public void CreateQueueUI(Song song)
        {
            QueueItem songEntry = new QueueItem();
            songEntry.Parent = pnlQueueContainer;
            songEntry.Name = "qitSong" + (song.queuePosition + 1);
            songEntry.lblPosition.Text = (song.queuePosition + 1).ToString() + ".";
            songEntry.lblName.Text = song.name;
            songEntry.lblDuration.Text = "Duration: " + song.durationMinutes;
        }

        public void ClearQueueUI()
        {
            pnlQueueContainer.SuspendLayout();

            if (pnlQueueContainer.Controls.Count > 0)
            {
                for (int i = (pnlQueueContainer.Controls.Count - 1); i >= 0; i--)
                {
                    Control c = pnlQueueContainer.Controls[i];
                    c.Dispose();
                }
                GC.Collect();
            }

            pnlQueueContainer.ResumeLayout();
        }

        public void ResetRequest()
        {
            processor.ClearProcessData();

            txtCriteria.Clear();
            SetRequestStatus("Ready!");
            pgbStatusBar.Style = ProgressBarStyle.Blocks;
            GC.Collect();
        }

        public void ResetInfo()
        {
            txtName.Clear();
            txtDuration.Clear();
            txtTimer.Clear();
            lblRequestStatus.Text = "Ready!";
        }
    }
}
