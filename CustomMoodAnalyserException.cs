using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProgram
{
    public class CustomMoodAnalyserException : Exception
    {
        public enum ExceptionType
        {
            NULL,
            EMPTY
        }
        ExceptionType type;
        public CustomMoodAnalyserException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
