using System;


namespace Alza.Common.Logger
{
    public class ConsoleLogger : IAlzaLogger
    {
        public void Log(string message)
        {
            Log(message, Level.Information);
        }
        public void Log(string message, Level level)
        {
            Log(message, level, null);
        }
        public void LogError(string message, Exception ex)
        {
            Log(message, Level.Error, ex.ToString());
        }
        public void Log(string message, Level level, string moreMessage)
        {
            Console.WriteLine($"{DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss.fff")} {level} {message}" + (moreMessage != null ? " " + moreMessage : string.Empty));
        }
    }
}