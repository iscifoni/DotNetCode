﻿// <auto-generated />
using AddressBook.Dal.Abstract;
using AddressBook.Dal.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AddressBook.Dal.SqlServer.Migrations
{
    [DbContext(typeof(AddressBookContext))]
    partial class AddressBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AddressBook.Dal.SqlServer.Person", b =>
                {
                    b.Property<int>("IdPerson")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("IdPerson");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("AddressBook.Dal.SqlServer.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdPerson");

                    b.Property<string>("Number");

                    b.Property<int>("NumberType");

                    b.HasKey("Id");

                    b.HasIndex("IdPerson");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("AddressBook.Dal.SqlServer.PhoneNumber", b =>
                {
                    b.HasOne("AddressBook.Dal.SqlServer.Person")
                        .WithMany("PhoneNumber")
                        .HasForeignKey("IdPerson")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
