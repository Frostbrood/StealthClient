using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace StealthClient
{
    class Session
    {
        public static string GUID;
        public static List<string> sesBlockedUrls = new List<string>();
        public static List<string> sesAllowedUrls = new List<string>();

        static string GetGUID()
        {
            RegistryKey GUIDKey = Registry.CurrentUser.CreateSubKey("Stealth Client");
            GUID = (string)GUIDKey.GetValue("GUID");
            if (GUID == null)
            {
                GUID = Guid.NewGuid().ToString();
                GUIDKey.SetValue("GUID", GUID);
            }

            return GUID;
        }

        public static bool AuthenticateUser(string sUser, string sPass)
        {
            GetGUID();

            // TODO

            return true;
        }

        public static bool GetSession(string session)
        {
            // TODO

            return true;
        }
    }
}
