using System;
using System.Globalization;
using System.Speech.Synthesis;

namespace TimeSpeechService
{
    public static class SpeechManager
    {
        public static void SayHour(DateTime dt)
        {
            if (dt.Minute == 0 && dt.Second == 0)
            {
                var synthesizer = new SpeechSynthesizer();
                var builder = new PromptBuilder();
                switch(CultureInfo.CurrentCulture.Name)
                {
                    case "en-US":
                        builder.StartVoice(new CultureInfo("en-US"));
                        EnHour(dt, builder);
                        break;
                    case "ru-RU":
                        builder.StartVoice(new CultureInfo("ru-RU"));
                        RuHours(dt, builder);
                        break;
                    default:
                        builder.StartVoice(new CultureInfo("en-US"));
                        EnHour(dt, builder);
                        break;
                }
                builder.EndVoice();
                synthesizer.Volume = 100;
                synthesizer.Speak(builder);
            }
        }

        private static void EnHour(DateTime dt, PromptBuilder builder)
        {
            if (dt.Hour == 1)
                builder.AppendText($"{dt.Hour} hour");
            else
                builder.AppendText($"{dt.Hour} hours");
        }

        private static void RuHours(DateTime dt, PromptBuilder builder)
        {
            if (dt.Hour == 1 || dt.Hour == 21)
                builder.AppendText($"{dt.Hour} час");
            else if (dt.Hour >= 2 && dt.Hour <= 4 || dt.Hour >= 22 && dt.Hour <= 23)
                builder.AppendText($"{dt.Hour} часа");
            else if (dt.Hour >= 5 && dt.Hour <= 20 || dt.Hour == 0)
                builder.AppendText($"{dt.Hour} часов");
        }

    }
}
