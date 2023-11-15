using ConsoleTools;
using JEZ37S_HFT_2023241.Logic.Logics;
using JEZ37S_HFT_2023241.Models;
using JEZ37S_HFT_2023241.Repository.DataBase;
using JEZ37S_HFT_2023241.Repository.ModelRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace JEZ37S_HFT_2023241.Client
{
    internal class Program
    {
        static BookLogic booklogic;
        static AuthorLogic authorlogic;
        static CategoryLogic categorylogic;
        static ReservationLogic reservationlogic;
        static void Main(string[] args)
        {
            var ctx = new LibraryDbContext();

            var boo = new BookRepository(ctx);
            var cate = new CategoryRepository(ctx);
            var auth = new AuthorRepository(ctx);
            var reser = new ReservationRepository(ctx);

            booklogic = new BookLogic(boo);
            categorylogic = new CategoryLogic(cate);
            authorlogic = new AuthorLogic(auth);
            reservationlogic = new ReservationLogic(reser);

            var nc2 = categorylogic.CountBooksPerCategory("Történelmi regény");
            var nc3 = booklogic.WhenWasTheAuthorBorn("Az Alapítvány");
            var nc4 = booklogic.Reservedby("A lány a vonaton");
            var nc5 = authorlogic.GetAuthorBooks("J.K. Rowling");
            var nc6 = reservationlogic.HowManyBooksHasBeenReserved("Kovács Antal");

            var reservationSubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Reservation"))
               .Add("Create", () => Create("Reservation"))
               .Add("Delete", () => Delete("Reservation"))
               .Add("Update", () => Update("Reservation"))
               .Add("Exit", ConsoleMenu.Close);           

            var categorySubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Category"))
               .Add("Create", () => Create("Category"))
               .Add("Delete", () => Delete("Category"))
               .Add("Update", () => Update("Category"))
               .Add("Exit", ConsoleMenu.Close);

            var authorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Author"))
                .Add("Create", () => Create("Author"))
                .Add("Delete", () => Delete("Author"))
                .Add("Update", () => Update("Author"))
                .Add("Exit", ConsoleMenu.Close);

            var bookSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Book"))
                .Add("Create", () => Create("Book"))
                .Add("Delete", () => Delete("Book"))
                .Add("Update", () => Update("Book"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Books", () => bookSubMenu.Show())
                .Add("Author", () => authorSubMenu.Show())
                .Add("Category", () => categorySubMenu.Show())
                .Add("Reservations", () => reservationSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();  
        }
        
        static void Create(string entity)
        {
            if (entity == "Book")
            {
                Console.Write("Add meg a könyv nevét: ");
                string name = Console.ReadLine();
                Console.Write("Add meg a könyv kiadási évét: ");
                int year = int.Parse(Console.ReadLine());
                Book newBook = new Book()
                {
                    Name = name,
                    Publication_year = year,
                };
                booklogic.Create(newBook);
            }
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Book")
            {
                var items = booklogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name);
                }
            }
            else if (entity == "Author")
            {
                var items = authorlogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name);
                }
            }
            else if (entity == "Category")
            {
                var items = categorylogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Id + "\t" + item.Category_Name);
                }
            }
            else if (entity == "Reservation")
            {
                var items = reservationlogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Id + "\t" + item.MemberName);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }
    }
}
