using System;
namespace InClassGPACalc_4_18
{
	public class Course
	{
		// Data Container for course
		public string sId { get; set; }
		public string courseName { get; set; }
		public int gradePts { get; set; }

        public Course(string sId, string courseName, int gradePts)
        {
            this.sId = sId;
            this.courseName = courseName;
            this.gradePts = gradePts;
        }
    }
}

