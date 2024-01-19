using System;
namespace TestGPACalc;
using System.Collections.Generic;
using SimplifiedIntegrationExample;
	public class DBStub : IDatabase
{
    public List<Course> GetCourses(string sId)
    {
        List<Course> courses = new List<Course>();
        if(sId.Equals("S101"))
        {
            courses.Add(new Course(sId, "CSC1700", 0));
            courses.Add(new Course(sId, "CSC1700", 1));
            courses.Add(new Course(sId, "CSC1700", 2));
            courses.Add(new Course(sId, "CSC1700", 3));
        }else if (sId.Equals("S102"))
        {
            courses.Add(new Course(sId, "CSC1700", 4));
            courses.Add(new Course(sId, "CSC2200", 3));
            courses.Add(new Course(sId, "CSC2300", 2));
        }
        return courses;
    }

    public bool isValid(string sId)
    {
        throw new NotImplementedException();
    }
}