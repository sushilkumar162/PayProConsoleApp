using System.IO;

namespace PayProConsoleApp.Utilities
{
    public static class ErrorLogger
    {
        public static void LogError(string errorLogDirectory, string department, string errorMessage)
        {
            var logPath = Path.Combine(errorLogDirectory, "ErrorLog.txt");
            using var writer = new StreamWriter(logPath, append: true);
            writer.WriteLine($"Error in {department}.csv: {errorMessage}");
        }
    }
}
