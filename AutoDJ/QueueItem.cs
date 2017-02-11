using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDJ
{
    public partial class QueueItem : UserControl
    {
        public Song allocatedSong;

        public QueueItem()
        {
            InitializeComponent();
        }

        private void btnVote_Click(object sender, EventArgs e)
        {
            QueueManager.queueManager.songsInQueue[allocatedSong.queuePosition].votes++;
            btnVote.Text = "Votes (" + QueueManager.queueManager.songsInQueue[allocatedSong.queuePosition].votes + ")";
            QueueManager.queueManager.UpdateQueue();
        }
    }
}
