namespace DependInjection;

public class HiPerMonth {
    public int Year { get; set; }
    public int Jan { get; set; }
    public int Feb { get; set; }
    public int Mar{  get; set; }
    public int Apr { get; set; }
    public int May { get; set; }
    public int Jun { get; set; }
    public int Jul { get; set; }
    public int Aug { get; set; }
    public int Sep { get; set; }
    public int Oct { get; set; }
    public int Nov { get; set; }
    public int Dec { get; set; }
    public HiPerMonth(int jan, int feb, int mar, int apr, int may, int jun, int jul, int aug, int sep, int oct, int nov, int dec, int year)  {
        Jan = jan;
        Feb = feb;
        Mar = mar;
        Apr = apr;
        May = may;
        Jun = jun;
        Jul = jul;
        Aug = aug;
        Sep = sep;
        Oct = oct;
        Nov = nov;
        Dec = dec;
        Year = year;
    }

    public override string ToString() {
        string res = String.Format("year:{0} Jan:{1} Feb:{2} Mar{3} Apr:{4} Mal:{5} Jun:{6}", Year, Jan, Feb, Mar, Apr,
            May, Jun);
        res += String.Format("Jul:{0} Aug:{1} Sep:{2} Oct:{3} Nov:{4} Dev:{5} ", Jul, Aug, Sep, Oct, Nov,
            Dec);
        return res;
    }
}