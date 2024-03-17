using JEZ37S_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEZ37S_HFT_2023241.WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Book> Books { get; set; }

        public MainWindowViewModel()
        {
            Books = new RestCollection<Book>("http://localhost:13009/", "book");
        }
    }
}
