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
    
    public partial class ApiKey
    {
        public int Id { get; set; }
        public long OrganizationId { get; set; }
        public System.Guid ApiKey1 { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        public virtual Organization Organization { get; set; }
    }
}