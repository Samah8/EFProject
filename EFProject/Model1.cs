using EFProject.StoredProcedurs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace EFProject
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Import_Items> Import_Items { get; set; }
        public virtual DbSet<Import_Perrmission> Import_Perrmission { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_Items> Order_Items { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Transformation> Transformations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.cus_name)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.cus_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.cus_fax)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.cus_mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.cus_email)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Ename)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Ephone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Eaddress)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.job_description)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Stores)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.manager_id);

            modelBuilder.Entity<Import_Perrmission>()
                .HasMany(e => e.Import_Items)
                .WithRequired(e => e.Import_Perrmission)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.item_name)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .Property(e => e.unit_measure)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Import_Items)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Order_Items)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Order_Items)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.store_name)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .Property(e => e.store_address)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Transformations)
                .WithOptional(e => e.Store)
                .HasForeignKey(e => e.to_store);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Transformations1)
                .WithOptional(e => e.Store1)
                .HasForeignKey(e => e.from_store);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.sup_name)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.sup_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.sup_fax)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.sup_mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.sup_email)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Import_Perrmission)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.supplier_id);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Transformations)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.supplier_id);
        }

        //public void Insert_Store(int id,string name, string address,int mgr_id)
        //{
        //    Stores.FromSqlRaw("exec Insert_Store @id,@name,@address,@mgr_id",id,name,address,mgr_id);
        //}

    }

}
