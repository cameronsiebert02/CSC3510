namespace PhoneNumberTests;
using PhoneNumberChecker;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestValidLength10Digit()
    {
        string pNum = "555-121-2222";
        PhoneNumber pn = new PhoneNumber(pNum);
        Assert.IsTrue(pn.isValidPhone());
    }
    [TestMethod]
    public void TestValidLength7Digit()
    {
        string pNum = "121-2222";
        PhoneNumber pn = new PhoneNumber(pNum);
        Assert.IsTrue(pn.isValidPhone());
    }
    [TestMethod]
    public void TestValid12Length()
    {
        string pNum = "555-121-2222";
        PhoneNumber pn = new PhoneNumber(pNum);
        Assert.IsFalse(pn.isValid12Length());
    }
    [TestMethod]
    public void TestNotValid12Length()
    {
        string pNum = "555-121x2222";
        PhoneNumber pn = new PhoneNumber(pNum);
        Assert.IsTrue(pn.isValid12Length());
    }
    [TestMethod]
    public void TestJustDigitsWDash()
    {
        string pNum = "555-121-2222";
        PhoneNumber pn = new PhoneNumber(pNum);
        Assert.IsTrue(pn.justDigits());
    }
    [TestMethod]
    public void TestJustDigitsWDashBad()
    {
        string pNum = "555-121-22-2";
        PhoneNumber pn = new PhoneNumber(pNum);
        Assert.IsFalse(pn.justDigits());
    }
    [TestMethod]
    public void ProveProfWrong()
    {
        string pNum = "555-121-b222";
        PhoneNumber pn = new PhoneNumber(pNum);
        Assert.IsTrue(pn.isValidPhone());
    }
}