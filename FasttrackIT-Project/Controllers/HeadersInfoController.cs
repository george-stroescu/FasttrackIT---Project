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
    public class HeadersInfoController : Controller
    {
        private readonly ProjectDbContext _context;

        public HeadersInfoController(ProjectDbContext context)
        {
            _context = context;
        }

        // GET: HeadersInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.HeaderInfo.ToListAsync());
        }

        // GET: HeadersInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headerInfo = await _context.HeaderInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headerInfo == null)
            {
                return NotFound();
            }

            return View(headerInfo);
        }

        // GET: HeadersInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HeadersInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,Date,Discount,ExpiryDate")] HeaderInfo headerInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(headerInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(headerInfo);
        }

        // GET: HeadersInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headerInfo = await _context.HeaderInfo.FindAsync(id);
            if (headerInfo == null)
            {
                return NotFound();
            }
            return View(headerInfo);
        }

        // POST: HeadersInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,Date,Discount,ExpiryDate")] HeaderInfo headerInfo)
        {
            if (id != headerInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(headerInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeaderInfoExists(headerInfo.Id))
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
            return View(headerInfo);
        }

        // GET: HeadersInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headerInfo = await _context.HeaderInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headerInfo == null)
            {
                return NotFound();
            }

            return View(headerInfo);
        }

        // POST: HeadersInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var headerInfo = await _context.HeaderInfo.FindAsync(id);
            _context.HeaderInfo.Remove(headerInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeaderInfoExists(int id)
        {
            return _context.HeaderInfo.Any(e => e.Id == id);
        }
    }
}
