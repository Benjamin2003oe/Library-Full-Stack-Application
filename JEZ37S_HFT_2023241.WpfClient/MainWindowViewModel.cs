﻿using JEZ37S_HFT_2023241.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using static JEZ37S_HFT_2023241.Models.Author;
using static JEZ37S_HFT_2023241.Models.Book;
using static JEZ37S_HFT_2023241.Models.Category;

namespace JEZ37S_HFT_2023241.WpfClient
{
    public class MainWindowViewModel: ObservableRecipient
    {
        #region Books
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
                }
            }
        }

        public ICommand CreateBookCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }
        public ICommand UpdateBookCommand { get; set; }

        #endregion 
        #region Authors
        public RestCollection<Author> Authors { get; set; }
        private Author selectedAuthor;

        public Author SelectedAuthor
        {
            get { return selectedAuthor; }
            set
            {
                if (value != null)
                {
                    selectedAuthor = new Author()
                    {
                        Name = value.Name,
                        Id = value.Id,
                    };
                    OnPropertyChanged();
                    (DeleteAuthorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateAuthorCommand { get; set; }
        public ICommand DeleteAuthorCommand { get; set; }
        public ICommand UpdateAuthorCommand { get; set; }

        #endregion 
        #region Category
        public RestCollection<Category> Categories { get; set; }
        private Category selectedCategory;

        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                if (value != null)
                {
                    selectedCategory = new Category()
                    {
                        Category_Name = value.Category_Name,
                        Id = value.Id,
                    };
                    OnPropertyChanged();
                    (DeleteCategoryCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateCategoryCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }
        public ICommand UpdateCategoryCommand { get; set; }

        #endregion
        #region NONCRUDS
        public ICommand Author1Command { get; set; }
        public ICommand Book1Command { get; set; }
        public ICommand Book2Command { get; set; }
        public ICommand Category1Command { get; set; }

        //Author
        public List<BooksWrittenbyAuthor> Author1Collection { get; set; }
        public ObservableCollection<BooksWrittenbyAuthor> Author1ObservableCollection { get; set; }

        //Book
        public List<AuthorsBornYear> Book1Collection { get; set; }
        public ObservableCollection<AuthorsBornYear> Book1ObservableCollection { get; set; }
 
        public List<WhoReservedThisBook> Book2Collection { get; set; }
        public ObservableCollection<WhoReservedThisBook> Book2ObservableCollection { get; set; }

        //Category
        public List<HowManyBooksPerCategory> Category1Collection { get; set; }
        public ObservableCollection<HowManyBooksPerCategory> Cattegory1ObservableCollection { get; set; }
        #endregion


        public MainWindowViewModel()
        {
            #region Books
            Books = new RestCollection<Book>("http://localhost:13009/", "book", "hub");
            CreateBookCommand = new RelayCommand(() =>
            {
                Books.Add(new Book()
                {
                    Name = SelectedBook.Name
                });
            });

            UpdateBookCommand = new RelayCommand(() =>
            {
                Books.Update(SelectedBook);
            });

            DeleteBookCommand = new RelayCommand(() =>
            {
                Books.Delete(SelectedBook.Id);
            }, 
            () =>
            {
                return  SelectedBook != null;
            });
            SelectedBook = new Book();
            #endregion
            #region Authors
            Authors = new RestCollection<Author>("http://localhost:13009/", "author", "hub");
            CreateAuthorCommand = new RelayCommand(() =>
            {
                Authors.Add(new Author()
                {
                    Name = SelectedAuthor.Name
                });
            });

            UpdateAuthorCommand = new RelayCommand(() =>
            {
                Authors.Update(SelectedAuthor);
            });

            DeleteAuthorCommand = new RelayCommand(() =>
            {
                Authors.Delete(SelectedAuthor.Id);
            },
            () =>
            {
                return SelectedAuthor != null;
            });
            SelectedAuthor = new Author();
            #endregion
            #region Categories
            Categories = new RestCollection<Category>("http://localhost:13009/", "category", "hub");
            CreateCategoryCommand = new RelayCommand(() =>
            {
                Categories.Add(new Category()
                {
                    Category_Name = SelectedCategory.Category_Name
                });
            });

            UpdateCategoryCommand = new RelayCommand(() =>
            {
                Categories.Update(SelectedCategory);
            });

            DeleteCategoryCommand = new RelayCommand(() =>
            {
                Categories.Delete(SelectedCategory.Id);
            },
            () =>
            {
                return SelectedCategory != null;
            });
            SelectedCategory = new Category();
            #endregion
            #region NONCRUDS
            #endregion
        }
    }
}
