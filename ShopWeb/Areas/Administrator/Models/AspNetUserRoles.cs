﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebShop.Areas.Administrator.Models
{
    public class AspNetUserRoles : WineShopEntities
    {
        public AspNetUserRoles()
        {
        }
        public DbSet<AspNetRole> Roles { get; set; }
        public DbSet<AspNetUser> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .HasMany(u => u.AspNetRoles)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UseId");
                    m.MapRightKey("RoleId");
                    m.ToTable("AspNetUserRoles");
                });
        }
    }
}