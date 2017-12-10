﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VASEntities : DbContext
    {
        public VASEntities()
            : base("name=VASEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AttachmentType> AttachmentTypes { get; set; }
        public virtual DbSet<BankTransactionType> BankTransactionTypes { get; set; }
        public virtual DbSet<ChargeType> ChargeTypes { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<DiscountType> DiscountTypes { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<MessageType> MessageTypes { get; set; }
        public virtual DbSet<PersonType> PersonTypes { get; set; }
        public virtual DbSet<ServiceOutputType> ServiceOutputTypes { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }
        public virtual DbSet<ActivityLog> ActivityLogs { get; set; }
        public virtual DbSet<AttachmentFile> AttachmentFiles { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MessageTemplate> MessageTemplates { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<PriceDetail> PriceDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductFamily> ProductFamilies { get; set; }
        public virtual DbSet<ProductInfo> ProductInfoes { get; set; }
        public virtual DbSet<ProductService> ProductServices { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceInfo> ServiceInfoes { get; set; }
        public virtual DbSet<Statement> Statements { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<RequestHistory> RequestHistories { get; set; }
    }
}
