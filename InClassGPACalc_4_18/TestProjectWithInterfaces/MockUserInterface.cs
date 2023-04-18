using System;
using InClassGPACalc_4_18;

namespace TestProjectWithInterfaces
{
    public class MockUserInterface : IUserInterface
    {
        public string getStudentId(DB DBC)
        {
            string sId = "S101";
            IDatabase database = new DB_Tester();
            List<Course> courses = database.GetCourses(sId);
            return sId;
        }
    }
}

