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
        frmAutoDJ ui;
        Player player;
        public List<Song> songsInQueue = new List<Song>();

        public QueueManager(frmAutoDJ ui)
        {
            this.ui = ui;
            player = new Player(ui);
        }

        public void AddToQueue(Song songToAdd)
        {
            songToAdd.queuePosition = songsInQueue.Count;
            songsInQueue.Add(songToAdd);
            UpdateQueueUI();
        }

        private void UpdateQueueUI()
        {
            ui.ClearQueueUI();

            foreach(Song song in songsInQueue)
            {
                ui.CreateQueueUI(song);
            }
        }

        public async void PlayQueue()
        {
            if(songsInQueue.Count != 0)
            {
                bool songStarted, songFinished = false;

                DisplayInfo(songsInQueue[0]);
                songStarted = await player.PlaySongAsync(songsInQueue[0].url);

                if (songStarted)
                    songFinished = await player.StartTimerAsync(songsInQueue[0].durationSeconds);

                if (songFinished)
                {
                    if (songsInQueue.Count == 1)
                    {
                        QueueFinished();
                    }
                    else
                    {
                        Console.WriteLine("Song Finished");
                        NextSong();
                    }
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
            ChangeQueuePosition();
            songsInQueue.RemoveAt(0);
            UpdateQueueUI();
            PlayQueue();
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
            songsInQueue.RemoveAt(0);
            UpdateQueueUI();
            ui.ResetInfo();
            MessageBox.Show("Playlist finished");
        }
    }
}
