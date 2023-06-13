namespace LinkConnCounterWithRapidAPI.Models
{

    public class WeatherModel
    {
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public float temp { get; set; }
    }

}
