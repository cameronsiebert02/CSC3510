namespace TestSalary;
using InClass_2_2_Salart;
[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestSalaryWorks()
    {
        SalaryCalculator sc = new SalaryCalculator(10);
        Assert.AreEqual(100.0m, sc.GetAnnualSalary(10.00m));
    }
    [TestMethod]
    public void TestSalaryWorksWithNegRate()
    {
        SalaryCalculator sc = new SalaryCalculator(52);
        Assert.AreEqual(0.0m, sc.GetAnnualSalary(-10.00m));
    }
    [TestMethod]
    public void TestSalaryWorksWithNegWeeks()
    {
        SalaryCalculator sc = new SalaryCalculator(-2);
        Assert.AreEqual(0.0m, sc.GetAnnualSalary(10.00m));
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "Price not right")]
    public void TestSalaryWorksWithIllegalWeeks()
    {
        SalaryCalculator sc = new SalaryCalculator(55);
        Assert.AreEqual(0.0m, sc.GetAnnualSalary(10.00m));
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "Price not right")]
    public void TestSalaryWorksWithSettingWeeks()
    {
        SalaryCalculator sc = new SalaryCalculator(55);
        sc.weeks = 200;
        Assert.AreEqual(0.0m, sc.GetAnnualSalary(10.00m));
    }
}