using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Mail;

namespace Img.EmailQueue.Common
{
    public static class CommonFunctions
    {

        public static string GetSetting(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName.ToUpper()];
        }


        public static Dictionary<string, string> GetSmtpHeaders(MailMessage message)
        {
            Dictionary<string,string> headersDictionary = new Dictionary<string, string>();
            foreach (string key in message.Headers.AllKeys)
            {
                headersDictionary.Add(key,message.Headers[key]);
            }
            return headersDictionary;
        }
    }
}
