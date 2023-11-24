using Castle.Core.Smtp;
using JEZ37S_HFT_2023241.Logic.Logics;
using JEZ37S_HFT_2023241.Models;
using JEZ37S_HFT_2023241.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static JEZ37S_HFT_2023241.Models.Author;
using static JEZ37S_HFT_2023241.Models.Book;
using static JEZ37S_HFT_2023241.Models.Category;
using static JEZ37S_HFT_2023241.Models.Reservation;

namespace JEZ37S_HFT_2023241.Test
{
    [TestFixture]
    public class BookLogicTester
    {
        BookLogic logic;
        Mock<IRepository<Book>> mockBookRepo;
        [SetUp]
        public void Init()
        {
            mockBookRepo = new Mock<IRepository<Book>>();
            mockBookRepo.Setup(m => m.ReadAll()).Returns(new List<Book>()
            {
                new Book() 
                {
                    Id = 1,
                    Author_id=1,
                    Category_id=1,
                    Reservation_id=1,
                    Name="Book1", 
                    Publication_year=1992,
                    Authors = new List<Author>()
                    { 
                        new Author() 
                        { 
                            Id=1, 
                            Name="Author1",
                            YearOfBirth=1952
                        } 
                    } ,
                    Reservations = new List<Reservation>()
                    {
                        new Reservation()
                        {
                            Id = 1,
                            MemberName = "Member1",
                            ReservationDays = 1,
                        }
                    }
                }
            }.AsQueryable());
            logic = new BookLogic(mockBookRepo.Object);
        }

        [Test]
        public void ReadWithCorrectId()
        {
            Book book = new Book()
            {
                Id = 1,
                Author_id = 1,
                Category_id = 1,
                Reservation_id = 1,
                Name = "Book1",
                Publication_year = 1991
            };
            mockBookRepo.Setup(m => m.Read(1)).Returns(book);
            var finalbook = logic.Read(1);
            Assert.AreEqual(finalbook,book);
        }
        [Test]
        public void CreateBookShortName()
        {
            var ShortName = new Book()
            {
                Name = "a"
            };
            try
            {
                logic.Create(ShortName);

            }
            catch
            {
            }
            mockBookRepo.Verify(m => m.Create(ShortName), Times.Never);
        }

    }
    public class AuthorLogicTester
    {
        AuthorLogic logic;
        Mock<IRepository<Author>> mockAuthorRepo;
        [SetUp]
        public void Init()
        {
            mockAuthorRepo = new Mock<IRepository<Author>>();
            mockAuthorRepo.Setup(m => m.ReadAll()).Returns(new List<Author>()
            {
                new Author()
                {
                    Id=1,
                    Name="Author1",
                    YearOfBirth=1952,
                    Books= new List<Book>()
                    {
                        new Book()
                        {
                            Id=1,
                            Category_id=1,
                            Reservation_id=1,
                            Author_id =1,
                            Name="Book1",
                            Publication_year=1991,
                            Author = new Author()  
                            {
                                Id = 1,
                                Name = "Author1",
                                YearOfBirth = 1952,
                            }
                        }
                    }
                }
            }.AsQueryable());
            logic = new AuthorLogic(mockAuthorRepo.Object);
        }
        [Test]
        public void AuthorBooks()
        {
            var actual = logic.GetAuthorBooks("Author1");
            var expected = new List<BooksWrittenbyAuthor>()
            {
                new BooksWrittenbyAuthor()
                {
                    name = "Book1"
                }
            };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CreateYoungAuthor()
        {
            var bornIn = new Author()
            {
                YearOfBirth = 2024
            };
            try
            {
                logic.Create(bornIn);

            }
            catch
            {
            }
            mockAuthorRepo.Verify(m => m.Create(bornIn), Times.Never);
        }
    }
    public class CategoryLogicTester
    {
        CategoryLogic logic;
        Mock<IRepository<Category>> mockCategoryRepo;
        [SetUp]
        public void Init()
        {
            mockCategoryRepo = new Mock<IRepository<Category>>();
            mockCategoryRepo.Setup(m => m.ReadAll()).Returns(new List<Category>()
            {

                new Category()
                {
                    Id = 1,
                    Category_Name = "Category1",
                    UnderAgeContent = true,
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                             Id = 1,
                             Category_id = 1,
                             Reservation_id = 1,
                             Author_id = 1,
                             Name = "Book1",
                             Publication_year = 1991,
                             Category = new Category()  
                             {
                                 Id = 1,
                                 Category_Name = "Category1",
                                 UnderAgeContent = true,
                             }
                        },
                    }
                }

            }.AsQueryable()); ;
            logic = new CategoryLogic(mockCategoryRepo.Object);
        }
        [Test]
        public void GetCountBooksPerCategory()
        {
            var actual = logic.CountBooksPerCategory("Category1");
            var expected = new List<HowManyBooksPerCategory>()
            {
                new HowManyBooksPerCategory()
                {
                    name = "Book1"
                }
            };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ReadWithCorrectId()
        {
            Category category = new Category()
            {
                Id = 1,
                Category_Name = "Category1",
                UnderAgeContent = false
            };
            mockCategoryRepo.Setup(m => m.Read(1)).Returns(category);
            var finalcategory = logic.Read(1);
            Assert.AreEqual(finalcategory, category);
        }
        [Test]
        public void CreateCategoryShortName()
        {
            var ShortName = new Category()
            {
                Category_Name = "a"
            };
            try
            {
                logic.Create(ShortName);

            }
            catch
            {
            }
            mockCategoryRepo.Verify(m => m.Create(ShortName), Times.Never);
        }
        [Test]
        public void CreateCategoryWithCorrectName()
        {
            var ShortName = new Category()
            {
                Category_Name = "Categoryabcde"
            }; 
            logic.Create(ShortName);
            mockCategoryRepo.Verify(m => m.Create(ShortName), Times.Once);
        }
    }
    public class ReservationLogicTester
    {
        ReservationLogic logic;
        Mock<IRepository<Reservation>> mockReservationRepo;
        [SetUp]
        public void Init()
        {
            mockReservationRepo = new Mock<IRepository<Reservation>>();
            mockReservationRepo.Setup(m => m.ReadAll()).Returns(new List<Reservation>()
            {
                new Reservation()
                {
                    Id = 1,
                    MemberName = "Member1",
                    ReservationDays = 1,
                    Books = new List<Book>()
                    {
                         new Book()
                         {
                              Id = 1,
                              Category_id = 1,
                              Reservation_id = 1,
                              Author_id = 1,
                              Name = "Book1",
                              Publication_year = 1991,
                              Reservation = new Reservation()  
                              {
                                  Id = 1,
                                  MemberName = "Member1",
                                  ReservationDays = 1,
                              }
                         }
                    }
                },
            }.AsQueryable()); ;
            logic = new ReservationLogic(mockReservationRepo.Object);
        }
        [Test]
        public void GetHowManyBooksHasBeenReserved()
        {
            var actual = logic.HowManyBooksHasBeenReserved("Member1");
            var expected = new List<BooksReservedby>()
            {
                new BooksReservedby()
                {
                    count = 1
                }
            };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CreateReservationForShortPeriod()
        {
            var ShortReservation = new Reservation()
            {
                ReservationDays = 1
            };
            try
            {
                logic.Create(ShortReservation);

            }
            catch
            {
            }
            mockReservationRepo.Verify(m => m.Create(ShortReservation), Times.Never);
        }
    }
    

}
