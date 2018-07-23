using System.Configuration;

namespace AppSecurity.SecurityChecker
{
    public class ApiConsumer
    {
        private string _apiUrl;
        private const string verifySerial = "/VerifySerial?code={0}";
        private const string addSerial = "/AddSerial?code={0}&app={1}";
        public ApiConsumer()
        {
            _apiUrl = ConfigurationManager.AppSettings["api_url"];
        }
        public bool VerifySerial(string serial)
        {
            var verified = false;
            var fullURL = _apiUrl + string.Format(verifySerial,serial);

            var result = Helpers.MakeRequest(fullURL);
            verified = Helpers.ParseXml(result);
            return verified;
        }
        public bool AddAppSerial(string serial, string computerId)
        {
            var added = false;
            var fullURL = _apiUrl + string.Format(addSerial, serial,computerId);

            var result = Helpers.MakeRequest(fullURL);
            added = Helpers.ParseXml(result);

            return added;
        }
    }
}
