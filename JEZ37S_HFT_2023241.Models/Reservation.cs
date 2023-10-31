using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace JEZ37S_HFT_2023241.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string MemberName { get; set; }
        public int ReservationDays { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public Reservation(int id,string memberName, int reservationDays)
        {
            Id = id;
            MemberName = memberName;
            ReservationDays = reservationDays;
            Books = new HashSet<Book>();
        }
        public Reservation()
        {
            Books = new HashSet<Book>();
        }
    }
}
