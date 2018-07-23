using AppSecurity.Database;
using AppSecurity.Models;
using System;
using System.Configuration;

namespace AppSecurity.SecureWebService.Services
{
    public class VerifyService
    {
        private DatabaseContext _dbContext;
        public VerifyService()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["appSecurityConStr"].ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString", "Connection string is not setup");
            }
            _dbContext = new DatabaseContext(connectionString);
        }

        public bool VerifySerial(string serial)
        {
            return _dbContext.VerifySerial(serial);
        }
        public bool AddSerial(AppSerial appSerial)
        {
            return _dbContext.AddSerial(appSerial);
        }
    }
}