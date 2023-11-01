using JEZ37S_HFT_2023241.Models;
using JEZ37S_HFT_2023241.Repository.DataBase;
using JEZ37S_HFT_2023241.Repository.GenericRepository;
using JEZ37S_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEZ37S_HFT_2023241.Repository.ModelRepositories
{
    internal class AuthorRepository : Repository<Author>, IRepository<Author>
    {
        public AuthorRepository(LibraryDbContext ctx) : base(ctx)
        {
        }

        public override Author Read(int id)
        {
            return ctx.Authors.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Author item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
