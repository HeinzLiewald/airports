namespace Service.Models {
    public class Airport {
        public const string TYPE_AIRPORT = "airport";
        public const string CONTINENT_EU = "EU";

        public string Iata { get; set; }
        public string Lon { get; set; }
        public string Iso { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Type { get; set; }
        public string Lat { get; set; }
        public string Size { get; set; }
    }
}
