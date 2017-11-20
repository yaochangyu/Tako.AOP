using System;
using System.IO;

namespace Tako.AOP.LogExtension
{
    [AttributeUsage(AttributeTargets.Method,
        AllowMultiple = true, Inherited = false)]
    public class LoggingAttribute : Attribute
    {
        private readonly string _path;

        public LoggingAttribute()
        {
            this._path = $"{this.FileName}{DateTime.UtcNow.ToString("yyyyMMdd")}.txt";
            if (!File.Exists(this._path))
            {
                using (var writer = File.Open(this._path, FileMode.CreateNew, FileAccess.Write))
                {
                }
            }
        }

        public string FileName { get; set; } = "log";

        public void WriteBeforeLog(string methodName)
        {
            using (var writer = File.AppendText(this._path))
            {
                var msg = $"Entry {methodName} => {DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss")}";
                Console.WriteLine(msg);
                writer.WriteLine(msg);
            }
        }

        public void WriteAfterLog(string methodName)
        {
            using (var writer = File.AppendText(this._path))
            {
                var msg = $"Finish {methodName} => {DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss")}";
                Console.WriteLine(msg);
                writer.WriteLine(msg);
            }
        }

        private void Log(string logMessage, TextWriter w)
        {

        }
    }
}