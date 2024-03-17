using JEZ37S_HFT_2023241.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace JEZ37S_HFT_2023241.WpfClient
{
    public class MainWindowViewModel: ObservableRecipient
    {
        public RestCollection<Book> Books { get; set; }
        private Book selectedBook;

        public Book SelectedBook
        {
            get { return selectedBook; }
            set 
            {
                if (value != null)
                {
                    selectedBook = new Book()
                    {
                        Name = value.Name,
                        Id = value.Id,
                    };
                    OnPropertyChanged();
                    (DeleteBookCommand as RelayCommand).NotifyCanExecuteChanged();
                    //Nem updatelodik vmiert
                }
            }
        }

        public ICommand CreateBookCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }
        public ICommand UpdateBookCommand { get; set; }


        public MainWindowViewModel()
        {
            Books = new RestCollection<Book>("http://localhost:13009/", "book");
            CreateBookCommand = new RelayCommand(() =>
            {
                Books.Add(new Book()
                {
                    Name = "Jóskönyv"
                });
            });

            UpdateBookCommand = new RelayCommand(() =>
            {

            });

            DeleteBookCommand = new RelayCommand(() =>
            {
                Books.Delete(SelectedBook.Id);
            }, 
            () =>
            {
                return  SelectedBook != null;
            });
        }
    }
}
