using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly InMemItemsRepository repository;

        public ItemController()
        {
            repository = new InMemItemsRepository();

        }

        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }
    }
}
