namespace PayProConsoleApp.Validators
{
    public static class EmployeeValidator
    {
        public static bool Validate(string[] record, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (record.Length < 4)
            {
                errorMessage = "Missing fields";
                return false;
            }

            if (!int.TryParse(record[0], out _))
            {
                errorMessage = "Invalid EmployeeId";
                return false;
            }

            if (string.IsNullOrWhiteSpace(record[1]))
            {
                errorMessage = "Name is missing";
                return false;
            }

            if (!decimal.TryParse(record[2], out _))
            {
                errorMessage = "Invalid HoursWorked";
                return false;
            }

            if (!decimal.TryParse(record[3], out _))
            {
                errorMessage = "Invalid HourlyRate";
                return false;
            }

            return true;
        }
    }
}
