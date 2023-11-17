using JEZ37S_HFT_2023241.Logic.Interfaces;
using JEZ37S_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JEZ37S_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryLogic Logic;

        public CategoryController(ICategoryLogic logic)
        {
            Logic = logic;
        }

        [HttpGet]
        public IEnumerable<Category> ReadAll()
        {
            return this.Logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Category Read(int id)
        {
            return this.Logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Category value)
        {
            this.Logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Category value)
        {
            this.Logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.Logic.Delete(id);
        }
    }
}

