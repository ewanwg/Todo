using Microsoft.EntityFrameworkCore;
using Todo.API.Data;
using Todo.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Todo.API.Entities;

namespace Todo.API.DTOs
{
    public class ListItemDataService
    {
        private readonly TodoContext _context;

        public ListItemDataService(TodoContext context) 
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<ListItemDTO>>> GetAllListItems()
        {
            return await _context.ListItems
                                 .Select(item => ListItemDTO.MapToDTO(item))
                                 .ToListAsync();
        }

        public async Task<ActionResult<ListItemDTO>> GetListItemId(int id)
        {
            var listItem = await _context.ListItems.FindAsync(id);

            return ListItemDTO.MapToDTO(listItem);
        }

        public async Task<ActionResult<IEnumerable<ListItemDTO>>> GetItemsByListTitleId(int listTitleId)
        {
            var items = await _context.ListItems
                                      .Where(li => li.ListTitleId == listTitleId)
                                      .Select(item => ListItemDTO.MapToDTO(item))
                                      .ToListAsync();
            return (items);
        }

        public async Task<ActionResult<ListItemDTO>> CreateListItem(ListItemDTO listItemDTO)
        {
            _context.ListItems.Add(ListItem.MapToEntity(listItemDTO));
            await _context.SaveChangesAsync();

            return (listItemDTO);
        }

        public async Task<ActionResult<ListItemDTO>> UpdateListItem(int id, ListItemDTO listItemDTO)
        {
            _context.Entry(ListItem.MapToEntity(listItemDTO)).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return (listItemDTO);
        }

        public async Task<IActionResult> ToggleComplete(int id)
        {
            var listItem = await _context.ListItems.FindAsync(id);

            listItem.IsComplete = !listItem.IsComplete;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}