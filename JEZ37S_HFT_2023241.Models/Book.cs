﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace JEZ37S_HFT_2023241.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(Category))]
        public int Category_id { get; set; }
        [ForeignKey(nameof(Author))]
        public int Author_id { get; set; }
        [ForeignKey(nameof(Reservation))]
        public int Reservation_id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int Publication_year { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual Reservation Reservation { get; set; }


        public Book(int id,int category_id,int reservation_id,int author_id,string name,int publication_year)
        {
            Id = id;
            Category_id = category_id;
            Reservation_id = reservation_id;
            Author_id = author_id;
            Name = name;
            Publication_year = publication_year;
        }
        public Book()
        {

        }

    }
}
