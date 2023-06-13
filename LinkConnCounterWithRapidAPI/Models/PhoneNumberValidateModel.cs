namespace LinkConnCounterWithRapidAPI.Models
{
    public class PhoneNumberValidateModel
    {
        public string phoneNumberEntered { get; set; }
        public string defaultCountryEntered { get; set; }
        public string languageEntered { get; set; }
        public string countryCode { get; set; }
        public string nationalNumber { get; set; }
        public string extension { get; set; }
        public string countryCodeSource { get; set; }
        public bool italianLeadingZero { get; set; }
        public string rawInput { get; set; }
        public bool isPossibleNumber { get; set; }
        public bool isValidNumber { get; set; }
        public bool isValidNumberForRegion { get; set; }
        public string phoneNumberRegion { get; set; }
        public string numberType { get; set; }
        public string E164Format { get; set; }
        public string originalFormat { get; set; }
        public string nationalFormat { get; set; }
        public string internationalFormat { get; set; }
        public string outOfCountryFormatFromUS { get; set; }
        public string outOfCountryFormatFromCH { get; set; }
        public string location { get; set; }
        public string timeZone_s { get; set; }
        public string carrier { get; set; }
    }
}
