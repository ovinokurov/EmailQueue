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
    
    public partial class ApiKey
    {
        public ApiKey()
        {
            this.Organizations = new HashSet<Organization>();
        }
    
        public int Id { get; set; }
        public System.Guid ApiKey1 { get; set; }
        public System.DateTime Expiration { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        public virtual ICollection<Organization> Organizations { get; set; }
    }
}