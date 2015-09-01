using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Img.EmailQueue.Web.Models;
using Img.EmailQueue.Data.Entities;


namespace Img.EmailQueue.Web.Controllers
{
    public class QueueController : Controller
    {
        public ActionResult Index()
        {
            var queues = new List<QueueMaster>();


            using (var queueConnection = new EmailQueueConnections())
            {
                queues = queueConnection.QueueMasters.ToList();
            }

            return View(queues);
        }


    }
}
