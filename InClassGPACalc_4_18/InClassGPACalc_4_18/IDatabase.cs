using System;
namespace InClassGPACalc_4_18
{
	public interface IDatabase
	{
        public List<Course> GetCourses(string sId);
        public bool isValid(string sId);

    }
}

