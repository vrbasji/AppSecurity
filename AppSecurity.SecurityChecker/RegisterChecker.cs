using Microsoft.Win32;
using System;

namespace AppSecurity.SecurityChecker
{
    public class RegisterChecker
    {
        private const string APP_NAME = "Windows1100";
        private const string KEY = "Verification_code";
        public string GetRegisterValue()
        {
            using (var key = Registry.LocalMachine.OpenSubKey("Software\\" + APP_NAME))
            {
                if (key != null)
                {
                    Object o = key.GetValue(KEY);
                    if (o != null)
                    {
                        return o as string;
                    }
                }
            }

            return string.Empty;
        }
        public void SetRegisterValue(string verCode)
        {
            var subKey = Registry.LocalMachine.OpenSubKey("Software\\" + APP_NAME, true);

            if(subKey == null)
            {
                subKey = CreateSubKey();
            }
            subKey.SetValue(KEY, verCode);
        }
        private RegistryKey CreateSubKey()
        {
            var subKey = Registry.LocalMachine.OpenSubKey("Software", true);
            return subKey.CreateSubKey(APP_NAME, true);
        }
    }
}
