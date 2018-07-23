using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Xml;

namespace AppSecurity.SecurityChecker
{
    public class Helpers
    {
        public static string GetMacAddress()
        {
            string macAddresses = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;
        }
        public static bool ParseXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return bool.Parse(doc.InnerText);
        }
        public static string MakeRequest(string url)
        {
            var responseResult = string.Empty;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                responseResult = reader.ReadToEnd();
            }
            return responseResult;
        }
    }
}
