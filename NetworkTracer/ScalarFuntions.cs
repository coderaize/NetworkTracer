using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace NetworkTracer
{
    class ScalarFuntions
    {
        public static string GetFirstRegexMatch(string pattern, string text)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(text, pattern))
                return System.Text.RegularExpressions.Regex.Matches(text, pattern, RegexOptions.IgnoreCase)[0].Value ?? null;
            else return "";
        }

        public static bool MatchRegex(string pattern, string text)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(text, pattern);
        }

        private static readonly Random random = new Random();
        public static string GetRandomString(int Length)
        {
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", Length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static bool IsInternetConnected
        {
            get
            {
                string host = "google.com";
                bool result = false;
                Ping p = new Ping();
                try
                {
                    PingReply reply = p.Send(host, 5000);
                    if (reply.Status == IPStatus.Success)
                        return true;
                }
                catch { return false; }
                return result;
            }
        }


        /// <summary>
        /// Becomes Dheet while deleting a file
        /// </summary>
        /// <param name="fullPath"></param>
        public static void DeleteFile(string fullPath)
        {
            try
            {
                File.Delete(fullPath);
            }
            catch { DeleteFile(fullPath); }
        }


    }
}
