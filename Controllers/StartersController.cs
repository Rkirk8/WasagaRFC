using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WasagaRFC.Data;
using WasagaRFC.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WasagaRFC.Controllers
{
    public class StartersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StartersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Starters
        [AllowAnonymous]  // Allow anonymous users to view the index
        public async Task<IActionResult> Index()
        {
            var starters = await _context.Starters.ToListAsync();
            return View(starters);
        }

        // GET: Starters/Details/5
        [AllowAnonymous]  // Allow anonymous users to view the details
        public async Task<IActionResult> Details(int id)
        {
            var starter = await _context.Starters
                .FirstOrDefaultAsync(m => m.StarterId == id);

            if (starter == null)
            {
                return NotFound();
            }

            return View(starter);
        }

        // GET: Starters/Create
        public IActionResult Create()
        {
            PopulatePlayersDropDownList();
            return View();
        }

        // POST: Starters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StarterId,Prop1,Prop2,Hooker,Lock1,Lock2,Flanker1,Flanker2,Number8,ScrumHalf,FlyHalf,Center1,Center2,Wing1,Wing2,FullBack,PlayerId")] Starters starters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(starters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulatePlayersDropDownList(starters.PlayerId); // Populate dropdown again if validation fails
            return View(starters);
        }

        // GET: Starters/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var starter = await _context.Starters.FindAsync(id);
            if (starter == null)
            {
                return NotFound();
            }

            PopulatePlayersDropDownList(starter.PlayerId); // Passing only the PlayerId for dropdowns
            return View(starter);
        }

        // POST: Starters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StarterId,Prop1,Prop2,Hooker,Lock1,Lock2,Flanker1,Flanker2,Number8,ScrumHalf,FlyHalf,Center1,Center2,Wing1,Wing2,FullBack,PlayerId")] Starters starters)
        {
            if (id != starters.StarterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(starters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StartersExists(starters.StarterId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            PopulatePlayersDropDownList(starters.PlayerId); // Populate dropdown again if validation fails
            return View(starters);
        }

        // GET: Starters/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var starter = await _context.Starters
                .FirstOrDefaultAsync(m => m.StarterId == id);

            if (starter == null)
            {
                return NotFound();
            }

            return View(starter);
        }

        // POST: Starters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var starter = await _context.Starters.FindAsync(id);
            if (starter != null)
            {
                _context.Starters.Remove(starter);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // Helper method to populate the player dropdown lists
        private void PopulatePlayersDropDownList(object selectedPlayer = null)
        {
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
            ViewData["Prop1"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
            ViewData["Prop2"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
            ViewData["Hooker"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
            ViewData["Lock1"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
            ViewData["Lock2"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
            ViewData["Flanker1"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
            ViewData["Flanker2"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
            ViewData["Number8"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
            ViewData["ScrumHalf"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
            ViewData["FlyHalf"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
            ViewData["Center1"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
            ViewData["Center2"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
            ViewData["Wing1"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
            ViewData["Wing2"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
            ViewData["FullBack"] = new SelectList(_context.Players, "Id", "Name", selectedPlayer);
        }

        private bool StartersExists(int id)
        {
            return _context.Starters.Any(e => e.StarterId == id);
        }
    }
}
