using System;

namespace YtDownloadA.Utils
{
    internal static class TimeUtils
    {
        public static string CurrentTime
        {
            get
            {
                return $"{DateTime.Now.Date.ToString()}, {DateTime.Now.Minute}";
            }
        }
    }
}
