using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDJ
{
    class QueueManager
    {
        public static QueueManager queueManager; 

        frmAutoDJ ui;
        Player player;
        public List<Song> songsInQueue = new List<Song>();
        private Song currentSong;

        public QueueManager(frmAutoDJ ui)
        {
            this.ui = ui;
            player = new Player(ui);
        }

        public void AddToQueue(Song songToAdd)
        {
            songToAdd.queuePosition = songsInQueue.Count;
            songsInQueue.Add(songToAdd);
            UpdateQueue();
        }

        public void UpdateQueue()
        {
            ui.ClearQueueUI();

            songsInQueue.Sort((x, y) => y.votes.CompareTo(x.votes));
            ui.SetQueueTime(GetQueueTime(true).ToString());

            int i = 0;
            foreach(Song song in songsInQueue)
            {
                song.queuePosition = i;
                ui.CreateQueueUI(song);
                i++;
            }
        }

        public async void PlayQueue()
        {
            if(songsInQueue.Count != 0)
            {
                bool songStarted, songFinished = false;
                currentSong = songsInQueue[0];

                songsInQueue.RemoveAt(0);
                ChangeQueuePosition();
                UpdateQueue();
                DisplayInfo(currentSong);

                songStarted = await player.PlaySongAsync(currentSong.url);

                if (songStarted)
                    songFinished = await player.StartTimerAsync(currentSong.durationSeconds);

                if (songFinished)
                {
                    Console.WriteLine("Song Finished");
                    NextSong();
                }
            }
            else
            {
                MessageBox.Show("Please add songs to the queue");
                return;
            }
        }

        public void NextSong()
        {
            if (songsInQueue.Count < 1)
            {
                QueueFinished();
            }
            else
            {
                player.ResetTimer();
                PlayQueue();
            }
        }

        public void ClearQueue()
        {
            songsInQueue.Clear();
            UpdateQueue();
            ui.ResetInfo();

            if (Player.songStarted)
                player.ResetTimer();

            GC.Collect();
            MessageBox.Show("Playlist cleared");
        }

        private void ChangeQueuePosition()
        {
            foreach(Song song in songsInQueue)
            {
                song.queuePosition--;
            }
        }

        private void DisplayInfo(Song song)
        {
            ui.SetSongName(song.name);
            ui.SetSongDuration(song.durationMinutes);
        }

        private void QueueFinished()
        {
            ui.ResetInfo();
            player.ResetTimer();
            Player.songStarted = false;
            MessageBox.Show("Playlist finished");
        }

        private Object GetQueueTime(bool inMinutes)
        {
            int queueTime = 0;
            string queueTimeMinutes = "";

            foreach (Song song in songsInQueue)
            {
                queueTime += song.durationSeconds;
            }

            if(!inMinutes)
            {
                return queueTime;
            }
            else
            {
                if(queueTime % 60 < 10)
                    queueTimeMinutes = Math.Floor((double)(queueTime / 60)).ToString() + ":0" + queueTime % 60;
                else
                    queueTimeMinutes = Math.Floor((double)(queueTime / 60)).ToString() + ":" + queueTime % 60;

                return queueTimeMinutes;
            }
        }
    }
}
