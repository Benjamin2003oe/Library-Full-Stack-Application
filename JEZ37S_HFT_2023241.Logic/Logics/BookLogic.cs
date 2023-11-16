using JEZ37S_HFT_2023241.Logic.Interfaces;
using JEZ37S_HFT_2023241.Models;
using JEZ37S_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JEZ37S_HFT_2023241.Models.Book;

namespace JEZ37S_HFT_2023241.Logic.Logics
{
    public class BookLogic : IBookLogic
    {
        IRepository<Book> repo;

        public BookLogic(IRepository<Book> repo)
        {
            this.repo = repo;
        }

        public void Create(Book item)
        {
            if (item.Name.Length < 3)
            {
                throw new ArgumentException("The name of the book is too short...");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Book Read(int id)
        {
            var book = repo.Read(id);
            if (book == null)
            {
                throw new ArgumentException($"{id} id does not exist");
            }
            return book;
        }

        public IQueryable<Book> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Book item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<AuthorsBornYear> WhenWasTheAuthorBorn(string bookname)
        {
            return ReadAll()
                .Where(t => t.Name == bookname)
                .Select(t => t.Author)
                .Select(t => new AuthorsBornYear()
                {
                    year = t.YearOfBirth

                });
        }
        public IEnumerable<WhoReservedThisBook> Reservedby(string bookname)
        {
            return ReadAll()
                .Where(t => t.Name == bookname)
                .Select(t=>t.Reservation)
                .Select(t=>new WhoReservedThisBook()
                { 
                    membername = t.MemberName
                });
        }


    }
}
