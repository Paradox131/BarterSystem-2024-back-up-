using BarterSystem_2024_back_up_.Data;
using BarterSystem_2024_back_up_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarterSystem_2024_back_up_.Controllers
{
    public class SwapsController : Controller
    {
        private readonly BarterSystem_2024_back_up_Context _context;

        public SwapsController(BarterSystem_2024_back_up_Context context)
        {
            _context = context;
        }

        // GET: Swaps
        public async Task<IActionResult> Index()
        {
            var barterSystem_2024_back_up_Context = _context.Swaps.Include(s => s.OfferedItem).Include(s => s.RequestedItem);
            return View(await barterSystem_2024_back_up_Context.ToListAsync());
        }

        // GET: Swaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var swap = await _context.Swaps
                .Include(s => s.OfferedItem)
                .Include(s => s.RequestedItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (swap == null)
            {
                return NotFound();
            }

            return View(swap);
        }

        // GET: Swaps/Create
        [Authorize(Roles = "User,Admin")]
        public IActionResult Create()
        {
            ViewData["OfferedItemId"] = new SelectList(_context.BarterItems, "Id", "Title");
            ViewData["RequestedItemId"] = new SelectList(_context.BarterItems, "Id", "Title");
            return View();
        }

        // POST: Swaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OfferedItemId,RequestedItemId,Status")] Swap swap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(swap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OfferedItemId"] = new SelectList(_context.BarterItems, "Id", "Title", swap.OfferedItemId);
            ViewData["RequestedItemId"] = new SelectList(_context.BarterItems, "Id", "Title", swap.RequestedItemId);
            return View(swap);
        }

        // GET: Swaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var swap = await _context.Swaps.FindAsync(id);
            if (swap == null)
            {
                return NotFound();
            }
            ViewData["OfferedItemId"] = new SelectList(_context.BarterItems, "Id", "Title", swap.OfferedItemId);
            ViewData["RequestedItemId"] = new SelectList(_context.BarterItems, "Id", "Title", swap.RequestedItemId);
            return View(swap);
        }

        // POST: Swaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OfferedItemId,RequestedItemId,Status")] Swap swap)
        {
            if (id != swap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(swap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SwapExists(swap.Id))
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
            ViewData["OfferedItemId"] = new SelectList(_context.BarterItems, "Id", "Title", swap.OfferedItemId);
            ViewData["RequestedItemId"] = new SelectList(_context.BarterItems, "Id", "Title", swap.RequestedItemId);
            return View(swap);
        }

        // GET: Swaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var swap = await _context.Swaps
                .Include(s => s.OfferedItem)
                .Include(s => s.RequestedItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (swap == null)
            {
                return NotFound();
            }

            return View(swap);
        }

        // POST: Swaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var swap = await _context.Swaps.FindAsync(id);
            if (swap != null)
            {
                _context.Swaps.Remove(swap);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SwapExists(int id)
        {
            return _context.Swaps.Any(e => e.Id == id);
        }

        [Authorize(Roles = "User,Admin")]
        public IActionResult Accept(int id)
        {
            var swap = _context.Swaps.Find(id);
            if (swap != null)
            {
                swap.Status = "Accepted";
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "User,Admin")]
        public IActionResult Decline(int id)
        {
            var swap = _context.Swaps.Find(id);
            if (swap != null)
            {
                swap.Status = "Declined";
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
