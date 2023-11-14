using JEZ37S_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;
using static JEZ37S_HFT_2023241.Models.Author;

namespace JEZ37S_HFT_2023241.Logic.Interfaces
{
    public interface IAuthorLogic
    {
        void Create(Author item);
        void Delete(int id);
        public IEnumerable<BooksWrittenbyAuthor> GetAuthorBooks(string author);
        IQueryable<Author> ReadAll();
        void Update(Author item);
    }
}