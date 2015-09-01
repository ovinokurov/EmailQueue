using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Img.EmailQueue.Core.Services;

namespace Img.EmailQueue.Server
{
    public class DequeueController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5 USE GET FOR TEST PURPOSE ONLY
        public string Get(string id)
        {

            var queueId = Guid.Parse(id);
            SmtpFactory.RemoveQueueMessage(queueId);

            return "value";
        }

        // POST api/<controller>
        public void Post(string qid)
        {
            var queueId = Guid.Parse(qid);
            SmtpFactory.RemoveQueueMessage(queueId);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}