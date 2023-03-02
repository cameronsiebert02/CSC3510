namespace MidtermReview_2_23;

public class TaxChecker{
    private List<TaxForm> _taxForms;

    public TaxChecker( IGetData getData ){
        _taxForms = getData.getTaxForms();
    }
    public decimal  processTaxForms(){
        // Method that goes through a batch of taxForms and 
        //  returns the total amount of tax due
        decimal  tDue = 0;
        foreach ( TaxForm tf in _taxForms){
            tDue += getTaxOwed(tf);
        }
        return tDue;
    }
    public decimal getTaxOwed(TaxForm tf){
        // ToDo:Test this method based on the following rules:
        //  ToDo:         R1 - if netIncome < 50,000 taxOwed is 10% of netIncome
        //  ToDo:         R2 - if netIncome is 50,000 - 100,000 (inclusive)
        //  ToDo:                taxOwed is 15% of netIncome
        //  ToDo:        R3 - if netIncome is > 100,000 taxOwed is 20% of netIncome
        //  ToDo:        R4 - Tax owed must be >= 0
        decimal tax = .10m;
        if (tf.grossIncome >= 50_000 && tf.grossIncome < 100_000 ){
            tax = .15m;
        } else if (tf.grossIncome > 100_000){
            tax = .20m;
        }
        decimal totalTaxOwed = tf.grossIncome * tax;
        return totalTaxOwed;
    }
}