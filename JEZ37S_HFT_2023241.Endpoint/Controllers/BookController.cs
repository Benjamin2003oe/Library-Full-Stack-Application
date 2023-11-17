using JEZ37S_HFT_2023241.Logic.Interfaces;
using JEZ37S_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JEZ37S_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        IBookLogic Logic;

        public BookController(IBookLogic logic)
        {
            Logic = logic;
        }

        [HttpGet]
        public IEnumerable<Book> ReadAll()
        {
            return this.Logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Book Read(int id)
        {
            return this.Logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Book value)
        {
            this.Logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Book value)
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
