using JEZ37S_HFT_2023241.Logic.Interfaces;
using JEZ37S_HFT_2023241.Models;
using JEZ37S_HFT_2023241.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JEZ37S_HFT_2023241.Models.Author;
using static JEZ37S_HFT_2023241.Models.Book;

namespace JEZ37S_HFT_2023241.Logic.Logics
{
    public class AuthorLogic : IAuthorLogic
    {
        IRepository<Author> repo;

        public AuthorLogic(IRepository<Author> repo)
        {
            this.repo = repo;
        }

        public void Create(Author item)
        {
            if (item.YearOfBirth > 2023)
            {
                throw new ArgumentException("The author is too young");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Author Read(int id)
        {
            var author = repo.Read(id);
            if (author == null)
            {
                throw new ArgumentException($"{id} id does not exist");
            }
            return author;
        }

        public IQueryable<Author> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Author item)
        {
            this.repo.Update(item);
        }
        //This method can tell you the name of the books written by a chosen author
        public IEnumerable<BooksWrittenbyAuthor> GetAuthorBooks(string author)
        {
            return ReadAll()
                .Where(t => t.Name.Equals(author))
                .SelectMany(t=>t.Books)
                .Where(t => t.Author.Name.Equals(author))
                .Select(t => new BooksWrittenbyAuthor()
                {
                    name = t.Name
                }); ;
        } 

    }
}
