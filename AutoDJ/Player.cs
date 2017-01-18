using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace AutoDJ
{
    class Player
    {
        frmAutoDJ ui;

        Stopwatch songTimer;
        int songDuration = 0;

        public Player(frmAutoDJ ui)
        {
            this.ui = ui;
        }

        private void InvokeUI(Action a)
        {
            IAsyncResult uiCall = ui.BeginInvoke(new MethodInvoker(a));
            ui.EndInvoke(uiCall);
        }

        public Task<bool> PlaySongAsync(string url) { return Task.Factory.StartNew(() => PlaySong(url)); }
        private bool PlaySong(string url)
        {
            Process.Start(url);
            Thread.Sleep(3000);
            return true;
        }

        public Task<bool> StartTimerAsync(int duration) { return Task.Factory.StartNew(() => StartTimer(duration)); }
        private bool StartTimer(int duration)
        {
            songDuration = duration;
            songTimer = new Stopwatch();
            songTimer.Start();

            UpdateTimer(songTimer);

            return true;
        }

        private void UpdateTimer(Stopwatch songTimer)
        {
            while (songTimer.ElapsedMilliseconds <= songDuration * 1000)
            {
                InvokeUI(() => ui.SetSongTimer((int)songTimer.ElapsedMilliseconds / 1000));
                Thread.Sleep(1000);
            }

            InvokeUI(() => ui.SetSongTimer(0));
            songTimer.Reset();
        }

        public void ClearPlayerData()
        {
            songDuration = 0;
        }
    }
}
