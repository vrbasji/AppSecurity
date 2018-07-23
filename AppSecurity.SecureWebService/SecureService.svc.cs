using AppSecurity.Models;
using AppSecurity.SecureWebService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AppSecurity.SecureWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SecureService : ISecureService
    {
        private VerifyService _verifyService = new VerifyService();
        public bool AddAppSerial(string verificationCode, string idApp)
        {
            var appSerial = new AppSerial()
            {
                CanRun = false,
                VerificationCode = verificationCode,
                IdApp = idApp,
                CreateTime = DateTime.Now,
                LastCheck = DateTime.Now
            };
            return _verifyService.AddSerial(appSerial);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public bool VerifySerial(string verificationCode)
        {
            return _verifyService.VerifySerial(verificationCode);
        }
    }
}
