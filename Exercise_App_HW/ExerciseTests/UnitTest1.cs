namespace ExerciseTests;
using Exercise_App_HW;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestParseRowsCorrectly()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string inFile = path + "//..//..//Exercise_App_HW//Data//ExerciseData.txt";
        CalorieBurner cb = new CalorieBurner(inFile);
        cb.getRowsFromFile();
        cb.SetExerciseRecords();
        Assert.AreEqual(18, cb.exerData.Count);
    }
    [TestMethod]
    public void TestReadFileCorrectly()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string inFile = path + "//..//..//Exercise_App_HW//Data//ExerciseData.txt";
        CalorieBurner cb = new CalorieBurner(inFile);
        cb.getRowsFromFile();
        Assert.AreEqual(19, cb.rows.Length);
    }
    [TestMethod]
    [ExpectedException(typeof(FileNotFoundException))]
    public void TestReadWrongFileCorrectly()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string inFile = path + "//..//..//Exercise_App_HW//Data//ExerciseData2.txt";
        CalorieBurner cb = new CalorieBurner(inFile);
        cb.getRowsFromFile();
        Assert.AreEqual(19, cb.rows.Length);
    }
    [TestMethod]
    public void TestWalkingCaloriesOverThree()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string inFile = path + "//..//..//Exercise_App_HW//Data//ExerciseData.txt";
        CalorieBurner cb = new CalorieBurner(inFile);
        cb.getRowsFromFile();
        cb.SetExerciseRecords();
        Assert.AreEqual(62.5m, cb.getWalkingCalories(DateTime.Parse("2023-1-15")));
    }
    [TestMethod]
    public void TestWalkingCaloriesOverTwoHalf()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string inFile = path + "//..//..//Exercise_App_HW//Data//ExerciseData.txt";
        CalorieBurner cb = new CalorieBurner(inFile);
        cb.getRowsFromFile();
        cb.SetExerciseRecords();
        Assert.AreEqual(100m, cb.getWalkingCalories(DateTime.Parse("2023-1-14")));
    }
    [TestMethod]
    public void TestWalkingCaloriesUnderTwoHalf()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string inFile = path + "//..//..//Exercise_App_HW//Data//ExerciseData.txt";
        CalorieBurner cb = new CalorieBurner(inFile);
        cb.getRowsFromFile();
        cb.SetExerciseRecords();
        Assert.AreEqual(50m, cb.getWalkingCalories(DateTime.Parse("2023-1-11")));
    }
    [TestMethod]
    public void TestMoreThanOneWalkingCalories()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string inFile = path + "//..//..//Exercise_App_HW//Data//ExerciseData.txt";
        CalorieBurner cb = new CalorieBurner(inFile);
        cb.getRowsFromFile();
        cb.SetExerciseRecords();
        Assert.AreEqual(112.5m, cb.getWalkingCalories(DateTime.Parse("2023-1-6")));
    }
    [TestMethod]
    public void TestBikingCaloriesOverTwenty()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string inFile = path + "//..//..//Exercise_App_HW//Data//ExerciseData.txt";
        CalorieBurner cb = new CalorieBurner(inFile);
        cb.getRowsFromFile();
        cb.SetExerciseRecords();
        Assert.AreEqual(65.4m, cb.getBikingCalories(DateTime.Parse("2023-1-5")));
    }
    [TestMethod]
    public void TestBikingCaloriesOverFourteen()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string inFile = path + "//..//..//Exercise_App_HW//Data//ExerciseData.txt";
        CalorieBurner cb = new CalorieBurner(inFile);
        cb.getRowsFromFile();
        cb.SetExerciseRecords();
        Assert.AreEqual(55m, cb.getBikingCalories(DateTime.Parse("2023-1-8")));
    }
    [TestMethod]
    public void TestBikingCaloriesOverTen()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string inFile = path + "//..//..//Exercise_App_HW//Data//ExerciseData.txt";
        CalorieBurner cb = new CalorieBurner(inFile);
        cb.getRowsFromFile();
        cb.SetExerciseRecords();
        Assert.AreEqual(22.5m, cb.getBikingCalories(DateTime.Parse("2023-1-1")));
    }
    [TestMethod]
    public void TestBikingCaloriesJustAboveTen()
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string inFile = path + "//..//..//Exercise_App_HW//Data//ExerciseData.txt";
        CalorieBurner cb = new CalorieBurner(inFile);
        cb.getRowsFromFile();
        cb.SetExerciseRecords();
        Assert.AreEqual(22.5m, cb.getBikingCalories(DateTime.Parse("2023-1-13")));
    }
}