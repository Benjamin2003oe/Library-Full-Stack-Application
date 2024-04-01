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
    public class CategoryController : ControllerBase
    {
        ICategoryLogic Logic;
        IHubContext<SignalRHub> hub;

        public CategoryController(ICategoryLogic logic, IHubContext<SignalRHub> hub)
        {
            Logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("CategoryCreated", value);

        }

        [HttpPut]
        public void Update([FromBody] Category value)
        {
            this.Logic.Update(value);
            this.hub.Clients.All.SendAsync("CategoryUpdated", value);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var categoryToDelete = this.Logic.Read(id);
            this.Logic.Delete(id);
            this.hub.Clients.All.SendAsync("CategoryDeleted", categoryToDelete);

        }
    }
}

