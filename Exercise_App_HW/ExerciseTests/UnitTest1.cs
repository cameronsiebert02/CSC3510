namespace ExerciseTests;
using Exercise_App_HW;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestReadRowsCorrectly()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string inFile = path + "//..//..//Exercise_App_HW//Data//ExerciseData.txt";
        Console.WriteLine(inFile);
        CalorieBurner cb = new CalorieBurner(inFile);
        cb.getRowsFromFile();
        cb.SetExerciseRecords();
        Assert.AreEqual(18, cb.exerData.Count);
    }
    //[TestMethod]
    //[ExpectedException(typeof(ArgumentException), "Price not right")]
    //public void TestBadPrice()
    //{
    //    string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
    //    string inFile = path + "//..//..//InClass_1_19//Input//Test1_Inventory.txt";
    //    InventManager im = new InventManager(inFile);
    //    im.setDataFromFile();
    //    im.parseRows();
    //    Assert.AreEqual(6, im.rows.Length);
    //}
}