using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedIntegrationExample
{
    public class DB : IDatabase {
        public string DBName { get; set; }

        public DB() {
        }
        public List<Course> GetCourses(string sId) {
            List<Course> courseList = new List<Course>();
            // Query the DB for the Courselist where Id='sId'
            // Will just hard code it here ... but 
            //    ... this is what is supposed to provide by query of DB
            //    ... but its development is behind and not ready
            //courseList.Add(new Course(sId, "CSC1700", 0));
            //courseList.Add(new Course(sId, "CSC1700", 1));
            //courseList.Add(new Course(sId, "CSC1700", 2));
            //courseList.Add(new Course(sId, "CSC2200", 4));
            return courseList;
        }
        public bool isValid(string sId) {
            // query the DB and return true if sId Is in DB 
            // false otherswise
            // Select * from DBname where studentid="iId"
            return true;
        }
    }
}
