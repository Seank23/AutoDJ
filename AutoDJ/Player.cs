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
        public static bool songStarted = false;
        public static bool songPaused = false;

        CancellationTokenSource timerSource;

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
            songStarted = true;
            return true;
        }

        public Task<bool> StartTimerAsync(int duration)
        {
            timerSource = new CancellationTokenSource();
            return Task.Factory.StartNew(() => StartTimer(duration, timerSource.Token));
        }
        private bool StartTimer(int duration, CancellationToken ct)
        {
            songDuration = duration;
            songTimer = new Stopwatch();
            songTimer.Start();

            return UpdateTimer(ct);
        }

        private bool UpdateTimer(CancellationToken ct)
        {
            while (songTimer.ElapsedMilliseconds <= songDuration * 1000)
            {
                if (ct.IsCancellationRequested)
                {
                    Console.WriteLine("Cancelation Requested");
                    return false;
                }

                if (!songPaused)
                {
                    songTimer.Start();
                    InvokeUI(() => ui.SetSongTimer((int)songTimer.ElapsedMilliseconds / 1000));
                    Thread.Sleep(1000);
                }
                else
                {
                    songTimer.Stop();
                }
            }

            InvokeUI(() => ui.SetSongTimer(0));
            return true;
        }

        public void ResetTimer()
        {
            timerSource.Cancel(true);
            songTimer.Reset();
            timerSource.Dispose();
        }

        public void ClearPlayerData()
        {
            songDuration = 0;
        }
    }
}
