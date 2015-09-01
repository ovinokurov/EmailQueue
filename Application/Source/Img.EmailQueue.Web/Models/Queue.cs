using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Img.EmailQueue.Web.Models
{
    public class Queue
    {
        public Int64 Id { get; set; }
        public Int64 OrganizationId { get; set; }
        public string Send { get; set; }
    }
}