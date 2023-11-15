using JEZ37S_HFT_2023241.Logic.Logics;
using JEZ37S_HFT_2023241.Models;
using JEZ37S_HFT_2023241.Repository.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEZ37S_HFT_2023241.Test
{
    public class FakeBookRepository : IRepository<Book>
    {
        public void Create(Book item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Book Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> ReadAll()
        {
            return new List<Book>()
            {
                new Book(1,1,1,1,"Book1",1961),
                new Book(2,2,2,2,"Book2",1962),
                new Book(3,3,3,3,"Book3",1963),
                new Book(4,4,4,4,"Book4",1964),
            }.AsQueryable();
        }

        public void Update(Book item)
        {
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class BookLogicTester
    {
        BookLogic logic;

        [SetUp]
        public void Init()
        {
            logic = new BookLogic(new FakeBookRepository());
        }

    }
}
