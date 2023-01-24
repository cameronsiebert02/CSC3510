using InClass_1_19;

namespace TestInClass_1_19;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestCanReadRows()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string inFile = path + "//..//..//InClass_1_19//Input//Inventory.txt";
        InventManager im = new InventManager(inFile);
        im.setDataFromFile();
        Assert.AreEqual(6, im.rows.Length);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException),"Price not right")]
    public void TestBadPrice()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string inFile = path + "//..//..//InClass_1_19//Input//Test1_Inventory.txt";
        InventManager im = new InventManager(inFile);
        im.setDataFromFile();
        im.parseRows();
        Assert.AreEqual(6, im.rows.Length);
    }
}