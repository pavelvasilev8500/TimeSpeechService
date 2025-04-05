using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TimeSpeechService
{
    internal static class SoundCheck
    {
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int waveOutGetNumDevs();

        public static bool IsAvalableSoundCard()
        {
            if (waveOutGetNumDevs() == 0)
                return false;
            else
                return true;
        }
    }
}
