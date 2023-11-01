using JEZ37S_HFT_2023241.Models;
using JEZ37S_HFT_2023241.Repository.DataBase;
using JEZ37S_HFT_2023241.Repository.Interfaces;
using JEZ37S_HFT_2023241.Repository.ModelRepositories;
using System;
using System.Linq;

namespace JEZ37S_HFT_2023241.Repository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryDbContext test = new LibraryDbContext();
            foreach (var item in test.Books)
            {
                Console.WriteLine(item.Name + ": " + item.Category.Category_Name + "\n\tIrta: "
                    + item.Author.Name + "\n\tKibérelte: " + item.Reservation.MemberName + "\n\tBérelési szám: " + item.Reservation.Id + "\n");

            }
            IRepository<Author> repo = new AuthorRepository(new LibraryDbContext());

            Author a = new Author()
            {
                Name = "Newton"
            };
            repo.Create(a);

            var another = repo.Read(1);
            another.Name = "Steve";
            repo.Update(another);

            var items = repo.ReadAll().ToArray();
            ;
        }
    }
}
