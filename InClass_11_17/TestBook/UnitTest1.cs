using InClass_11_17;

namespace TestBook;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestPricePerPage()
    {
        Book b = new Book("Good Grief", 100, 20m, 10);
        Console.WriteLine("Expected .2 Actual {0}", b.PricePerPage());
        Assert.AreEqual(.2m, b.PricePerPage());
    }
    [TestMethod]
    public void TestPricePerPageFractional()
    {
        Book b = new Book("Good Grief", 100, 200m, 10);
        Console.WriteLine("Expected .2 Actual {0}", b.PricePerPage());
        Assert.AreEqual(2m, b.PricePerPage());
    }
    [TestMethod]
    public void TestPricePerPageZero()
    {
        Book b = new Book("Good Grief", 0, 100m, 10);
        Console.WriteLine("Expected 0 Actual {0}", b.PricePerPage());
        Assert.AreEqual(0m, b.PricePerPage());
    }
    [TestMethod]
    public void TestNoReorder()
    {
        Book b = new Book("Good Grief", 100, 100m, 100);
        Console.WriteLine("Expected False Actual {0}", b.reOrder());
        Assert.IsFalse(b.reOrder());
    }
    [TestMethod]
    public void TestNoReorder100PriceTrue()
    {
        Book b = new Book("Good Grief", 100, 100m, 10);
        Console.WriteLine("Expected True Actual {0}", b.reOrder());
        Assert.IsTrue(b.reOrder());
    }
    [TestMethod]
    public void TestNoReorder100PriceFalse()
    {
        Book b = new Book("Good Grief", 100, 100m, 20);
        Console.WriteLine("Expected False Actual {0}", b.reOrder());
        Assert.IsFalse(b.reOrder());
    }
    [TestMethod]
    public void TestNoReorder50PriceTrue()
    {
        Book b = new Book("Good Grief", 100, 50m, 20);
        Console.WriteLine("Expected True Actual {0}", b.reOrder());
        Assert.IsTrue(b.reOrder());
    }
}
