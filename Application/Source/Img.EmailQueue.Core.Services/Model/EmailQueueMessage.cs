using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.SmtpApi;

namespace Img.EmailQueue.Core.Services.Model
{
   public class EmailQueueMessage:SendGridMessage
    {

       public EmailQueueMessage(MailMessage message)
       {
           From = message.From;
           To = message.To.ToArray();
           Subject = message.Subject;

           if (message.IsBodyHtml)
               Html = message.Body;
           else
               Text = message.Body;
          
           Dictionary<string,string> uniqueArgs = new Dictionary<string, string>();
           foreach (string key in message.Headers.AllKeys)
           {
               uniqueArgs.Add(key,message.Headers[key]);
           }
           this.AddUniqueArgs(uniqueArgs);

       }
    }
}
