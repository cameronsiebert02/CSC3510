using MidtermReview_2_23;

namespace ReviewMT;

public class ClassGrader{
    private List<Student> students = null;
    // 0. Practice TDD for this exercise. What are the steps?
    // 1.Write code to get students. DId you already create the test class? 
    // 2. Implement getAverage
    // 2.b Create the equivalence partition for this class
    //   c Create a boundary valuation
    //   d. List test cases and why you selected them
    //  2.c Create test 2 test cases for this data
    // 3. Rewrite the getStudents() method to inject an interface into the 
    //    getStudents method:
    //    E.g., 
    //       private List<Student> getStudents( IGetStudentData getData ).
    // 4. Write test cases to test this data.
    public ClassGrader(GetDataFromList studentData){
        this.students = getStudents(studentData);
    }

    public decimal getOverallAverage(){
        decimal retVal = 0.0m;
        int count = 0;
        // get the overall average for these students
        foreach (Student student in students)
        {
            foreach(decimal score in student.HWScores)
            {
                retVal += score;
                count++;
            }
        }
        return retVal/count;
    }

    public decimal getStudentAverage( string studentID){
        // For a given student ID return their average
        // if overall grade is > 100 set it to 100
        // If overall grade is < 0 set it to 0
        decimal aver = 0.0m;
        int count = 0;
        foreach(Student student in students)
        {
            if (student.first.Equals(studentID))
            {
                foreach(decimal score in student.HWScores)
                {
                    aver += score;
                }
            }
        }
        return aver/count;
    }
    private List<Student> getStudents(IStudentData studentData){
        // Generate this list of students 
        // 101 -> 
        //    HWScores = 70, 60, 80;
        // 102 -> 
        //    HWScores = 40, 55, 75;
        // 103 -> 
        //    HWScores = 100, 90, 80;
        return studentData.getStudentData();
    }
}