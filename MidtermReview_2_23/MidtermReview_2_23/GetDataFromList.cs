using System;
using ReviewMT;

namespace MidtermReview_2_23
{
	public class GetDataFromList : IStudentData
	{
        public List<Student> getStudentData()
        {
            List<Student> sList = new List<Student>();
            List<decimal> scores101 = new List<decimal>();
            scores101.Add(70.0m);
            scores101.Add(60.0m);
            scores101.Add(80.0m);
            sList.Add(new Student("101", scores101));
            List<decimal> scores102 = new List<decimal>();
            scores102.Add(40.0m);
            scores102.Add(55.0m);
            scores102.Add(75.0m);
            sList.Add(new Student("102", scores102));
            List<decimal> scores103 = new List<decimal>();
            scores103.Add(100.0m);
            scores103.Add(90.0m);
            scores103.Add(80.0m);
            sList.Add(new Student("103", scores103));
            return sList;
        }
    }
}