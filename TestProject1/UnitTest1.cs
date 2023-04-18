namespace TestProject1;
using InClassGPACalc_4_18;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        List<Course> courseList = new List<Course>();
        courseList.Add(new Course("S101", "CSC1010", 2));
        courseList.Add(new Course("S101", "CSC1010", 3));
        courseList.Add(new Course("S101", "CSC1010", 4));
        courseList.Add(new Course("S101", "CSC1700", 2));
        GPACalc gpa = new GPACalc(courseList);
        Assert.AreEqual(3, gpa.getGPA());
    }
}