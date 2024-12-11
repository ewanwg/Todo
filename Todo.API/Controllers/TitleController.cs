using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.API.Data;
using Todo.API.Entities;

namespace Todo.API.Controllers
{
    [Route("api/listtitle")]
    public class TitleController : ControllerBase
    {
        private readonly TodoContext _context;

        public TitleController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListTitle>>> GetListTitles()
        {
            var a = await _context.ListTitles.Include(lt => lt.Items).ToListAsync();

            return a;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ListTitle>> GetListTitle(int id)
        {
            var listTitle = await _context.ListTitles.Include(lt => lt.Items).FirstOrDefaultAsync(lt => lt.Id == id);

            if (listTitle == null)
                return NotFound();

            return listTitle;
        }

        [HttpPost]
        public async Task<ActionResult<ListTitle>> CreateListTitle(ListTitle listTitle)
        {
            _context.ListTitles.Add(listTitle);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetListTitle), new { id = listTitle.Id }, listTitle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateListTitle(int id, ListTitle listTitle)
        {
            if (id != listTitle.Id)
            {
                return BadRequest();
            }

            _context.Entry(listTitle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ListTitles.Any(e => e.Id == id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListTitle(int id)
        {
            var listTitle = await _context.ListTitles.FindAsync(id);
            if (listTitle == null)
            {
                return NotFound();
            }

            _context.ListTitles.Remove(listTitle);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
