//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Img.EmailQueue.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Organization
    {
        public Organization()
        {
            this.QueueMasters = new HashSet<QueueMaster>();
        }
    
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public int ApiKey { get; set; }
    
        public virtual ApiKey ApiKey1 { get; set; }
        public virtual ICollection<QueueMaster> QueueMasters { get; set; }
    }
}
