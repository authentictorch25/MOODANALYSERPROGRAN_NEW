using System;

namespace MoodAnalyserProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MOOD ANALYSER PROGRAM");
            string message = "i am very sad";
            MoodAnalyser moodAnalyser = new MoodAnalyser();
            Console.WriteLine("MOOD : {0}", moodAnalyser.AnalyseMood());
        }
    }
}
