using System;
namespace InClassGPACalc_4_18
{
	public class DB
	{
		public string DBName { get; set; }

        public DB()
        {
        }

        public List<Course> GetCourses(string sId)
        {
            List<Course> courseList = new List<Course>();
            // Query the DB fpr the Courselist where id='sId'
            return courseList;
        }

        public bool isValid(string sId)
        {
            // Query the DB and return true if sId is in DB
            // false otherwise
            // Select * from DBName where studentid="sId"
            return true;
        }
    }
}