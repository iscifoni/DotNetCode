using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Dal.SqlServer
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext(DbContextOptions<AddressBookContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<PhoneNumber>().ToTable("PhoneNumber");

            modelBuilder.Entity<Person>()
                .HasMany((d) => d.PhoneNumber);
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<PhoneNumber> PhoneNumber { get; set; }
    }
}
