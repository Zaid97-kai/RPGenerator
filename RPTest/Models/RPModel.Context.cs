﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RPTest.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RPEntities : DbContext
    {
        public RPEntities()
            : base("name=RPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AcademicPlan> AcademicPlan { get; set; }
        public virtual DbSet<Assessment_Form> Assessment_Form { get; set; }
        public virtual DbSet<Auditory> Auditory { get; set; }
        public virtual DbSet<Auditory_Equipment> Auditory_Equipment { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Chapter> Chapter { get; set; }
        public virtual DbSet<Competencies> Competencies { get; set; }
        public virtual DbSet<Discipline> Discipline { get; set; }
        public virtual DbSet<Discipline_Competencies> Discipline_Competencies { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Kind_Of_Discipline> Kind_Of_Discipline { get; set; }
        public virtual DbSet<Knowledge> Knowledge { get; set; }
        public virtual DbSet<Literary_Source> Literary_Source { get; set; }
        public virtual DbSet<Literary_Source_Author> Literary_Source_Author { get; set; }
        public virtual DbSet<Proffessional_Module> Proffessional_Module { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<Software> Software { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<Topic_Competencies> Topic_Competencies { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Auditory_Software> Auditory_Software { get; set; }
    }
}
