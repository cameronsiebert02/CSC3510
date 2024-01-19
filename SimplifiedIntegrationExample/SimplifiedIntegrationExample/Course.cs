using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedIntegrationExample
{
    public class Course {
        // Data Container for course
        public string sId { get; set; }
        public string courseName { get; set; }
        public int gradePts { get; set; }

        public Course(string sId, string courseName, int gradePts) {
            this.sId = sId;
            this.courseName = courseName;
            this.gradePts = gradePts;
        }
    }

}
