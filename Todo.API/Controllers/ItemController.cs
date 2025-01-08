using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.API.Data;
using Todo.API.DTOs;
using Todo.API.Entities;

namespace Todo.API.Controllers
{
    [Route("api/listitem")]
    public class ItemController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly ListItemDataService _itemDataService;

        public ItemController(TodoContext context, ListItemDataService itemDataService)
        {
            _context = context;
            _itemDataService = itemDataService;
        }

        // GET: api/ListItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListItemDTO>>> GetListItems()
        {
            var items = await _itemDataService.GetAllListItems();
            return Ok(items);
        }

        // GET: api/ListItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListItemDTO>> GetListItem(int id)
        {
            var listItem = await _itemDataService.GetListItemId(id);
            return Ok(listItem);

        }

        // GET: api/ListItem/byListTitle/1
        [HttpGet("byListTitle/{listTitleId}")]
        public async Task<ActionResult<IEnumerable<ListItem>>> GetItemsByListTitle(int listTitleId)
        {
            var items = await _context.ListItems
                                      .Where(li => li.ListTitleId == listTitleId)
                                      .ToListAsync();

            return items;
        }

        // POST: api/ListItem
        [HttpPost]
        public async Task<ActionResult<ListItem>> CreateListItem(ListItem listItem)
        {
            if (!_context.ListTitles.Any(lt => lt.Id == listItem.ListTitleId))
            {
                return BadRequest("Invalid ListTitleId.");
            }

            _context.ListItems.Add(listItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetListItem), new { id = listItem.Id }, listItem);
        }

        // PUT: api/ListItem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateListItem(int id, ListItem listItem)
        {
            if (id != listItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(listItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PATCH: api/ListItem/5/toggleComplete
        [HttpPatch("{id}/toggleComplete")]
        public async Task<IActionResult> ToggleComplete(int id)
        {
            var listItem = await _context.ListItems.FindAsync(id);
            if (listItem == null)
            {
                return NotFound();
            }

            listItem.IsComplete = !listItem.IsComplete;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ListItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListItem(int id)
        {
            var listItem = await _context.ListItems.FindAsync(id);
            if (listItem == null)
            {
                return NotFound();
            }

            _context.ListItems.Remove(listItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListItemExists(int id)
        {
            return _context.ListItems.Any(e => e.Id == id);
        }
    }
}
