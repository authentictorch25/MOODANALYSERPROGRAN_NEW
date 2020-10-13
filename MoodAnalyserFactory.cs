using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyserProgram
{
    public class MoodAnalyserFactory
    {
    public static object CreateMoodAnalyse(string className, string constructorName)
    {
        string pattern = @"." + constructorName + "$";
        Match result = Regex.Match(className, pattern);
        if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnayseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnayseType);
                }
                catch (ArgumentNullException)
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "CLASS NOT FOUND");
                }
            }
        else
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "CONSTRUCTOR IS NOT FOUND");

        }
    }
}
