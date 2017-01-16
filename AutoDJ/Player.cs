using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDJ
{
    class Player
    {
        public void PlaySong(string url)
        {
            System.Diagnostics.Process.Start(url);
        }
    }
}
