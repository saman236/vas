//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VAS.Panel.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Statement
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public Nullable<System.DateTime> OpenDate { get; set; }
        public Nullable<System.DateTime> CloseDate { get; set; }
        public Nullable<System.DateTime> SettlementDate { get; set; }
        public string Description { get; set; }
        public Nullable<byte> MessageTypeId { get; set; }
        public int TotalBillAmount { get; set; }
    
        public virtual MessageTemplate MessageTemplate { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
