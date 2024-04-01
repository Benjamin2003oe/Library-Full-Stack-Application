using JEZ37S_HFT_2023241.Endpoint.Services;
using JEZ37S_HFT_2023241.Logic.Interfaces;
using JEZ37S_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JEZ37S_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IAuthorLogic Logic;
        IHubContext<SignalRHub> hub;

        public AuthorController(IAuthorLogic logic ,IHubContext<SignalRHub> hub)
        {
            Logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Author> ReadAll()
        {
            return this.Logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Author Read(int id)
        {
            return this.Logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Author value)
        {
            this.Logic.Create(value);
            this.hub.Clients.All.SendAsync("AuthorCreated", value);

        }

        [HttpPut]
        public void Update([FromBody] Author value)
        {
            this.Logic.Update(value);
            this.hub.Clients.All.SendAsync("AuthorUpdated", value);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var authorToDelete = this.Logic.Read(id);
            this.Logic.Delete(id);
            this.hub.Clients.All.SendAsync("AuthorDeleted", authorToDelete);

        }
    }
}
