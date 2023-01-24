internal class CalorieBurner
{
    public string inFile; // The input file path and name
    public string[] rows = new string[0]; // These are the raw rows from file
    List<Excercise> excerData = new List<Excercise>(); // THese are Raw Rows converted into Exercise
    public CalorieBurner(string inFile)
    {
        this.inFile = inFile;
    }
    public void getRowsFromFile()
    {
        // ToDo: Get all input data and set rows;
        // Sets the rows variable

    }
    public void SetExerciseRecords()
    {
        //ToDo: Convert this.rows into this.exerData rows
        List<Excercise> eData = new List<Excercise>();
        this.excerData = eData;

    }
    public decimal getWalkingCalories(DateTime inDate)
    {
        // ToDo: Return the total calories walking for input date
        //  Use these speeds to calculate calories:
        //      Calories Per Mile Speed
        //      a. 100       2.5 or more,
        //      b. 125         3 or more,
        //      c.  90        less than 2.5
        // Returns: the total calories burned for that day for walking
        decimal cals = 0.0m;
        return cals;
    }
    public decimal getBikingCalories(DateTime dateTime)
    {
        // ToDo: Return the total calories walking for input date
        //  Use these speeds to calculate calories:
        //  Speed              Calories Per Mile
        //  Light < 10 MPH      30 
        //  Moderate 10-13.9    45 
        //  Vigorous 14-19.9  55 Calories Per Mile
        // Racing >=20 65.4 - Calories Per Mile
        decimal cals = 0.0m;
        return cals;
    }
}
