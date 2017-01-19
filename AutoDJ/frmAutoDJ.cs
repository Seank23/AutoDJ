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

        private int songMinutes = 0;

        public frmAutoDJ()
        {
            InitializeComponent();
            processor = new RequestProcessor(this);
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            processor.RequestSong();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Player.songPlaying)
                Reset();
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

        public void Reset()
        {
            processor.ClearProcessData();

            txtCriteria.Clear();
            txtName.Clear();
            txtDuration.Clear();
            txtTimer.Clear();
            SetRequestStatus("Ready!");
            pgbStatusBar.Style = ProgressBarStyle.Blocks;
        }
    }
}
