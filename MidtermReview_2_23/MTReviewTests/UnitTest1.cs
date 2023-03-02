using MidtermReview_2_23;
using ReviewMT;

namespace MTReviewTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestGallonsGreaterThanTank()
    {
        MPG tester = new MPG(25.5d, 25.5d, 13);
        Assert.AreEqual(25.5d, tester.getMPG());
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestGallonsLessThanZero()
    {
        MPG tester = new MPG(25.5d, -1.4d, 13);
        Assert.AreEqual(-1.4d, tester.getMPG());
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestTankLessThanZero()
    {
        MPG tester = new MPG(25.5d, 25.5d, -5);
        Assert.AreEqual(25.5d, tester.getMPG());
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestTankGreaterThan60()
    {
        MPG tester = new MPG(25.5d, 25.5d, 100);
        Assert.AreEqual(25.5d, tester.getMPG());
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestTankLessThanTen()
    {
        MPG tester = new MPG(25.5d, 25.5d, 6);
        Assert.AreEqual(25.5d, tester.getMPG());
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestGallonsMoreThanOne()
    {
        MPG tester = new MPG(25.5d, 0.9d, 13);
        Assert.AreEqual(0.9d, tester.getMPG());
    }
    [TestMethod]
    public void TestReturnsProperly()
    {
        MPG tester = new MPG(500.0d, 10.0d, 13);
        Assert.AreEqual(50.0d, tester.getMPG());
    }
    [TestMethod]
    public void TestGetsData()
    {
        GetDataFromList gdl = new GetDataFromList();
        ClassGrader cg = new ClassGrader(gdl);
    }
}