using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WasagaRFC.Data;
using WasagaRFC.Models;
using System.Threading.Tasks;

namespace WasagaRFC.Controllers
{
    public class StartersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StartersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StartersController
        public async Task<IActionResult> Index()
        {
            var starters = await _context.Starters.ToListAsync();
            return View(starters);
        }

        // GET: StartersController/Details/5
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

        // GET: StartersController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StartersController/Create
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
            return View(starters);
        }

        // GET: StartersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var starter = await _context.Starters.FindAsync(id);
            if (starter == null)
            {
                return NotFound();
            }
            return View(starter);
        }

        // POST: StartersController/Edit/5
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
            return View(starters);
        }

        // GET: StartersController/Delete/5
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

        // POST: StartersController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var starter = await _context.Starters.FindAsync(id);
            _context.Starters.Remove(starter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StartersExists(int id)
        {
            return _context.Starters.Any(e => e.StarterId == id);
        }
    }
}
