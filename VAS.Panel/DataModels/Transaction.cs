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
    
    public partial class Transaction
    {
        public int Id { get; set; }
        public byte TransactionTypeId { get; set; }
        public long Amount { get; set; }
        public int SubscriptionId { get; set; }
        public string DetailDescription { get; set; }
    
        public virtual TransactionType TransactionType { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}