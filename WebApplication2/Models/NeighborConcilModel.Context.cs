﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NeighborhoodCouncilEntities : DbContext
    {
        public NeighborhoodCouncilEntities()
            : base("name=NeighborhoodCouncilEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Announcement_Info> Announcement_Info { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Committee_Members> Committee_Members { get; set; }
        public virtual DbSet<Council> Councils { get; set; }
        public virtual DbSet<Election> Elections { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<Meeting_Arrangements> Meeting_Arrangements { get; set; }
        public virtual DbSet<Meeting_Location> Meeting_Location { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Nomination> Nominations { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Project_log> Project_log { get; set; }
        public virtual DbSet<Report_Problem> Report_Problem { get; set; }
        public virtual DbSet<Voters_Info> Voters_Info { get; set; }
    }
}
