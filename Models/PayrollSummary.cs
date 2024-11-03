namespace PayProConsoleApp.Models
{
    public class PayrollSummary
    {
        public string Department { get; set; }
        public decimal TotalPayroll { get; set; }
        public Employee HighestPaidEmployee { get; set; }
    }
}
