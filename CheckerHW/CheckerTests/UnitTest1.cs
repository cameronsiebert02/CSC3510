using CheckerHW;

namespace CheckerTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestLengthRequirement()
    {
        string password = "i0$2J";
        Checker check = new Checker(password);
        Assert.AreEqual("1", check.checkPassword());
    }
    [TestMethod]
    public void TestUpperRequirement()
    {
        string password = "ifi*u2bi6jbwdi";
        Checker check = new Checker(password);
        Assert.AreEqual("2", check.checkPassword());
    }
    [TestMethod]
    public void TestLowerRequirement()
    {
        string password = "I2BFJ8IEB&FJON";
        Checker check = new Checker(password);
        Assert.AreEqual("3", check.checkPassword());
    }
    [TestMethod]
    public void TestSpecialCharacterRequirement()
    {
        string password = "IdF2Jfr4EBFJO";
        Checker check = new Checker(password);
        Assert.AreEqual("4", check.checkPassword());
    }
    [TestMethod]
    public void TestSpecialCharacterRequirement2()
    {
        string password = "IdFJ1frEB5FJO*";
        Checker check = new Checker(password);
        Assert.AreEqual("4", check.checkPassword());
    }
    [TestMethod]
    public void TestDigitRequirement()
    {
        string password = "Id$FJfrEBFJO";
        Checker check = new Checker(password);
        Assert.AreEqual("5", check.checkPassword());
    }
    [TestMethod]
    public void TestDigitRequirementWorks()
    {
        string password = "Id$F9Jf5rEBFJO";
        Checker check = new Checker(password);
        Assert.AreEqual("0", check.checkPassword());
    }
    [TestMethod]
    public void TestWordRequirement()
    {
        string password = "Id$F9Jbankf5rEBFJO";
        Checker check = new Checker(password);
        Assert.AreEqual("6", check.checkPassword());
    }
    [TestMethod]
    public void TestWordRequirementWorks()
    {
        string password = "Id$F9Jbnkf5rEBFJO";
        Checker check = new Checker(password);
        Assert.AreEqual("0", check.checkPassword());
    }
    [TestMethod]
    public void TestMultipleRequirements()
    {
        string password = "d9bankf";
        Checker check = new Checker(password);
        Assert.AreEqual("1,2,4,5,6", check.checkPassword());
    }
    [TestMethod]
    public void TestLengthLowerRequirements()
    {
        string password = "I9V&4I";
        Checker check = new Checker(password);
        Assert.AreEqual("1,3", check.checkPassword());
    }
}