using JEZ37S_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEZ37S_HFT_2023241.Repository.DataBase
{
    public class LibraryDbContext: DbContext
    {   
        public LibraryDbContext()
        {
             this.Database.EnsureCreated();
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                //.UseSqlServer(conn)
                .UseInMemoryDatabase("LibraryDB")
                .UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(book => book
            .HasOne(book => book.Author)
            .WithMany(author => author.Books)
            .HasForeignKey(book => book.Author_id)
            .OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book(1,1,1,1,"A holló",1845),
                new Book(2,2,2,2,"A lány a vonaton",2015),
                new Book(3,3,3,3,"Az Alapítvány",1951),
                new Book(4,4,4,4,"A Marsi",2011),
                new Book(5,5,1,5,"Stolz és szépség",1813),
                new Book(6,6,4,6,"Az örökkévalóság nyára",2012),
                new Book(7,7,7,7,"A Hattyúk tava",2007),
                new Book(8,8,8,8,"A Bíró kutyája",1994),
                new Book(9,9,9,9,"Harry Potter és a bölcsek köve",1997),
                new Book(10,10,4,10,"Trónok harca",1996),
            });
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author(1,"Edgar Allan Poe",1809),
                new Author(2,"Paula Hawkins",1927),
                new Author(3,"Isaac Asimov",1920),
                new Author(4,"Andy Weir",1972),
                new Author(5,"Jane Austen",1775),
                new Author(6,"Morgan Matson",1989),
                new Author(7,"Kate Furnivall",1970),
                new Author(8,"Orhan Pamuk",1952),
                new Author(9,"J.K. Rowling",1965),
                new Author(10,"George R.R. Martin",1948)
            });

            modelBuilder.Entity<Book>(book => book
            .HasOne(book => book.Reservation)
            .WithMany(reservation => reservation.Books)
            .HasForeignKey(book => book.Reservation_id)
            .OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Reservation>().HasData(new Reservation[]
            {
                new Reservation(1,"Kiss Klaudia",10),
                new Reservation(2,"Nagy Ferenc",20),
                new Reservation(3,"Kerekes Péter",31),
                new Reservation(4,"Kovács Antal",5),
                new Reservation(5,"Kiss Klaudia",1),
                new Reservation(6,"Kovács Antal",60),
                new Reservation(7,"Szénási Ádám",30),
                new Reservation(8,"Ferences Gábor",20),
                new Reservation(9,"Citad Ella",25),
                new Reservation(10,"Kovács Antal",1),

            });
        }
    }
}
