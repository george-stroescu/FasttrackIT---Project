using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FasttrackIT_Project.Data;
using FasttrackIT_Project.Models;

namespace FasttrackIT_Project.Controllers
{
    public class OfferHeadersController : Controller
    {
        private readonly ProjectDbContext _context;

        public OfferHeadersController(ProjectDbContext context)
        {
            _context = context;
        }

        // GET: OfferHeaders
        public async Task<IActionResult> Index()
        {
            return View(await _context.OfferHeader.ToListAsync());
        }

        // GET: OfferHeaders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerHeader = await _context.OfferHeader
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offerHeader == null)
            {
                return NotFound();
            }

            return View(offerHeader);
        }

        // GET: OfferHeaders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfferHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Discount,ExpiryDate")] OfferHeader offerHeader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offerHeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(offerHeader);
        }

        // GET: OfferHeaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerHeader = await _context.OfferHeader.FindAsync(id);
            if (offerHeader == null)
            {
                return NotFound();
            }
            return View(offerHeader);
        }

        // POST: OfferHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Discount,ExpiryDate")] OfferHeader offerHeader)
        {
            if (id != offerHeader.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offerHeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferHeaderExists(offerHeader.Id))
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
            return View(offerHeader);
        }

        // GET: OfferHeaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerHeader = await _context.OfferHeader
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offerHeader == null)
            {
                return NotFound();
            }

            return View(offerHeader);
        }

        // POST: OfferHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offerHeader = await _context.OfferHeader.FindAsync(id);
            _context.OfferHeader.Remove(offerHeader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfferHeaderExists(int id)
        {
            return _context.OfferHeader.Any(e => e.Id == id);
        }
    }
}
