using JEZ37S_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;
using static JEZ37S_HFT_2023241.Models.Reservation;

namespace JEZ37S_HFT_2023241.Logic.Interfaces
{
    public interface IReservationLogic
    {
        void Create(Reservation item);
        void Delete(int id);
        public IEnumerable<BooksReservedby> HowManyBooksHasBeenReserved(string membername);
        Reservation Read(int id);
        IQueryable<Reservation> ReadAll();
        void Update(Reservation item);
    }
}