using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MoodAnalyserProgram
{
    public class MoodAnalyser
    {
        string message;
        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        public MoodAnalyser()
        {
            message = "";
        }

        public string AnalyseMood()
        {
            try
            {
                if (this.message.ToUpper().Contains("SAD"))
                {
                    return "SAD";
                }
                else
                    return "HAPPY";
            }
            catch(NullReferenceException)
            {
                return "HAPPY";
            }
        }
    }
}
