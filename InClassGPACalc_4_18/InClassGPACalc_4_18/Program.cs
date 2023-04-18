// See https://aka.ms/new-console-template for more information
using InClassGPACalc_4_18;

DB DBC = new DB();
string sId = getStudentId(DBC);
List<Course> courseList = DBC.GetCourses(sId);
IGPACalc gpa = new GPA_TestClass(courseList);
Console.WriteLine("GPA=" + gpa.getGPA());


string getStudentId(DB DBC)
{
    string sId = null;
    while (true)
    {
        Console.WriteLine("Enter a sId to lookup ->");
        sId = Console.ReadLine();
        if (!DBC.isValid(sId))
        {
            Console.WriteLine("sId does not exist, try again");
        }
        else
        {
            break;
        }
    }
    return sId;
}