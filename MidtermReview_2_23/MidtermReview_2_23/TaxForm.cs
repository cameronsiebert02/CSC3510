using Microsoft.VisualBasic.CompilerServices;

namespace MidtermReview_2_23;

public class TaxForm{
    public string SSNumber{ get; set; }
    public  decimal grossIncome { get; set; }

    public TaxForm(string ssNumber, decimal grossIncome){
        SSNumber = ssNumber;

        this.grossIncome = grossIncome;
    }
    public bool validSSN( ){
        //ValidSSN: 
        //  Returns true if valid set of 9 digits. 
        //    SSNumber can have or not have dashes 
        //    E.g., 121-11-2121 or 121112121
        //  returns false if not valid set of 9 digits. 
        // E.g., Input: 1234567890 => returns true
        //       Input: 123456789 => returns false;
        //       Input: 123-33-2323 => Returns true
        string testSSN = SSNumber;
        if (SSNumber.Length > 9) return false;
        else if (SSNumber[0] == '6' && SSNumber[1] == '6' && SSNumber[2] == '6'){
            return false;
        } else{
            for (int i = 0; i < SSNumber.Length - 1; i++){
                if (SSNumber[i] == '0'){
                    return false;
                }
                try{
                    int d = Int32.Parse(testSSN);
                    return true;
                }
                catch{
                    return false;
                }
            }
            return true;
        }
    }
}