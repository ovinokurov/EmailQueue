using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Img.EmailQueue.Common;
using Img.EmailQueue.Data.Entities;

namespace Img.EmailQueue.Data.DataAccess
{
    public class DatabaseFunctions
    {
        public Guid InsertQueue(MailMessage queueMessage)  
        {
            Message message = new Message();
            Email email = new Email();
            QueueMaster queue = new QueueMaster();
            Status status = new Status();

            using (var queueConnection =  new EmailQueueConnections())
            {
               
                //
                message.Emails = message.Emails;
                message.Subject = queueMessage.Subject;
                message.Body = queueMessage.Body;
                message.IsBodyHtml = queueMessage.IsBodyHtml;



                queueConnection.Messages.Add(message);
                queueConnection.SaveChanges();

                email.EmailAddress = queueMessage.From.Address;
                email.MessageId = message.Id;
                email.IsSender = true;
                email.IsReciever = false;

                queueConnection.Emails.Add(email);
                queueConnection.SaveChanges();

                foreach (var toEmail in queueMessage.To)
                {
                    email.MessageId = message.Id;
                    email.EmailAddress = toEmail.Address;
                    email.IsSender = false;
                    email.IsReciever = true;

                    queueConnection.Emails.Add(email);
                    
                }
                queueConnection.SaveChanges();
                
                queue.OrganizationId = Convert.ToInt32(CommonFunctions.GetSmtpHeaders(queueMessage)[Constant.OrganizationId]);
                queue.Id = Guid.NewGuid();
                queue.MessageId = message.Id;
                queue.StatusId = 1; 
                //queue.StatusId = status.Id; 
                //queue.Status = "InProcess";
                queueConnection.QueueMasters.Add(queue);
                queueConnection.SaveChanges();

            }
            return queue.Id;
        }

        public Guid GetApiKey(int id)
        {
            using (var db = new EmailQueueConnections())
            {
                return db.ApiKeys.FirstOrDefault(a => a.OrganizationId == id).ApiKey1;
            }
        }

        public MailMessage GetQueueMessage(Guid queueId)
        {
            using (var db = new EmailQueueConnections())
            {
                
                var queue = db.QueueMasters.Join(db.Messages, q => q.MessageId, m => m.Id,
                    (q, m) => new { q.Id, q.MessageId, m.Emails, q.Message }).Where(m => m.Id == queueId).ToList();

                var messageId = queue.First().MessageId;
                var attachments = db.Attachments.Where(a => a.MessageId == messageId).ToList();
                var emailFromAddress = db.Emails.Where(e => e.MessageId == messageId && e.IsSender == true).Select(y => y.EmailAddress).First();
                var emailToAddress = db.Emails.Where(e => e.MessageId == messageId && e.IsSender == false).Select(y => y.EmailAddress).First();             
                var subject = queue.First().Message.Subject;
                var body = queue.First().Message.Body;
                
                
                MailAddress emailAddressFrom = new MailAddress(emailFromAddress);
                MailAddress emailAddressTo = new MailAddress(emailToAddress);
                MailMessage mailMessage = new MailMessage(emailAddressFrom, emailAddressTo);

                mailMessage.Headers.Add(Constant.QueueId,queueId.ToString());
                mailMessage.Subject = subject;
                mailMessage.Body = body;


                ArchieveQueue(queueId);

                return mailMessage;
            }
        }

        public void ArchieveQueue(Guid queueId)
        {
            using (var db = new EmailQueueConnections())
            {
                var queueMaster = db.QueueMasters.Single(m => m.Id == queueId);
                QueueArchive queueArchive = new QueueArchive();
                queueArchive.QueueId = queueMaster.Id;
                queueArchive.OrganizationId = queueMaster.OrganizationId;
                queueArchive.QueueOrder = queueMaster.QueuedOrder;
                queueArchive.QueuedDate = queueMaster.QueuedDate;
                queueArchive.ProcessedDate = queueMaster.ProcessedDate;
                queueArchive.Attempts = queueMaster.Attempts;
                queueArchive.Retry = queueMaster.Retry;
                queueArchive.MessageId = queueMaster.MessageId;
                queueArchive.Status = queueMaster.Status;

                db.QueueArchives.Add(queueArchive);
                db.SaveChanges();

                db.QueueMasters.Remove(queueMaster);
                db.SaveChanges();
            }

        }


        public List<Guid> GetAllMessageIds()
        {
                using (var db = new EmailQueueConnections())
                {

                    return db.QueueMasters
                        /*.Where(pd => pd.ProcessedDate==null)*/
                        .Where(pd => pd.StatusId == 1)
                        .Select(i => i.Id)
                        .ToList();
                }
        } 

        public MailMessage GetMessage(Guid queueId)
        {
            using (var db = new EmailQueueConnections())
            {

                var queue = db.QueueMasters.Join(db.Messages, q => q.MessageId, m => m.Id,
                    (q, m) => new { q.Id, q.MessageId, m.Emails, q.Message }).Where(m => m.Id == queueId).ToList();

                var messageId = queue.First().MessageId;
                var attachments = db.Attachments.Where(a => a.MessageId == messageId).ToList();
                var emailFromAddress = db.Emails.Where(e => e.MessageId == messageId && e.IsSender == true).Select(y => y.EmailAddress).First();
                var emailToAddress = db.Emails.Where(e => e.MessageId == messageId && e.IsSender == false).Select(y => y.EmailAddress).First();
                var subject = queue.First().Message.Subject;
                var body = queue.First().Message.Body;


                MailAddress emailAddressFrom = new MailAddress(emailFromAddress);
                MailAddress emailAddressTo = new MailAddress(emailToAddress);
                MailMessage mailMessage = new MailMessage(emailAddressFrom, emailAddressTo);

                mailMessage.Headers.Add(Constant.QueueId, queueId.ToString());
                mailMessage.Subject = subject;
                mailMessage.Body = body;

                return mailMessage;
            }
        }
    }
}
