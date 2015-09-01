using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Img.EmailQueue.Common;
using Img.EmailQueue.Core.Services.Model;
using SendGrid;
using Img.EmailQueue.Data.DataAccess;


namespace Img.EmailQueue.Core.Services
{
     public static class SmtpFactory
    {
         private static string SmtpLogin { get; set; }
         private static string SmtpPassword { get; set; }
         private static string SmtpServer { get; set; }

         static SmtpFactory() 
         {
             SmtpLogin = CommonFunctions.GetSetting(Constant.SmtpLogin);
             SmtpPassword = CommonFunctions.GetSetting(Constant.SmtpPassword);
             SmtpServer = CommonFunctions.GetSetting(Constant.SmtpServer);
         }



         public static void SendMessage(MailMessage message)
        {
            var smtpClientType = CommonFunctions.GetSetting(Constant.SmtpType);
             

           switch (smtpClientType)
            {
                case Constant.Internal:

                    SmtpClient smtpClient = new SmtpClient();
                    MailMessage mailMessage = (MailMessage) message;
                    smtpClient.Send(mailMessage);
                    break;

                case Constant.SendGrid:

                    EmailQueueMessage sendGridMessage = new EmailQueueMessage(message);
                    Task.Run(() => SendGridAsync(sendGridMessage));
                    break;
                default:
                    throw new NotImplementedException();
            }

        }

        static async Task SendGridAsync(SendGridMessage message)
        {
            var credentials = new NetworkCredential(SmtpLogin, SmtpPassword);
            var transportWeb = new Web(credentials);
           
            try
            {
                await transportWeb.DeliverAsync(message);
            }
            catch (Exception ex)
            {

            }
        }

         public static void SendSmtp(MailMessage mailMsg)
         {
             try
             {
                 var smtpClient = new SmtpClient(SmtpServer, Convert.ToInt32(587));
                 var credentials = new NetworkCredential(SmtpLogin,SmtpPassword);

                 smtpClient.Credentials = credentials;
                 smtpClient.Send(mailMsg);
             }
             catch (Exception ex)
             {
               
             }
         }

         public static Guid InsertQueueMessage(MailMessage queueMessage)
         {
             DatabaseFunctions dbFunctions = new DatabaseFunctions();
   
             return dbFunctions.InsertQueue(queueMessage);
         }

         public static MailMessage GetQueueMessage(Guid id)
         {
             DatabaseFunctions dbFunctions = new DatabaseFunctions();
             var mailMessage = dbFunctions.GetQueueMessage(id);

             return mailMessage;
         }


         public static MailMessage GetMessage(Guid id)
         {
             DatabaseFunctions dbFunctions = new DatabaseFunctions();
             var mailMessage = dbFunctions.GetMessage(id);

             return mailMessage;
         }

         public static List<Guid> GetAllMessageIds()
         {
             DatabaseFunctions dbFunctions = new DatabaseFunctions();
             List<Guid> messageId = dbFunctions.GetAllMessageIds();
             return messageId;
         }
         public static Guid GetApiKey(int id)
         {
             DatabaseFunctions dbFunctions = new DatabaseFunctions();
             Guid apiKey = dbFunctions.GetApiKey(id);
             return apiKey;
         }

         public static void RemoveQueueMessage(Guid id)
         {
             DatabaseFunctions dbFunctions = new DatabaseFunctions();
    
             dbFunctions.ArchieveQueue(id);
         }
    }
}
