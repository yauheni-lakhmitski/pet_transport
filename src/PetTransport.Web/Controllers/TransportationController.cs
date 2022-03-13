#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetTransport.Domain;
using PetTransport.Infrastructure.Data;

namespace PetTransport.Web.Controllers
{
    public class TransportationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransportationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transportation
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transportations.ToListAsync());
        }

        // GET: Transportation/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation = await _context.Transportations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportation == null)
            {
                return NotFound();
            }

            return View(transportation);
        }

        // GET: Transportation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transportation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Name,Description,CreatedAt,UpdatedAt")] Transportation transportation)
        {
            if (ModelState.IsValid)
            {
                transportation.Id = Guid.NewGuid();
                _context.Add(transportation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transportation);
        }

        // GET: Transportation/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation = await _context.Transportations
                .Include(x=>x.Routes)
                .ThenInclude(x=>x.Car)
                .FirstOrDefaultAsync(x=>x.Id == id);
            if (transportation == null)
            {
                return NotFound();
            }
            return View(transportation);
        }

        // POST: Transportation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Name,Description,CreatedAt,UpdatedAt")] Transportation transportation)
        {
            if (id != transportation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportationExists(transportation.Id))
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
            return View(transportation);
        }

        // GET: Transportation/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation = await _context.Transportations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportation == null)
            {
                return NotFound();
            }

            return View(transportation);
        }

        // POST: Transportation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var transportation = await _context.Transportations.FindAsync(id);
            _context.Transportations.Remove(transportation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportationExists(Guid id)
        {
            return _context.Transportations.Any(e => e.Id == id);
        }
    }
}
