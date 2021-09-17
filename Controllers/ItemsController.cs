using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());

            return items;
        }

        [HttpGet("id/{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItemById(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }
        [HttpGet("name/{name}")]
        public ActionResult<ItemDto> GetItemByName(String name)
        {
            var item = repository.GetItemByName(name);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        [HttpPut("id/{id}")]
        public ActionResult UpdateItemById(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItemById(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price,
            };

            repository.UpdateItemById(updatedItem);

            return NoContent();
        }
        [HttpPut("name/{name}")]
        public ActionResult UpdateItemByName(String name, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItemByName(name);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price,
            };

            repository.UpdateItemByName(updatedItem);

            return NoContent();
        }

        [HttpDelete("id/{id}")]
        public ActionResult DeleteItemById(Guid id)
        {
            var existingItem = repository.GetItemById(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            repository.DeleteItemById(id);

            return NoContent();
        }
        [HttpDelete("name/{name}")]
        public ActionResult DeleteItemByName(String name)
        {
            var existingItem = repository.GetItemByName(name);

            if (existingItem is null)
            {
                return NotFound();
            }

            repository.DeleteItemByName(name);

            return NoContent();
        }
    }
}