using System;

namespace AppSecurity.SecurityChecker
{
    public class SecurityChecker
    {
        private RegisterChecker _regChecker = new RegisterChecker();
        private ApiConsumer _apiConsumer = new ApiConsumer();

        public bool CanAppRun()
        {
            var macAddress = Helpers.GetMacAddress();
            var regValue = _regChecker.GetRegisterValue();

            if(regValue == string.Empty)
            {
                var serial = Guid.NewGuid().ToString();
                _regChecker.SetRegisterValue(serial);
                _apiConsumer.AddAppSerial(serial, macAddress);
                return true;
            }
            return _apiConsumer.VerifySerial(regValue);
        }
    }
}
