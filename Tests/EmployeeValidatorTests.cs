using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayProConsoleApp.Validators;

[TestClass]
public class EmployeeValidatorTests
{
    [TestMethod]
    public void Validate_WithMissingField_ReturnsFalse()
    {
        var record = new string[] { "1001", "John Doe", "40" };
        var result = EmployeeValidator.Validate(record, out string errorMessage);
        Assert.IsFalse(result);
        Assert.AreEqual("Missing fields", errorMessage);
    }

    [TestMethod]
    public void Validate_WithInvalidHourlyRate_ReturnsFalse()
    {
        var record = new string[] { "1001", "John Doe", "40", "invalidRate" };
        var result = EmployeeValidator.Validate(record, out string errorMessage);
        Assert.IsFalse(result);
        Assert.AreEqual("Invalid HourlyRate", errorMessage);
    }
}
