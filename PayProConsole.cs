using PayProConsoleApp.Services;
using PayProConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PayProConsoleApp
{
    public class PayProConsole
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Processing payroll files...");
            // Adjust path for appsettings.json if needed
            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            

            var config = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(File.ReadAllText("appsettings.json"))["Directories"];
            var payrollDirectory = config["PayrollFiles"];
            var reportDirectory = config["Reports"];
            var errorLogDirectory = config["ErrorLogs"];

            FileHelper.EnsureDirectoryExists(reportDirectory);
            FileHelper.EnsureDirectoryExists(errorLogDirectory);

            var payrollService = new PayrollCalculationService();
            var filePaths = Directory.GetFiles(payrollDirectory, "*.csv");

            var tasks = filePaths.Select(async filePath =>
            {
                try
                {
                    return await payrollService.ProcessPayrollFileAsync(filePath, errorLogDirectory);
                }
                catch (Exception ex)
                {
                    ErrorLogger.LogError(errorLogDirectory, Path.GetFileNameWithoutExtension(filePath), ex.Message);
                    return null;
                }
            });

            var summaries = await Task.WhenAll(tasks);

            var reportPath = Path.Combine(reportDirectory, "PayrollReport.txt");
            ReportGenerationService.GenerateReport(summaries.Where(s => s != null), reportPath);

            Console.WriteLine("Payroll processing completed. Check PayrollReport.txt and ErrorLog.txt for results.");
        }
    }
}
