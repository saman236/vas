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
    
    public partial class Subscription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subscription()
        {
            this.ActivityLogs = new HashSet<ActivityLog>();
            this.Statements = new HashSet<Statement>();
            this.Transactions = new HashSet<Transaction>();
        }
    
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int PriceId { get; set; }
        public System.DateTime ActivateDate { get; set; }
        public System.DateTime ExpireDate { get; set; }
        public bool Status { get; set; }
        public Nullable<int> CouponID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
        public virtual Coupon Coupon { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Price Price { get; set; }
        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Statement> Statements { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}