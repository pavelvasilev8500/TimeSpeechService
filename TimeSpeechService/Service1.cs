using System;
using System.ServiceProcess;
using System.Timers;

namespace TimeSpeechService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            CanStop = true;
            CanPauseAndContinue = true;
            if(SoundCheck.IsAvalableSoundCard())
            {
                var timer = new Timer(1000);
                timer.Elapsed += Timer_Elapsed;
                timer.AutoReset = true;
                timer.Start();
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var dt = DateTime.Now;
            SpeechManager.SayHour(dt);
        }
    }
}
