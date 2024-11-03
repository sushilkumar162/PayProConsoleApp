## PayProConsoleApp
PayProConsoleApp is a C# console application designed to process payroll data across multiple departments. Each department's payroll data is stored in a separate CSV file. The application reads these files, validates the data, calculates payroll for each employee, and generates a summary report. Validation errors are logged separately, and the application supports asynchronous processing to handle multiple files concurrently.

## Table of Contents
- Features
- Project Structure
*Prerequisites
*Setup and Configuration
*Running the Application
*Output Files
*Running Tests
*Example Input and Output

## Features
Concurrent Processing: Processes multiple department files asynchronously.
Data Validation: Ensures each payroll entry has the required fields and correct data types.
Payroll Calculation: Calculates total payroll for each department and identifies the highest-paid employee.
Error Logging: Logs validation errors to a dedicated error log file.
Configuration File: Customizable paths for input files, reports, and error logs through appsettings.json.

## Project Structure


PayProConsoleAppSol
│
├── PayProConsoleApp
│   ├── Program.cs                # Main entry point
│   ├── appsettings.json          # Configuration file for directory paths
│   ├── Models                    
│   │   ├── Employee.cs           # Employee data model
│   │   └── PayrollSummary.cs     # Department payroll summary model
│   ├── Services                  
│   │   ├── PayrollCalculationService.cs  # Service for processing payroll files
│   │   └── ReportGenerationService.cs    # Service for generating payroll report
│   ├── Validators                
│   │   └── EmployeeValidator.cs  # Validator for payroll data
│   └── Utilities                 
│       ├── CsvReaderUtility.cs   # Utility to read CSV files
│       ├── ErrorLogger.cs        # Utility for logging errors
│       └── FileHelper.cs         # Utility for ensuring directories exist
│
├── PayrollFiles                  # Directory for input CSV files
├── Reports                       # Directory for generated payroll reports
├── ErrorLogs                     # Directory for error log file
└── PayProConsoleApp.Tests        # Unit tests for the application
    ├── EmployeeValidatorTests.cs
    └── PayrollCalculationServiceTests.cs

## Prerequisites
.NET SDK (version 5.0 or later)
Setup and Configuration
Clone the repository to your local machine:

bash

git clone <repository-url>
cd PayProConsoleAppSol
Navigate to the PayProConsoleApp folder and open appsettings.json. Update the file paths if needed.

json

{
    "Directories": {
        "PayrollFiles": "../PayrollFiles",
        "Reports": "../Reports",
        "ErrorLogs": "../ErrorLogs"
    }
}
PayrollFiles: Directory where input CSV files are stored.
Reports: Directory where the summary report will be generated.
ErrorLogs: Directory where validation errors will be logged.
Create the PayrollFiles, Reports, and ErrorLogs folders in the project root if they don't already exist.

Running the Application
To run the application, execute the following command in the project directory:

bash

dotnet run --project PayProConsoleApp
The console output will indicate that payroll files are being processed. Once completed, check the Reports and ErrorLogs directories for the generated files.

Output Files
PayrollReport.txt (in Reports directory): A summary report for each department with:

Total payroll amount.
The highest-paid employee.
Example:



Department: Finance
Total Payroll: $5250.00
Highest Paid Employee: John Doe ($1020.00)
ErrorLog.txt (in ErrorLogs directory): Logs any validation errors encountered while processing files.

Example:



Error in Finance.csv: Missing HoursWorked for Employee 1003
Error in HR.csv: Invalid HourlyRate for Employee 1004 (not a valid decimal)
Running Tests
This project includes unit tests for validation and payroll calculation logic.

Navigate to the project root:

bash

cd PayProConsoleAppSol
Run the tests using the following command:

bash

dotnet test
The test results will display in the console, verifying that the validation and payroll calculation logic work as expected.

Example Input and Output
Example Input (CSV Files in PayrollFiles Directory)
Finance.csv

csv

EmployeeId,Name,HoursWorked,HourlyRate
1001,John Doe,40,25.50
1002,Jane Smith,35,30.00
1003,Chris Johnson,45,20.00
HR.csv

csv

EmployeeId,Name,HoursWorked,HourlyRate
2001,Emily Taylor,38,22.50
2002,Alex Lee,40,21.00
2003,Patricia Kim,42,24.00
Example Output
PayrollReport.txt



Department: Finance
Total Payroll: $2975.00
Highest Paid Employee: John Doe ($1020.00)

Department: HR
Total Payroll: $2690.00
Highest Paid Employee: Patricia Kim ($1008.00)
ErrorLog.txt (if any validation errors are encountered)



Error in Finance.csv: Invalid HoursWorked for Employee 1004 (not a valid decimal)
