using System;
namespace InClassGPACalc_4_18
{
	public class GPACalc : IGPACalc
	{
		List<Course> courseList = new List<Course>();

        public GPACalc(List<Course> courseList)
        {
            this.courseList = courseList;
        }

        public double getGPA()
        {
            double gpa = 0.0;
            int sum = 0;
            int ct = 0;
            Dictionary<string, int> uniqueCourses = getCoursesToUse();
            foreach(string course in uniqueCourses.Keys)
            {
                sum += uniqueCourses[course];
                ct += 1;
            }
            gpa = sum / ct;
            return gpa;
        }

        private Dictionary<string, int> getCoursesToUse()
        {
            Dictionary<string, int> uniqueCourses = new Dictionary<string, int>();
            foreach (Course course in courseList)
            {
                if (uniqueCourses.ContainsKey(course.courseName))
                {
                    int prev = uniqueCourses[course.courseName];
                    if(prev < course.gradePts)
                    {
                        uniqueCourses[course.courseName] = course.gradePts;
                    }
                    else
                    {
                        uniqueCourses[course.courseName] = course.gradePts;
                    }
                }
            }
            return uniqueCourses;
        }
    }
}