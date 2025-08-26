using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarterSystem_2024_back_up_.Data;
using BarterSystem_2024_back_up_.Models;
using Microsoft.AspNetCore.Authorization;


namespace BarterSystem_2024_back_up_.Controllers
{
    [Authorize]
    public class BarterItemsController : Controller
    {
        private readonly BarterSystem_2024_back_up_Context _context;

        public BarterItemsController(BarterSystem_2024_back_up_Context context)
        {
            _context = context;
        }

        // GET: BarterItems
        public async Task<IActionResult> Index()
        {
            var barterSystem_2024_back_up_Context = _context.BarterItems.Include(b => b.Owner);
            return View(await barterSystem_2024_back_up_Context.ToListAsync());
        }

        // GET: BarterItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barterItem = await _context.BarterItems
                .Include(b => b.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barterItem == null)
            {
                return NotFound();
            }

            return View(barterItem);
        }

        // GET: BarterItems/Create
        // Users & Admins can create
        [Authorize(Roles = "User,Admin")]
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            return View();
        }

        // POST: BarterItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Category,ImagePath,IsApproved,OwnerId,IsTraded")] BarterItem barterItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barterItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", barterItem.OwnerId);
            return View(barterItem);
        }

        // GET: BarterItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barterItem = await _context.BarterItems.FindAsync(id);
            if (barterItem == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", barterItem.OwnerId);
            return View(barterItem);
        }

        // POST: BarterItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Category,ImagePath,IsApproved,OwnerId,IsTraded")] BarterItem barterItem)
        {
            if (id != barterItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barterItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarterItemExists(barterItem.Id))
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
            ViewData["OwnerId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", barterItem.OwnerId);
            return View(barterItem);
        }

        // GET: BarterItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barterItem = await _context.BarterItems
                .Include(b => b.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barterItem == null)
            {
                return NotFound();
            }

            return View(barterItem);
        }

        // POST: BarterItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barterItem = await _context.BarterItems.FindAsync(id);
            if (barterItem != null)
            {
                _context.BarterItems.Remove(barterItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarterItemExists(int id)
        {
            return _context.BarterItems.Any(e => e.Id == id);
        }

        // Only Admin can approve
        [Authorize(Roles = "Admin")]
        public IActionResult Approve(int id)
        {
            // find item and mark approved
            return RedirectToAction(nameof(Index));
        }
    }
}
