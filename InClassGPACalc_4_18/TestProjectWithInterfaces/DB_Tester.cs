using System;
using InClassGPACalc_4_18;

namespace TestProjectWithInterfaces
{
	public class DB_Tester : IDatabase
	{
        public List<Course> GetCourses(string sId)
        {
            List<Course> courses = new List<Course>();
            courses.Add(new Course("S101", "CSC1700", 4));
            return courses;

        }

        public bool isValid(string sId)
        {
            return true;
        }
    }
}

