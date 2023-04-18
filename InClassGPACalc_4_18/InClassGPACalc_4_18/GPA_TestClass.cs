using System;
namespace InClassGPACalc_4_18
{
    public class GPA_TestClass : IGPACalc
    {
        List<Course> courses = new List<Course>();

        public GPA_TestClass(List<Course> coursess)
        {
            this.courses = courses;
        }

        public double getGPA()
        {
            return 3.5;
        }
    }
}