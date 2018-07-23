using System;

namespace AppSecurity.Models
{
    public class AppSerial
    {
        public int IdAppSerial { get; set; }
        public string VerificationCode { get; set; }
        public string IdApp { get; set; }
        public string Note { get; set; }
        public bool CanRun { get; set; }
        public DateTime LastCheck { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
