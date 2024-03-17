using JEZ37S_HFT_2023241.Endpoint.Services;
using JEZ37S_HFT_2023241.Logic.Interfaces;
using JEZ37S_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using static JEZ37S_HFT_2023241.Models.Book;

namespace JEZ37S_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        IBookLogic Logic;
        IHubContext<SignalRHub> hub;

        public BookController(IBookLogic logic, IHubContext<SignalRHub> hub)
        {
            Logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("BookCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Book value)
        {
            this.Logic.Update(value);
            this.hub.Clients.All.SendAsync("BookUpdated", value);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var actorToDelete = this.Logic.Read(id);
            this.Logic.Delete(id);
            this.hub.Clients.All.SendAsync("BookDeleted", actorToDelete);

        }

    }
}
