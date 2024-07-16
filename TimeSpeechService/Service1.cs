using System.ServiceProcess;
using System.Threading;

namespace TimeSpeechService
{
    public partial class Service1 : ServiceBase
    {
        private static TimerCallback _timerCallback = new TimerCallback(SpeechManager.SayHour);
        private Timer _timer;
        public Service1()
        {
            InitializeComponent();
            CanStop = true;
            CanPauseAndContinue = true;
        }

        protected override void OnStart(string[] args)
        {
            _timer = new Timer(_timerCallback, null, SpeechManager.GetNextHour(), 3600000);
        }

        protected override void OnStop()
        {
            _timer.Dispose();
        }

        protected override void OnPause()
        {
            base.OnPause();
            _timer.Dispose();
        }

        protected override void OnContinue()
        {
            base.OnContinue();
            _timer = new Timer(_timerCallback, null, SpeechManager.GetNextHour(), 3600000);
        }
    }
}
