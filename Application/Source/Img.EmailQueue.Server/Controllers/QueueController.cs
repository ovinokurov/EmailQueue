using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using Img.EmailQueue.Common;
using Img.EmailQueue.Core.Services;
using Microsoft.AspNet.Identity;


namespace Img.EmailQueue.Server.Controllers
{
    public class QueueController : ApiController
    {
        // GET: api/Queue
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Queue/5 USE GET FOR TESTING ONLY
        //this is going to be post
        
        //7
        //851255a1-213c-4299-a50b-57a06f4a2ed0
        
        // http://localhost:62902/api/queue/
        //[System.Web.Http.HttpPost]
        public string Get(int id, string apiKey)
        
        {
            if (apiKey == SmtpFactory.GetApiKey(id).ToString())
            {
                var mailFrom = new MailAddress("ovinokurov@wmeentertainment.com");
                var mailTo = new MailAddress("olegvinokurov@hotmail.com");
                var mailMessage = new MailMessage(mailFrom, mailTo);


                mailMessage.Body = "Testing body message";
                mailMessage.Subject = "Another Test";

                //C:\files/file.jpg

                ////upload files here////


                mailMessage.Headers.Add(Constant.OrganizationId, id.ToString());

                var queueId = SmtpFactory.InsertQueueMessage(mailMessage);
                mailMessage.Headers.Add(Constant.QueueId, queueId.ToString());

                //STOP 

                //ADD new service to send OR Create function to look use QueueId
                //EmailService
                //SmtpFactory.SendMessage(mailMessage);
                
                return "";
            }
            return "Wrong ApiKey";
        }

        // POST: api/Queue
        public string Post(MailMessage mailMessage)
        {
            var queueId = SmtpFactory.InsertQueueMessage(mailMessage);
            mailMessage.Headers.Add(Constant.QueueId, queueId.ToString());
           
            SmtpFactory.SendMessage(mailMessage);

            return queueId.ToString();
        }

        // PUT: api/Queue/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Queue/5
        public void Delete(int id)
        {
        }
    }
}