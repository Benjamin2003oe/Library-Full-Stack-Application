using JEZ37S_HFT_2023241.Logic.Logics;
using JEZ37S_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;
using static JEZ37S_HFT_2023241.Models.Book;

namespace JEZ37S_HFT_2023241.Logic.Interfaces
{
    public interface IBookLogic
    {
        public IEnumerable<AuthorsBornYear> WhenWasTheAuthorBorn(string bookname);
        void Create(Book item);
        void Delete(int id);
        public IEnumerable<WhoReservedThisBook> Reservedby(string bookname);
        Book Read(int id);
        IQueryable<Book> ReadAll();
        void Update(Book item);
    }
}