﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BorrowTools.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BorrowToolEntities1 : DbContext
    {
        public BorrowToolEntities1()
            : base("name=BorrowToolEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tool> Tools { get; set; }

        public System.Data.Entity.DbSet<BorrowTools.Models.customer> customers { get; set; }

        public System.Data.Entity.DbSet<BorrowTools.Models.Location> Locations { get; set; }
    }
}
