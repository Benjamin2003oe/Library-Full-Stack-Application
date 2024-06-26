﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JEZ37S_HFT_2023241.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        public string Category_Name { get; set; }
        public bool UnderAgeContent { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }


        public Category(int id, string category_name, bool underagecontent)
        {
            Id = id;
            Category_Name = category_name;
            UnderAgeContent = underagecontent;
            Books = new HashSet<Book>();
        }
        public Category()
        {
            Books = new HashSet<Book>();
        }
        //Non-Crud Class
        public class HowManyBooksPerCategory
        {
            public HowManyBooksPerCategory()
            {

            }
            public string name { get; set; }
            public override string ToString()
            {
                return $"{name}";
            }

            public override bool Equals(object obj)
            {
                HowManyBooksPerCategory b = obj as HowManyBooksPerCategory;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.name == b.name;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.name);
            }
        }
    }
}
