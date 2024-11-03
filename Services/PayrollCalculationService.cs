using PayProConsoleApp.Models;
using PayProConsoleApp.Validators;
using PayProConsoleApp.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PayProConsoleApp.Services
{
    public class PayrollCalculationService
    {
        public async Task<PayrollSummary> ProcessPayrollFileAsync(string filePath, string errorLogDirectory)
        {
            var employees = new List<Employee>();
            var department = Path.GetFileNameWithoutExtension(filePath);

            foreach (var line in await CsvReaderUtility.ReadFileAsync(filePath))
            {
                var fields = line.Split(',');

                if (!EmployeeValidator.Validate(fields, out string errorMessage))
                {
                    ErrorLogger.LogError(errorLogDirectory, department, errorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    EmployeeId = int.Parse(fields[0]),
                    Name = fields[1],
                    HoursWorked = decimal.Parse(fields[2]),
                    HourlyRate = decimal.Parse(fields[3])
                };

                employees.Add(employee);
            }

            return new PayrollSummary
            {
                Department = department,
                TotalPayroll = employees.Sum(e => e.TotalPay),
                HighestPaidEmployee = employees.OrderByDescending(e => e.TotalPay).FirstOrDefault()
            };
        }
    }
}
