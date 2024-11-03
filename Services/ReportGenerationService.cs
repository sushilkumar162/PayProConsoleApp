using PayProConsoleApp.Models;
using System.Collections.Generic;
using System.IO;

namespace PayProConsoleApp.Services
{
    public static class ReportGenerationService
    {
        public static void GenerateReport(IEnumerable<PayrollSummary> summaries, string reportPath)
        {
            using var writer = new StreamWriter(reportPath);

            foreach (var summary in summaries)
            {
                writer.WriteLine($"Department: {summary.Department}");
                writer.WriteLine($"Total Payroll: ${summary.TotalPayroll:F2}");
                writer.WriteLine($"Highest Paid Employee: {summary.HighestPaidEmployee.Name} (${summary.HighestPaidEmployee.TotalPay:F2})");
                writer.WriteLine();
            }
        }
    }
}
