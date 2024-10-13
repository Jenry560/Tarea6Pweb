namespace Tarea6Pweb.Models
{
     public partial class Clima
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
        public Forecast Forecast { get; set; }
        public Alerts Alerts { get; set; }
    }

    public partial class Alerts
    {
        public List<Alert> Alert { get; set; }
    }

    public partial class Alert
    {
        public string Headline { get; set; }
        public object Msgtype { get; set; }
        public object Severity { get; set; }
        public object Urgency { get; set; }
        public object Areas { get; set; }
        public string Category { get; set; }
        public object Certainty { get; set; }
        public string Event { get; set; }
        public object Note { get; set; }
        public DateTimeOffset Effective { get; set; }
        public DateTimeOffset Expires { get; set; }
        public string Desc { get; set; }
        public string Instruction { get; set; }
    }

    public partial class Current
    {
        public long LastUpdatedEpoch { get; set; }
        public string LastUpdated { get; set; }
        public double TempC { get; set; }
        public double TempF { get; set; }
        public long IsDay { get; set; }
        public Condition Condition { get; set; }
        public double WindMph { get; set; }
        public double WindKph { get; set; }
        public long WindDegree { get; set; }
        public string WindDir { get; set; }
        public long PressureMb { get; set; }
        public double PressureIn { get; set; }
        public long PrecipMm { get; set; }
        public long PrecipIn { get; set; }
        public long Humidity { get; set; }
        public long Cloud { get; set; }
        public long FeelslikeC { get; set; }
        public double FeelslikeF { get; set; }
        public long VisKm { get; set; }
        public long VisMiles { get; set; }
        public long Uv { get; set; }
        public double GustMph { get; set; }
        public double GustKph { get; set; }
        public Dictionary<string, double> AirQuality { get; set; }
    }

    public partial class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public long Code { get; set; }
    }

    public partial class Forecast
    {
        public List<Forecastday> Forecastday { get; set; }
    }

    public partial class Forecastday
    {
        public DateTimeOffset Date { get; set; }
        public long DateEpoch { get; set; }
        public Day Day { get; set; }
        public Astro Astro { get; set; }
        public List<Hour> Hour { get; set; }
    }

    public partial class Astro
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Moonrise { get; set; }
        public string Moonset { get; set; }
        public string MoonPhase { get; set; }
        public long MoonIllumination { get; set; }
    }

    public partial class Day
    {
        public double MaxtempC { get; set; }
        public double MaxtempF { get; set; }
        public double MintempC { get; set; }
        public double MintempF { get; set; }
        public double AvgtempC { get; set; }
        public double AvgtempF { get; set; }
        public double MaxwindMph { get; set; }
        public double MaxwindKph { get; set; }
        public long TotalprecipMm { get; set; }
        public long TotalprecipIn { get; set; }
        public long AvgvisKm { get; set; }
        public long AvgvisMiles { get; set; }
        public long Avghumidity { get; set; }
        public long DailyWillItRain { get; set; }
        public long DailyChanceOfRain { get; set; }
        public long DailyWillItSnow { get; set; }
        public long DailyChanceOfSnow { get; set; }
        public Condition Condition { get; set; }
        public long Uv { get; set; }
    }

    public partial class Hour
    {
        public long TimeEpoch { get; set; }
        public string Time { get; set; }
        public double TempC { get; set; }
        public double TempF { get; set; }
        public long IsDay { get; set; }
        public Condition Condition { get; set; }
        public double WindMph { get; set; }
        public double WindKph { get; set; }
        public long WindDegree { get; set; }
        public string WindDir { get; set; }
        public long PressureMb { get; set; }
        public double PressureIn { get; set; }
        public long PrecipMm { get; set; }
        public long PrecipIn { get; set; }
        public long Humidity { get; set; }
        public long Cloud { get; set; }
        public double FeelslikeC { get; set; }
        public double FeelslikeF { get; set; }
        public double WindchillC { get; set; }
        public double WindchillF { get; set; }
        public double HeatindexC { get; set; }
        public double HeatindexF { get; set; }
        public double DewpointC { get; set; }
        public double DewpointF { get; set; }
        public long WillItRain { get; set; }
        public long ChanceOfRain { get; set; }
        public long WillItSnow { get; set; }
        public long ChanceOfSnow { get; set; }
        public long VisKm { get; set; }
        public long VisMiles { get; set; }
        public long GustMph { get; set; }
        public double GustKph { get; set; }
        public long Uv { get; set; }
    }

    public partial class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string TzId { get; set; }
        public long LocaltimeEpoch { get; set; }
        public string Localtime { get; set; }
    }
}
