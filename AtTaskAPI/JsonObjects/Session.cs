namespace AtTaskAPI.JsonObjects
{
    public class Rootobject
    {
        public Datum data { get; set; }
    }

    public class Datum
    {
        public string userID { get; set; }
        public string sessionID { get; set; }
        public Versioninformation versionInformation { get; set; }
        public string locale { get; set; }
        public string timeZone { get; set; }
        public string timeZoneName { get; set; }
        public string iso3Country { get; set; }
        public string iso3Language { get; set; }
        public Currency currency { get; set; }
    }

    public class Versioninformation
    {
        public string currentAPI { get; set; }
        public string buildNumber { get; set; }
        public Apiversions apiVersions { get; set; }
        public string lastUpdated { get; set; }
        public string release { get; set; }
        public string version { get; set; }
    }

    public class Apiversions
    {
        public string v10 { get; set; }
        public string v20 { get; set; }
        public string v30 { get; set; }
    }

    public class Currency
    {
        public bool useNegativeSign { get; set; }
        public int fractionDigits { get; set; }
        public string symbol { get; set; }
        public string ID { get; set; }
        public string groupingSeparator { get; set; }
        public string decimalSeparator { get; set; }
    }
}
