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
    
    public partial class ProductInfo
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public byte LanguageTypeId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual Product Product { get; set; }
    }
}