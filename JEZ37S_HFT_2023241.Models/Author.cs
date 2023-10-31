using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEZ37S_HFT_2023241.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public Author(int id,string name, int yearofbirth)
        {
            Id = id;
            Name = name;
            YearOfBirth = yearofbirth;
            Books = new HashSet<Book>();

        }
        public Author()
        {
            Books = new HashSet<Book>();
        }
    }
}
