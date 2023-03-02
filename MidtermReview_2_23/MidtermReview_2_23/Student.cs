namespace ReviewMT;

public class Student{
    public string first;
    public List<decimal> HWScores;
    
    public Student(string first, List<decimal> hwScores ){
        this.first = first;
        HWScores = hwScores;
    }
}