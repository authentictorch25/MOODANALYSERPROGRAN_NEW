using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyserProgram
{
    public class MoodAnalyserReflection
    {
        public static object CreateMoodAnalyzerObject(string className, string constructorName, string message = "DEFAULT")
        {
            string pattern = @"." + constructorName + "$";
            var isMatch = Regex.IsMatch(className, pattern);
            if (isMatch)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    var type = assembly.GetType(className);
                    //The Activator.CreateInstance method creates an instance of a type defined in an assembly by invoking the constructor that best matches the specified arguments. 
                    //If no arguments are specified then the constructor that takes no parameters, that is, the default constructor, is invoked.
                    if (message == "DEFAULT")
                        return Activator.CreateInstance(type);
                    else
                        return Activator.CreateInstance(type, message);
                }
                catch (ArgumentNullException)
                {
                    // Exceptions: System.ArgumentNullException, when type is null.
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "No such class found");
                }
            }
            else
            {
                //This block will execute when constructorName don't match with className, though any of them can be invalid
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "No such constructor found");
            }
            
        }
        public static string InvokeAnalyseMood(string methodName, string message)
        {
            try
            {
                
                MoodAnalyser moodAnalyzer = (MoodAnalyser)MoodAnalyserReflection.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
              
                var type = typeof(MoodAnalyser);
                
                //GetMethod Returns an object that represents the public method with the specified name, if found; otherwise, null.
                
                var analyseMoodMethod = type.GetMethod(methodName);
                // Now invoke method using meta information of method, need an instance of class and parameters as arguments
                var mood = analyseMoodMethod.Invoke(moodAnalyzer, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                // Get methods returns null incase no method is found with given methodName
                // Invoke method will throw exception
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "No such method found");
            }
            catch (TargetInvocationException ex)
            {
                // When message is null or empty this exception is thrown
                throw ex.InnerException;
            }
        }
    }
}
