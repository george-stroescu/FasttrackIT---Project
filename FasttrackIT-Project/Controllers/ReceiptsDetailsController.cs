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
    public class ReceiptsDetailsController : Controller
    {
        private readonly ProjectDbContext _context;

        public ReceiptsDetailsController(ProjectDbContext context)
        {
            _context = context;
        }

        // GET: ReceiptsDetails
        public async Task<IActionResult> Index()
        {
            var projectDbContext = _context.ReceiptDetails.Include(r => r.Product);
            return View(await projectDbContext.ToListAsync());
        }

        // GET: ReceiptsDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptDetails = await _context.ReceiptDetails
                .Include(r => r.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receiptDetails == null)
            {
                return NotFound();
            }

            return View(receiptDetails);
        }

        // GET: ReceiptsDetails/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName");
            return View();
        }

        // POST: ReceiptsDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HeaderInfoId,ProductId")] ReceiptDetails receiptDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receiptDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", receiptDetails.ProductId);
            return View(receiptDetails);
        }

        // GET: ReceiptsDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptDetails = await _context.ReceiptDetails.FindAsync(id);
            if (receiptDetails == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", receiptDetails.ProductId);
            return View(receiptDetails);
        }

        // POST: ReceiptsDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HeaderInfoId,ProductId")] ReceiptDetails receiptDetails)
        {
            if (id != receiptDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receiptDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptDetailsExists(receiptDetails.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", receiptDetails.ProductId);
            return View(receiptDetails);
        }

        // GET: ReceiptsDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptDetails = await _context.ReceiptDetails
                .Include(r => r.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receiptDetails == null)
            {
                return NotFound();
            }

            return View(receiptDetails);
        }

        // POST: ReceiptsDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receiptDetails = await _context.ReceiptDetails.FindAsync(id);
            _context.ReceiptDetails.Remove(receiptDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptDetailsExists(int id)
        {
            return _context.ReceiptDetails.Any(e => e.Id == id);
        }
    }
}
