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

        public frmAutoDJ()
        {
            InitializeComponent();
            processor = new RequestProcessor(this);
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            processor.RequestSong();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCriteria.Clear();
            txtName.Clear();
            txtDuration.Clear();
        }

        public string GetSearchInput() { return txtCriteria.Text; }

        public void SetSongName(string name) { txtName.Text = name; }

        public void SetSongDuration(string time) { txtDuration.Text = time; }

        public void SetSongTimer(int seconds)
        {
            int minutes = 0;

            if (seconds % 60 == 0 && seconds != 0) { minutes++; }

            if (seconds < 10)
            {
                txtTimer.Text = "0" + minutes + ":0" + seconds;
            }
            else
            {
                txtTimer.Text = "0" + minutes + ":" + seconds;
            }
        }
    }
}
