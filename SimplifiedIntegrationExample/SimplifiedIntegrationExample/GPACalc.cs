using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedIntegrationExample {
    public class GPACalc : IGPACalc {
        List<Course> courseList = new List<Course>();

        public GPACalc( String SId, IDatabase IDb  ) {
            this.courseList = IDb.GetCourses(SId);
        }
        public double getGPA() {
            double gpa = 0.0;
            int sum = 0;
            int ct = 0;
            Dictionary<string, int > uniqCourse = getCoursesToUse();
            foreach (string course  in uniqCourse.Keys) {
                sum += uniqCourse[course];
                ct += 1;
            }
            if(ct == 0)
            {
                gpa = 0;
            }
            else
            {
                gpa = sum / ct;
            }
            return gpa;
        }

        private Dictionary<string, int> getCoursesToUse() {
            Dictionary<string, int> uniqCourse = new Dictionary<string, int>();
            foreach (Course course in courseList) {
                if ( uniqCourse.ContainsKey( course.courseName)) {
                    int prev = uniqCourse[course.courseName];
                    if ( prev < course.gradePts ) {
                        uniqCourse[course.courseName] = course.gradePts;
                    }
                } else {
                    uniqCourse[course.courseName] = course.gradePts;
                }
            }
            return uniqCourse;
        }
    }
}
