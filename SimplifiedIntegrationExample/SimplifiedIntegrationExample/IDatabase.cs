using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedIntegrationExample
{
    public interface IDatabase {
        public List<Course> GetCourses(string sId);
        public bool isValid(string sId);
    }
}
