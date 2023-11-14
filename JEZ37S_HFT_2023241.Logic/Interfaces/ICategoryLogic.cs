using JEZ37S_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;
using static JEZ37S_HFT_2023241.Models.Category;

namespace JEZ37S_HFT_2023241.Logic.Interfaces
{
    public interface ICategoryLogic
    {
        public IEnumerable<HowManyBooksPerCategory> CountBooksPerCategory(string category);
        void Create(Category item);
        void Delete(int id);
        Category Read(int id);
        IQueryable<Category> ReadAll();
        void Update(Category item);
    }
}