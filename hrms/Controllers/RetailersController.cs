using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hrms.Data;
using hrms.Models;

namespace hrms.Controllers
{
    public class RetailersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RetailersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Retailers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Retailer.ToListAsync());
        }

        // GET: Retailers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retailer = await _context.Retailer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retailer == null)
            {
                return NotFound();
            }

            return View(retailer);
        }

        // GET: Retailers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Retailers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Name,ManufacturingDate,ExpiryDate,SerialNo,CompanyCRN")] Retailer retailer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(retailer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(retailer);
        }

        // GET: Retailers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retailer = await _context.Retailer.FindAsync(id);
            if (retailer == null)
            {
                return NotFound();
            }
            return View(retailer);
        }

        // POST: Retailers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Name,ManufacturingDate,ExpiryDate,SerialNo,CompanyCRN")] Retailer retailer)
        {
            if (id != retailer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retailer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RetailerExists(retailer.Id))
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
            return View(retailer);
        }

        // GET: Retailers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retailer = await _context.Retailer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retailer == null)
            {
                return NotFound();
            }

            return View(retailer);
        }

        // POST: Retailers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var retailer = await _context.Retailer.FindAsync(id);
            if (retailer != null)
            {
                _context.Retailer.Remove(retailer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RetailerExists(int id)
        {
            return _context.Retailer.Any(e => e.Id == id);
        }
    }
}
