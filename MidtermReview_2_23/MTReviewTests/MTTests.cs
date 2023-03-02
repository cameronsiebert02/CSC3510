using MidtermReview_2_23;
using Moq;
using ReviewMT;

namespace MTReviewTests;

[TestClass]
public class MTTests
{
    [TestMethod]
    public void TestTotalTaxedOwed()
    {
        // Test whether or not total tax owed from all the data it correct or not
        // This includes if all different brackets were implemented correctly
        getTaxDataFromDB gd = new getTaxDataFromDB();
        TaxChecker tc = new TaxChecker(gd);
        Assert.AreEqual(128155m, tc.processTaxForms());
        // Finds a bug because the data points above 100000 do not calculate correctly,
        // therefore making this also fail
    }
    [TestMethod]
    public void TestIncomeLess50000TaxOwed()
    {
        // test if income being less than 50000 (on the boundary of 50000)
        // correctly calculates tax for that person
        IGetData gd = new getTaxDataFromDB();
        var serviceMock = new Mock<getTaxDataFromDB>();
        TaxChecker tc = new TaxChecker(gd);
        TaxForm tf = new TaxForm("122118901", 49999.9m);
        Assert.AreEqual(4999.99m, tc.getTaxOwed(tf));
    }
    [TestMethod]
    public void TestIncome50000TaxOwed()
    {
        // test if income being 50000 (the boundary of 50000 for the bracket)
        // correctly calculates tax (should be 15%) for that person
        IGetData gd = new getTaxDataFromDB();
        TaxChecker tc = new TaxChecker(gd);
        TaxForm tf = new TaxForm("122118901", 50000m);
        Assert.AreEqual(7500, tc.getTaxOwed(tf));
    }
    [TestMethod]
    public void TestIncome100000TaxOwed()
    {
        // test if income being 100000 (the boundary of 100000 for the bracket)
        // correctly calculates tax (should be 15%) for that person
        IGetData gd = new getTaxDataFromDB();
        TaxChecker tc = new TaxChecker(gd);
        TaxForm tf = new TaxForm("122118901", 100000m);
        Assert.AreEqual(15000, tc.getTaxOwed(tf));
    }
    [TestMethod]
    public void TestIncomeOver100000TaxOwed()
    {
        // test if income being more than 100000 (the boundary of 100000 bracket)
        // correctly calculates tax (should be 20% now) for that person
        IGetData gd = new getTaxDataFromDB();
        TaxChecker tc = new TaxChecker(gd);
        TaxForm tf = new TaxForm("122118901", 110000m);
        Assert.AreEqual(22000, tc.getTaxOwed(tf));
        // Finds a bug where income being over 100000 is not calculated at 20%
        // rather it calculates at 10%
    }
    [TestMethod]
    public void TestTaxEqual0()
    {
        // Tests to see if tax owed for a single person will remain at 0
        // if it recogmnizes the boundary includes 0 or not
        IGetData gd = new getTaxDataFromDB();
        TaxChecker tc = new TaxChecker(gd);
        TaxForm tf = new TaxForm("122118901", 0m);
        Assert.AreEqual(0, tc.getTaxOwed(tf));
    }
    [TestMethod]
    public void TestTaxLess0()
    {
        // Tests to see if the tax owed by a single person will be set to 0
        // if it would have been less than 0 after calculation
        IGetData gd = new getTaxDataFromDB();
        TaxChecker tc = new TaxChecker(gd);
        TaxForm tf = new TaxForm("122118901", -1000m);
        Assert.AreEqual(0, tc.getTaxOwed(tf));
        // Finds bug where tax is not set to 0 when the input is negative,
        // tax is supposed to be >= 0
    }

    [TestMethod]
    public void TestTaxFormCorrect()
    {
        // Tests for the correct tax form length with no problems
        TaxForm tf = new TaxForm("122118981", 10000m);
        Assert.IsTrue(tf.validSSN());
    }
    [TestMethod]
    public void TestTaxFormSixInFirstThree()
    {
        // Tests for there being a 6 in any of the first 3 positions
        // makes sure it returns false
        TaxForm tf = new TaxForm("666118901", 10000m);
        Assert.IsFalse(tf.validSSN());
    }
    [TestMethod]
    public void TestTaxFormIncorrectLength()
    {
        // Tests for length being less than 9 and making sure it returns false
        TaxForm tf = new TaxForm("1221", 10000m);
        Assert.IsFalse(tf.validSSN());
        // The code does not recognize a length less than 9 being incorrect
    }
    [TestMethod]
    public void TestTaxFormIncorrectLength2()
    {
        // Tests for incorrect length on the high end with lenght being over 9
        // makes sure it returns false
        TaxForm tf = new TaxForm("12218758758754", 10000m);
        Assert.IsFalse(tf.validSSN());
    }
    [TestMethod]
    public void TestTaxFormHasZero()
    {
        // Tests for a 0 in any position to return false or it not being valid
        TaxForm tf = new TaxForm("122107679", 10000m);
        Assert.IsFalse(tf.validSSN());
        // The code does not properly find a 0 in the string to make sure it returns false
    }
}