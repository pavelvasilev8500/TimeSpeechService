﻿using System;
using System.Globalization;
using System.Speech.Synthesis;

namespace TimeSpeechService
{
    public static class SpeechManager
    {
        private static DateTime _time = DateTime.Now;

        public static void SayHour(object state)
        {
            DateTime time = DateTime.Now;
            var synthesizer = new SpeechSynthesizer();
            var builder = new PromptBuilder();
            builder.StartVoice(new CultureInfo("ru-RU"));
            if (time.Hour == 1 || time.Hour == 21)
                builder.AppendText($"{time.Hour} час");
            else if (time.Hour >= 2 && time.Hour <= 4 || time.Hour >= 22 && time.Hour <= 23)
                builder.AppendText($"{time.Hour} часа");
            else if (time.Hour >= 5 && time.Hour <= 20 || time.Hour == 0)
                builder.AppendText($"{time.Hour} часов");
            builder.EndVoice();
            synthesizer.Volume = 100;
            synthesizer.Speak(builder);
        }

        public static int GetNextHour()
        {
            int currentTime = _time.Hour * 3600000 + _time.Minute * 60000 + _time.Second * 1000;
            int nextTime = _time.AddHours(1).Hour * 3600000;
            return nextTime - currentTime;
        }
    }
}
