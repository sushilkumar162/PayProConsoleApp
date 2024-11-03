using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayProConsoleApp.Models;
using PayProConsoleApp.Services;

[TestClass]
public class PayrollCalculationServiceTests
{
    private PayrollCalculationService _service;

    [TestInitialize]
    public void SetUp()
    {
        _service = new PayrollCalculationService();
    }

    [TestMethod]
    public void CalculateTotalPay_ReturnsCorrectValue()
    {
        var employee = new Employee { HoursWorked = 40, HourlyRate = 25.5M };
        Assert.AreEqual(1020, employee.TotalPay);
    }
}
