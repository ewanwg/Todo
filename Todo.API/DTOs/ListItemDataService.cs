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
            return await _context.ListItems.Select(item => ListItemDTO.MapToDTO(item)).ToListAsync();
        }

        public async Task<ActionResult<ListItemDTO>> GetListItemId(int id)
        {
            var listItem = await _context.ListItems.FindAsync(id);

            return ListItemDTO.MapToDTO(listItem);
        }
    }
}