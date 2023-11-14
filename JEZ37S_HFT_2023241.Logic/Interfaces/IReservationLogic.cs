using JEZ37S_HFT_2023241.Models;
using System.Linq;

namespace JEZ37S_HFT_2023241.Logic.Interfaces
{
    public interface IReservationLogic
    {
        void Create(Reservation item);
        void Delete(int id);
        Reservation Read(int id);
        IQueryable<Reservation> ReadAll();
        void Update(Reservation item);
    }
}