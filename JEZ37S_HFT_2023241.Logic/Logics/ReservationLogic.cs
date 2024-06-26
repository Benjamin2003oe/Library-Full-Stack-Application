﻿using JEZ37S_HFT_2023241.Logic.Interfaces;
using JEZ37S_HFT_2023241.Models;
using JEZ37S_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JEZ37S_HFT_2023241.Models.Category;
using static JEZ37S_HFT_2023241.Models.Reservation;

namespace JEZ37S_HFT_2023241.Logic.Logics
{
    public class ReservationLogic : IReservationLogic
    {
        IRepository<Reservation> repo;

        public ReservationLogic(IRepository<Reservation> repo)
        {
            this.repo = repo;
        }

        public void Create(Reservation item)
        {
            if (item.ReservationDays < 2)
            {
                throw new ArgumentException("You have to reservate the books for minimum 2 days!");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Reservation Read(int id)
        {
            var reservation = repo.Read(id);
            if (reservation == null)
            {
                throw new ArgumentException($"{id} id does not exist");
            }
            return reservation;
        }

        public IQueryable<Reservation> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Reservation item)
        {
            this.repo.Update(item);
        }
        //This method can tell you how many books has been reserved by a person by typing in the name of a person
        public IEnumerable<BooksReservedby> HowManyBooksHasBeenReserved(string membername)
        {
            return ReadAll()
                .SelectMany(t=>t.Books)
                .Where(t => t.Reservation.MemberName == membername)
                .GroupBy(t=>t.Reservation.MemberName)
                .Select(t => new BooksReservedby()
                {
                    count = t.Count()                   
                });

        }

    }
}
