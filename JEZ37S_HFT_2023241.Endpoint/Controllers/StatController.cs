using JEZ37S_HFT_2023241.Logic.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using static JEZ37S_HFT_2023241.Models.Author;
using static JEZ37S_HFT_2023241.Models.Book;
using static JEZ37S_HFT_2023241.Models.Category;
using static JEZ37S_HFT_2023241.Models.Reservation;

namespace JEZ37S_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IBookLogic booklogic;
        IAuthorLogic authorlogic;
        ICategoryLogic categorylogic;
        IReservationLogic reservationlogic;
        public StatController(IBookLogic booklogic,IAuthorLogic authorlogic, ICategoryLogic categorylogic, IReservationLogic reservationlogic)
        {
            this.booklogic = booklogic;
            this.authorlogic = authorlogic;
            this.categorylogic = categorylogic;
            this.reservationlogic = reservationlogic;
        }
        [HttpGet("{bookname}")]
        public IEnumerable<AuthorsBornYear> WhenWasTheAuthorBorn(string bookname)
        {
            return this.booklogic.WhenWasTheAuthorBorn(bookname);
        }
        [HttpGet("{bookname}")]
        public IEnumerable<WhoReservedThisBook> Reservedby(string bookname)
        {
            return this.booklogic.Reservedby(bookname);
        }
        [HttpGet("{author}")]
        public IEnumerable<BooksWrittenbyAuthor> GetAuthorBooks(string author)
        {
            return this.authorlogic.GetAuthorBooks(author);
        }
        [HttpGet("{category}")]
        public IEnumerable<HowManyBooksPerCategory> CountBooksPerCategory(string category)
        {
            return this.categorylogic.CountBooksPerCategory(category);
        }
        [HttpGet("{membername}")]
        public IEnumerable<BooksReservedby> HowManyBooksHasBeenReserved(string membername)
        {
            return this.reservationlogic.HowManyBooksHasBeenReserved(membername);
        }



    }

}
