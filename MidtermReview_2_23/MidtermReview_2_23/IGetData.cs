namespace MidtermReview_2_23;

public interface IGetData{
    List<TaxForm> getTaxForms();
}

public class getTaxDataFromDB : IGetData{
    public List<TaxForm> getTaxForms(){
        // This method would get data from the database. For our midterm 
        //   purposes only, it hard-codes loading data into an arrayList
        List<TaxForm> tForm= new List<TaxForm>();
        tForm.Add( new TaxForm("222334442", 10_000));
        tForm.Add( new TaxForm("112331234", 54_000));
        tForm.Add( new TaxForm("222331211", 10_0000));
        tForm.Add( new TaxForm("123456789", 13_000));
        tForm.Add( new TaxForm("123456777", 12_550));
        tForm.Add( new TaxForm("123456772", 100_500 ));
        tForm.Add( new TaxForm("123456773", 120_000));
        tForm.Add( new TaxForm("123456774",  140_000));
        tForm.Add( new TaxForm("123456785",  10_000));
        tForm.Add( new TaxForm("123456786",  40_000));
        tForm.Add( new TaxForm("123456789",  122_000));

        return tForm;
    }
}