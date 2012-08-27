using Microsoft.Win32;
using System;
using System.Collections.Generic;

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

            return (string)GUIDKey.GetValue("GUID"); // Null if not available
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
