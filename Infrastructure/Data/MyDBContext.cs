using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Data
{
    internal class MyDBContext : DbContext
    {
        //public DbSet<Entity> Entities { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
            // Database.EnsureDeleted();
            if (Database.EnsureCreated())
            {
                DefaultGenerate generate = new DefaultGenerate();
                var dg = generate.DefaultDepartments();
                Departments.AddRange(dg);
                var em = generate.DefaultEmloyees(dg);
                Employees.AddRange(em);
                var pr = generate.DefaultProducts();
                Products.AddRange(pr);
                SaveChanges();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        #region Տhis classes is used once

        private class DefaultGenerate
        {
            private Random r = new Random();
            private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            public List<Employee> DefaultEmloyees(List<Department> dg)
            {
                var st = new DateTime(1940, 1, 1, 0, 0, 0);
                var ft = (int)new DateTime(1995, 12, 31).Subtract(st).TotalSeconds;
                var days = new byte[] { 1, 2, 3, 4, 5, 6, 7 };

                List<Employee> em = new();

                for (int i = 0; i < 50000; i++)
                {
                    em.Add(new()
                    {
                        DepartmentId = dg[r.Next(dg.Count)].Id,
                        FirstName = $"Employee {i}",
                        LastName = new string(Enumerable.Repeat(chars, r.Next(5, 15)).Select(s => s[r.Next(s.Length)]).ToArray()), //Random string with 5-15 characters length
                        BirthDate = i % 3000 == 0 ? null : st.AddSeconds(r.Next(0, ft)), //Random date from 01.01.1940 to 31.12.1995 or nothing (unknown)
                        Wage = r.Next(1, 100) * 10,   //Random number 10-1000 divisible to 10
                        Workdays = days[r.Next(1, 7)]  //Random number 1-7 (byte type)
                    });
                }
                return em;
            }

            public List<Department> DefaultDepartments() => new()
            {
                new() { Name = "Administration" },
                new() { Name = "Management" },
                new() { Name = "Programming" },
                new() { Name = "Marketing" },
                new() { Name = "Store" }
            };

            public List<Product> DefaultProducts()
            {
                var em = new List<Product>();
                var barcodeL = new HashSet<string>();
                var pluL = new HashSet<int>();

                while (true)
                {
                    var plu = r.Next(1, 99999);
                    var barcode = em.Count % 5000 == 0 ? null : new string(Enumerable.Repeat(chars, 13).Select(s => s[r.Next(s.Length)]).ToArray()); //10% of products should not have a barcode

                    var isBarcode = barcodeL.Add(barcode);
                    var isplu = pluL.Add(plu);

                    if ((barcode == null && isplu) || (isBarcode && isplu))
                    {
                        em.Add(new()
                        {
                            Name = new string(Enumerable.Repeat(chars, r.Next(5, 15)).Select(s => s[r.Next(s.Length)]).ToArray()), //Random string with 5-15 characters length
                            Price = r.Next(1, 500) * 10,
                            Barcode = barcode, //10% of products should not have a barcode
                            PLU = plu
                        });
                    }
                    if (em.Count() == 50000) { break; }
                }
                return em;
            }
        }

        #endregion Տhis classes is used once
    }
}