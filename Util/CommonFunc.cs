using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptPrice_DataCenter.Util
{
    public static class CommonFunc
    {
        public static int GetIntValue(string MStr, int defaultValue = 0)
        {
            if (string.IsNullOrEmpty(MStr)) return defaultValue;
            if (int.TryParse(MStr.Replace(",", ""), out int result)) return result;
            return defaultValue;
        }
        public static float GetFloatValue(string MStr, float defaultValue = 0)
        {
            if (string.IsNullOrEmpty(MStr)) return defaultValue;
            if (float.TryParse(MStr, out float result)) return result;
            return defaultValue;
        }
        public static void WriteLog(string message)
        {
            string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);

            string logFile = Path.Combine(logDir, DateTime.Now.ToString("yyyyMMdd") + ".log");

            using (StreamWriter writer = new StreamWriter(logFile, true))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}");
            }
        }
    }
}
