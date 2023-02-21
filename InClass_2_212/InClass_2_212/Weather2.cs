using DependInjection;

namespace InClass_2_21;

public class Weather2
{
    public List<HiPerMonth> HiPerMonth { get; set; }

    public IWeatherData weatherData
    {
        set
        {
            this.weatherData = value;
        }
        get
        {
            return weatherData;
        }
    }

    public Weather2(IWeatherData weatherData)
    {
        this.weatherData = weatherData;
        HiPerMonth = weatherData.GetWaetherData();
    }
    
    public double getSummerHiAver(){
        double aver = 0.0;
        var ct = 0;
        double sum = 0.0;
        foreach (var row in HiPerMonths){
            sum += row.Jun + row.Jul + row.Aug;
            ct += 3;
        }

        aver = sum / ct;
        return aver;
    }
}