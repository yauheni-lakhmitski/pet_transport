// #nullable disable
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using PetTransport.Infrastructure.Data;
// using PetTransport.Web.Commands.Routes;
// using Route = PetTransport.Domain.Entities.Route;
//
// namespace PetTransport.Web.Controllers
// {
//     public class RouteController : Controller
//     {
//         private readonly ApplicationDbContext _context;
//         private readonly IMediator _mediator;
//
//         public RouteController(ApplicationDbContext context, IMediator mediator)
//         {
//             _context = context;
//             _mediator = mediator;
//         }
//
//         // GET: Route
//         public async Task<IActionResult> Index()
//         {
//             var applicationDbContext = _context.Routes
//                 .Include(r => r.Car)
//                 .Include(r => r.Transportation)
//                 .Include(x=>x.Driver);
//             return View(await applicationDbContext.ToListAsync());
//         }
//
//         // GET: Route/Details/5
//         public async Task<IActionResult> Details(Guid? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//
//             var route = await _context.Routes
//                 .Include(r => r.Car)
//                 .Include(r => r.Transportation)
//                 .FirstOrDefaultAsync(m => m.Id == id);
//             if (route == null)
//             {
//                 return NotFound();
//             }
//
//             return View(route);
//         }
//
//         // GET: Route/Create
//         public async Task<IActionResult> Create(Guid transportationId)
//         {
//             var drivers = await _context.Users.ToListAsync();
//             var driversViewModel = drivers.Select(x => new DriverViewModel(x.Id, $"{x.FirstName} {x.LastName}"));
//             ViewData["DriverId"] = new SelectList(driversViewModel, "Id", "Name");
//             
//             var cars = await _context.Cars.ToListAsync();
//             var carsViewModels = cars.Select(x => new CarViewModel(x.Id, $"{x.Make} {x.Model} {x.RegistrationNumber}"));
//             ViewData["CarId"] = new SelectList(carsViewModels, "Id", "Name");
//             ViewData["TransportationId"] = transportationId;
//             return View();
//         }
//
//         public record DriverViewModel(string Id, string Name);
//
//         public record CarViewModel(Guid Id, string Name);
//
//         // POST: Route/Create
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Create(CreateRouteCommand command)
//         {
//             if (ModelState.IsValid)
//             {
//                 await _mediator.Send(command);
//                 return RedirectToAction(nameof(Index));
//             }
//             
//             var drivers = await _context.Users.ToListAsync();
//             var driversViewModel = drivers.Select(x => new DriverViewModel(x.Id, $"{x.FirstName} {x.LastName}"));
//             ViewData["DriverId"] = new SelectList(driversViewModel, "Id", "Name", command.DriverId);
//             
//             var cars = await _context.Cars.ToListAsync();
//             var carsViewModels = cars.Select(x => new CarViewModel(x.Id, $"{x.Make} {x.Model} {x.RegistrationNumber}"));
//             ViewData["CarId"] = new SelectList(carsViewModels, "Id", "Name", command.CarId);
//             
//             ViewData["TransportationId"] = new SelectList(_context.Transportations, "Id", "Description", command.TransportationId);
//             return View(command);
//         }
//
//         // GET: Route/Edit/5
//         public async Task<IActionResult> Edit(Guid? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//
//             var route = await _context.Routes.FindAsync(id);
//             if (route == null)
//             {
//                 return NotFound();
//             }
//             var drivers = await _context.Users.ToListAsync();
//             var driversViewModel = drivers.Select(x => new DriverViewModel(x.Id, $"{x.FirstName} {x.LastName}"));
//             ViewData["DriverId"] = new SelectList(driversViewModel, "Id", "Name", route.DriverId);
//             
//             var cars = await _context.Cars.ToListAsync();
//             var carsViewModels = cars.Select(x => new CarViewModel(x.Id, $"{x.Make} {x.Model} {x.RegistrationNumber}"));
//             ViewData["CarId"] = new SelectList(carsViewModels, "Id", "Name");
//             ViewData["TransportationId"] = new SelectList(_context.Transportations, "Id", "Description", route.TransportationId);
//             return View(route);
//         }
//
//         // POST: Route/Edit/5
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Source,Destination,CarId,TransportationId,StartTime,EndTime")] Route route)
//         {
//             if (id != route.Id)
//             {
//                 return NotFound();
//             }
//
//             if (ModelState.IsValid)
//             {
//                 try
//                 {
//                     _context.Update(route);
//                     await _context.SaveChangesAsync();
//                 }
//                 catch (DbUpdateConcurrencyException)
//                 {
//                     if (!RouteExists(route.Id))
//                     {
//                         return NotFound();
//                     }
//                     else
//                     {
//                         throw;
//                     }
//                 }
//                 return RedirectToAction(nameof(Index));
//             }
//             var drivers = await _context.Users.ToListAsync();
//             var driversViewModel = drivers.Select(x => new DriverViewModel(x.Id, $"{x.FirstName} {x.LastName}"));
//             ViewData["DriverId"] = new SelectList(driversViewModel, "Id", "Name", route.DriverId);
//             
//             var cars = await _context.Cars.ToListAsync();
//             var carsViewModels = cars.Select(x => new CarViewModel(x.Id, $"{x.Make} {x.Model} {x.RegistrationNumber}"));
//             ViewData["CarId"] = new SelectList(carsViewModels, "Id", "Name", route.CarId);
//             ViewData["TransportationId"] = new SelectList(_context.Transportations, "Id", "Description", route.TransportationId);
//             
//             return View(route);
//         }
//
//         // GET: Route/Delete/5
//         public async Task<IActionResult> Delete(Guid? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//
//             var route = await _context.Routes
//                 .Include(r => r.Car)
//                 .Include(r => r.Transportation)
//                 .FirstOrDefaultAsync(m => m.Id == id);
//             if (route == null)
//             {
//                 return NotFound();
//             }
//
//             return View(route);
//         }
//
//         // POST: Route/Delete/5
//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> DeleteConfirmed(Guid id)
//         {
//             var route = await _context.Routes.FindAsync(id);
//             _context.Routes.Remove(route);
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//         }
//
//         private bool RouteExists(Guid id)
//         {
//             return _context.Routes.Any(e => e.Id == id);
//         }
//     }
// }
