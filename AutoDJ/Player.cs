using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AutoDJ
{
    class Player
    {
        public Task<bool> PlaySongAsync(string url) { return Task.Factory.StartNew(() => PlaySong(url)); }
        private bool PlaySong(string url)
        {
            System.Diagnostics.Process.Start(url);
            Thread.Sleep(3000);
            return true;
        }
    }
}
