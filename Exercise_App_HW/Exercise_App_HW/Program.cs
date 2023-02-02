using System;
using static System.Net.Mime.MediaTypeNames;
using Exercise_App_HW;
namespace Exercise_App_HW;
public class CalorieBurner
{
    public string inFile; // The input file path and name
    public string[] rows = new string[0]; // These are the raw rows from file
    public List<Exercise> exerData = new List<Exercise>(); // THese are Raw Rows converted into Exercise
    public CalorieBurner(string inFile)
    {
        this.inFile = inFile;
    }
    public void getRowsFromFile()
    {
        // ToDo: Get all input data and set rows;
        // Sets the rows variable
        string[] rows = new string[0];
        try
        {
            rows = File.ReadAllLines(inFile);
            this.rows = rows;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error on file open!");
            throw new FileNotFoundException("Error on file open!");
        }
    }
    public void SetExerciseRecords()
    {
        //ToDo: Convert this.rows into this.exerData rows
        List<Exercise> eData = new List<Exercise>();
        bool firstLine = true;
        for (int i = 1; i < rows.Length; i++)
        {
                string[] toks = rows[i].Split(',');
                DateTime date;
                string exerType;
                decimal time;
                decimal speed;
                try
                {
                    date = DateTime.Parse(toks[0]);
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Date is not entered correctly in the data");
                }
                try
                {
                    exerType = toks[1];
                }catch(Exception e)
                {
                    throw new ArgumentException("Exercise type is not entered correctly in the date");
                }
                try
                {
                    time = decimal.Parse(toks[2]);
                }catch(Exception e)
                {
                    throw new ArgumentException("Time is not entered correctly in the data");
                }
                try
                {
                    speed = decimal.Parse(toks[3]);
                }catch(Exception e)
                {
                    throw new ArgumentException("Speed is not entered correctly in the data");
                }
                eData.Add(new Exercise(date, exerType, time, speed));
        }
        this.exerData = eData;
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
        foreach(Exercise exercise in exerData)
        {
            if(exercise.dt == inDate)
            {
                if (exercise.exType.Equals("Walking"))
                {
                    if (exercise.speed >= 3)
                    {
                        cals += 125 * (exercise.time / 60);
                    }
                    else if (Decimal.ToDouble(exercise.speed) >= 2.5)
                    {
                        cals += 100 * (exercise.time / 60);
                    }
                    else
                    {
                        cals += 90 * (exercise.time / 60);
                    }
                }
            }
        }
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
        foreach(Exercise exercise in exerData)
        {
            if(exercise.dt == dateTime)
            {
                if (exercise.exType.Equals("Biking"))
                {
                    if(exercise.speed >= 20)
                    {
                        cals += 65.4m * (exercise.time / 60);
                    }
                    else if (exercise.speed >= 14)
                    {
                        cals += 55 * (exercise.time / 60);
                    }
                    else if(exercise.speed >= 10)
                    {
                        cals += 45 * (exercise.time / 60);
                    }
                    else
                    {
                        cals += 30 * (exercise.time / 60);
                    }
                }
            }
        }
        return cals;
    }
}