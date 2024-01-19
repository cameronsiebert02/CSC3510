using InClassCoverageExamples;
namespace StackTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestCanCreateStack()
    {
        MyStack s = new MyStack(3);
        Assert.AreEqual(0, s.size);
    }
    [TestMethod]
    public void TestPushCountsSize()
    {
        MyStack s = new MyStack(3);
        s.push(10);
        s.push(12);
        Assert.AreEqual(2, s.size);
    }
    [TestMethod]
    [ExpectedException(typeof(StackOverflowException))]
    public void TestPushTooMany()
    {
        MyStack s = new MyStack(3);
        s.push(10);
        s.push(12);
        s.push(14);
        s.push(16);
        //Assert.AreEqual(4, s.size);
    }
}