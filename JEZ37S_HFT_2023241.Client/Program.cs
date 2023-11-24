using ConsoleTools;
using JEZ37S_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static JEZ37S_HFT_2023241.Models.Author;
using static JEZ37S_HFT_2023241.Models.Book;
using static JEZ37S_HFT_2023241.Models.Category;
using static JEZ37S_HFT_2023241.Models.Reservation;

namespace JEZ37S_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:13009/","book");   

            var reservationSubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Reservation"))
               .Add("Create", () => Create("Reservation"))
               .Add("Delete", () => Delete("Reservation"))
               .Add("Update", () => Update("Reservation"))
               .Add("HowManyBooksHasBeenReserved", () => HowManyBooksHasBeenReserved())
               .Add("Exit", ConsoleMenu.Close);

            var categorySubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Category"))
               .Add("Create", () => Create("Category"))
               .Add("Delete", () => Delete("Category"))
               .Add("Update", () => Update("Category"))
               .Add("CountBooksPerCategory", () => CountBooksPerCategory())
               .Add("Exit", ConsoleMenu.Close);

            var authorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Author"))
                .Add("Create", () => Create("Author"))
                .Add("Delete", () => Delete("Author"))
                .Add("Update", () => Update("Author"))
                .Add("GetAuthorBooks", () => GetAuthorBooks())
                .Add("Exit", ConsoleMenu.Close);

            var bookSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Book"))
                .Add("Create", () => Create("Book"))
                .Add("Delete", () => Delete("Book"))
                .Add("Update", () => Update("Book"))
                .Add("WhenWasTheAuthorBorn", () => WhenWasTheAuthorBorn())
                .Add("Reservedby", () => Reservedby())
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
                Console.Write("Enter book title: ");
                string title = Console.ReadLine();
                rest.Post(new Book() { Name = title }, "book");
            }
            else if (entity == "Author")
            {
                Console.Write("Enter author name: ");
                string name = Console.ReadLine();
                rest.Post(new Author() { Name = name }, "author");
            }
            else if (entity == "Category")
            {
                Console.Write("Enter category name: ");
                string name = Console.ReadLine();
                rest.Post(new Category() { Category_Name = name }, "category");
            }
            else if (entity == "Reservation")
            {
                Console.Write("Enter reservation member name: ");
                string name = Console.ReadLine();
                Console.Write("Enter reservation days: ");
                int days = int.Parse(Console.ReadLine());
                rest.Post(new Reservation() { MemberName = name,ReservationDays = days }, "reservation");
            }
        }
        static void List(string entity)
        {
            if (entity == "Book")
            {
                List<Book> books = rest.Get<Book>("book");
                foreach (var item in books)
                {
                    Console.WriteLine(item.Id + "\t" +item.Name);
                }
            }
            else if (entity == "Author")
            {
                List<Author> authors = rest.Get<Author>("author");
                foreach (var item in authors)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name);
                }
            }
            else if (entity == "Category")
            {
                List<Category> categories = rest.Get<Category>("category");
                foreach (var item in categories)
                {
                    Console.WriteLine(item.Id + "\t" + item.Category_Name);
                }
            }
            else if (entity == "Reservation")
            {
                List<Reservation> reservations = rest.Get<Reservation>("reservation");
                foreach (var item in reservations)
                {
                    Console.WriteLine(item.Id + "\t" + item.MemberName);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Book")
            {
                Console.Write("Enter book's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Book one = rest.Get<Book>(id, "book");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "book");
            }
            else if (entity == "Author")
            {
                Console.Write("Enter author's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Author one = rest.Get<Author>(id, "author");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "author");
            }
            else if (entity == "Category")
            {
                Console.Write("Enter category's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Category one = rest.Get<Category>(id, "category");
                Console.Write($"New name [old: {one.Category_Name}]: ");
                string name = Console.ReadLine();
                one.Category_Name = name;
                rest.Put(one, "category");
            }
            else if (entity == "Reservation")
            {
                Console.Write("Enter reservation's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Reservation one = rest.Get<Reservation>(id, "reservation");
                Console.Write($"New name [old: {one.MemberName}]: ");
                string name = Console.ReadLine();
                one.MemberName = name;
                rest.Put(one, "reservation");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Book")
            {
                Console.Write("Enter book's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "book");
            }
            else if (entity == "Author")
            {
                Console.Write("Enter author's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "author");
            }
            else if (entity == "Category")
            {
                Console.Write("Enter category's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "category");
            }
            else if (entity == "Reservation")
            {
                Console.Write("Enter reservation's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "reservation");
            }
        }
        static void GetAuthorBooks()
        {
            Console.Write("Enter the name of the chosen author: ");
            string name = Console.ReadLine();
            List<BooksWrittenbyAuthor> list = rest.Get<BooksWrittenbyAuthor>(name, "Stat/GetAuthorBooks");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static void WhenWasTheAuthorBorn()
        {
            Console.Write("Enter the name of the chosen book: ");
            string name = Console.ReadLine();
            List<AuthorsBornYear> list = rest.Get<AuthorsBornYear>(name, "Stat/WhenWasTheAuthorBorn");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static void Reservedby()
        {
            Console.Write("Enter the name of the chosen book: ");
            string name = Console.ReadLine();
            List<WhoReservedThisBook> list = rest.Get<WhoReservedThisBook>(name, "Stat/Reservedby");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static void CountBooksPerCategory()
        {
            Console.Write("Enter the name of the chosen category: ");
            string name = Console.ReadLine();
            List<HowManyBooksPerCategory> list = rest.Get<HowManyBooksPerCategory>(name, "Stat/CountBooksPerCategory");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static void HowManyBooksHasBeenReserved()
        {
            Console.Write("Enter the name of the chosen member: ");
            string name = Console.ReadLine();
            List<BooksReservedby> list = rest.Get<BooksReservedby>(name, "Stat/HowManyBooksHasBeenReserved");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();

        }




    }
}
