#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetTransport.Domain;
using PetTransport.Domain.Entities;
using PetTransport.Infrastructure.Data;
using PetTransport.Web.Commands.Transportations;
using Route = PetTransport.Domain.Entities.Route;

namespace PetTransport.Web.Controllers
{
    public class TransportationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public TransportationController(ApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
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
        public async Task<IActionResult> Create(CreateTransportationCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        // GET: Transportation/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportation = await _context.Transportations
                .Where(x=>x.Id == id)
                .Include(x=>x.Routes)
                .ThenInclude(x=>x.Car)
                .Select(x=> new UpdateTransportationCommand(x.Id, x.Title, x.Name, x.Description))
                .FirstOrDefaultAsync();
            
            
            ViewBag.Routes = await _context.Routes
                .Include(x=>x.Car).
                Where(x => x.TransportationId == transportation.Id).
                OrderBy(x=>x.Name).
                ToListAsync();
            
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
        public async Task<IActionResult> Edit(Guid id, UpdateTransportationCommand transportation)
        {
            
            if (id != transportation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(transportation);
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
            
            ViewBag.Routes = _context.Routes
                .Include(x=>x.Car).
                Where(x => x.TransportationId == transportation.Id).
                OrderBy(x=>x.Name).
                ToListAsync();

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
