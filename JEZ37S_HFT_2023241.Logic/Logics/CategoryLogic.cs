using JEZ37S_HFT_2023241.Logic.Interfaces;
using JEZ37S_HFT_2023241.Models;
using JEZ37S_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JEZ37S_HFT_2023241.Models.Book;
using static JEZ37S_HFT_2023241.Models.Category;

namespace JEZ37S_HFT_2023241.Logic.Logics
{
    public class CategoryLogic : ICategoryLogic
    {
        IRepository<Category> repo;

        public CategoryLogic(IRepository<Category> repo)
        {
            this.repo = repo;
        }

        public void Create(Category item)
        {
            if (item.Category_Name.Length < 2)
            {
                throw new ArgumentException("The name of the category is too short...");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Category Read(int id)
        {
            var category = repo.Read(id);
            if (category == null)
            {
                throw new ArgumentException($"{id} id does not exist");
            }
            return category;
        }

        public IQueryable<Category> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Category item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<HowManyBooksPerCategory> CountBooksPerCategory(string category)
        {
            return ReadAll()
                .Where(t => t.Category_Name == category)
                .SelectMany(t=>t.Books)
                .Where(t => t.Category.Category_Name.Equals(category))
                .Select(t => new HowManyBooksPerCategory()
                {
                    name = t.Name
                }) ;

        }

    }
}
