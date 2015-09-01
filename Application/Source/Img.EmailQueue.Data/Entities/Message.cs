//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Img.EmailQueue.Data.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public Message()
        {
            this.Attachments = new HashSet<Attachment>();
            this.Emails = new HashSet<Email>();
            this.QueueArchives = new HashSet<QueueArchive>();
            this.QueueMasters = new HashSet<QueueMaster>();
        }
    
        public long Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string CC { get; set; }
        public string Bcc { get; set; }
        public Nullable<bool> IsBodyHtml { get; set; }
    
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<QueueArchive> QueueArchives { get; set; }
        public virtual ICollection<QueueMaster> QueueMasters { get; set; }
    }
}
