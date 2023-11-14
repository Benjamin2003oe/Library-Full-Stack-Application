using JEZ37S_HFT_2023241.Logic.Logics;
using JEZ37S_HFT_2023241.Models;
using JEZ37S_HFT_2023241.Repository.DataBase;
using JEZ37S_HFT_2023241.Repository.ModelRepositories;
using System;
using System.Linq;

namespace JEZ37S_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctx = new LibraryDbContext();

            var boo = new BookRepository(ctx);
            var boologic = new BookLogic(boo);

            var cate = new CategoryRepository(ctx);
            var catelogic = new CategoryLogic(cate);

            var auth = new AuthorRepository(ctx);
            var authlogic = new AuthorLogic(auth);


            Book b = new Book()
            {
                Id = 101,
                Category_id = 101,
                Reservation_id = 101,
                Author_id = 101,
                Name = "Kis Herceg",
                Publication_year = 1999
                
            };
            boologic.Create(b);
            //Mukodik
            var nc2 = catelogic.CountBooksPerCategory("Történelmi regény");
            //Mukodik
            var nc3 = boologic.WhenWasTheAuthorBorn("Az Alapítvány");
            //Mukodik
            var nc4 = boologic.Reservedby("A lány a vonaton");
            //Mukodik
            var nc5 = authlogic.GetAuthorBooks("J.K. Rowling");
            ;
        }
    }
}
