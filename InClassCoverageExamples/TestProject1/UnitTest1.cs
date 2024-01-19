namespace TestProject1;
using InClassCoverageExamples;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        MyClass mc = new MyClass();
        Assert.AreEqual("Even", mc.checkSumOddEven(2, 4));
    }
    [TestMethod]
    public void TestTheOddCase()
    {
        MyClass mc = new MyClass();
        Assert.AreEqual("Odd", mc.checkSumOddEven(2, 3));
    }
    [TestMethod]
    public void TestIsBigNOT()
    {
        MyClass mc = new MyClass();
        Assert.IsFalse(mc.isBig(3));
    }
    [TestMethod]
    public void TestIsBig()
    {
        MyClass mc = new MyClass();
        Assert.IsTrue(mc.isBig(5));
    }
}