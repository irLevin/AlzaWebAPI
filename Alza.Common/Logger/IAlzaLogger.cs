using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Common.Logger
{
    public interface IAlzaLogger
    {
        void Log(string message);
        void Log(string message, Level level);
        void LogError(string message, Exception ex);
    }
}
