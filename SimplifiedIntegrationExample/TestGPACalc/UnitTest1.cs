namespace TestGPACalc;
using SimplifiedIntegrationExample;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestRedundantCourse()
    {
        //DB myDB = new DB();
        IDatabase myDB = new DBStub();
        string sId = "S101";
        List<Course> courses = myDB.GetCourses(sId);
        GPACalc gpa = new GPACalc(sId, myDB);
        Assert.AreEqual(3, gpa.getGPA());
    }
    [TestMethod]
    public void TestNoRedundantCourses()
    {
        //DB myDB = new DB();
        IDatabase myDB = new DBStub();
        string sId = "S102";
        List<Course> courses = myDB.GetCourses(sId);
        GPACalc gpa = new GPACalc(sId, myDB);
        Assert.AreEqual(3, gpa.getGPA());
    }
    [TestMethod]
    public void TestStudentNoCourses()
    {
        //DB myDB = new DB();
        IDatabase myDB = new DBStub();
        string sId = "S112";
        List<Course> courses = myDB.GetCourses(sId);
        GPACalc gpa = new GPACalc(sId, myDB);
        Assert.AreEqual(0, gpa.getGPA());
    }
}