using ApiProjectEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class MenusController : ControllerBase
{
    private readonly ApiProjectContext _context;

    public MenusController(ApiProjectContext context)
    {
        _context = context;
    }

    // GET: api/menus
    [HttpGet]
    public ActionResult<IEnumerable<Menu>> GetMenus()
    {
        return _context.Menus.ToList();
    }

    // GET: api/menus/5
    [HttpGet("{id}")]
    public ActionResult<Menu> GetMenu(int id)
    {
        var menu = _context.Menus.Find(id);

        if (menu == null)
        {
            return NotFound();
        }

        return menu;
    }

    // POST: api/menus
    [HttpPost]
    public ActionResult<Menu> CreateMenu(Menu menu)
    {
        _context.Menus.Add(menu);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMenu), new { id = menu.MenuId }, menu);
    }

    // PUT: api/menus/5
    [HttpPut("{id}")]
    public IActionResult UpdateMenu(int id, Menu menu)
    {
        if (id != menu.MenuId)
        {
            return BadRequest();
        }

        _context.Entry(menu).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/menus/5
    [HttpDelete("{id}")]
    public IActionResult DeleteMenu(int id)
    {
        var menu = _context.Menus.Find(id);

        if (menu == null)
        {
            return NotFound();
        }

        _context.Menus.Remove(menu);
        _context.SaveChanges();

        return NoContent();
    }
}
