using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FactoryProduction.Models;

namespace FactoryProduction.Controllers
{
    public class ReleacePlansController : Controller
    {
        private readonly ApplicationContext _context;

        public ReleacePlansController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ReleacePlans
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.ReleacePlan.Include(r => r.Product);
            return View(await applicationContext.ToListAsync());
        }

        // GET: ReleacePlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var releacePlan = await _context.ReleacePlan
                .Include(r => r.Product)
                .SingleOrDefaultAsync(m => m.ReleacePlanId == id);
            if (releacePlan == null)
            {
                return NotFound();
            }

            return View(releacePlan);
        }

        // GET: ReleacePlans/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductsId", "ProductsId");
            return View();
        }

        // POST: ReleacePlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReleacePlanId,ProductId,OutputPlan,Price")] ReleacePlan releacePlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(releacePlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductsId", "ProductsId", releacePlan.ProductId);
            return View(releacePlan);
        }

        // GET: ReleacePlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var releacePlan = await _context.ReleacePlan.SingleOrDefaultAsync(m => m.ReleacePlanId == id);
            if (releacePlan == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductsId", "ProductsId", releacePlan.ProductId);
            return View(releacePlan);
        }

        // POST: ReleacePlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReleacePlanId,ProductId,OutputPlan,Price")] ReleacePlan releacePlan)
        {
            if (id != releacePlan.ReleacePlanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(releacePlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReleacePlanExists(releacePlan.ReleacePlanId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductsId", "ProductsId", releacePlan.ProductId);
            return View(releacePlan);
        }

        // GET: ReleacePlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var releacePlan = await _context.ReleacePlan
                .Include(r => r.Product)
                .SingleOrDefaultAsync(m => m.ReleacePlanId == id);
            if (releacePlan == null)
            {
                return NotFound();
            }

            return View(releacePlan);
        }

        // POST: ReleacePlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var releacePlan = await _context.ReleacePlan.SingleOrDefaultAsync(m => m.ReleacePlanId == id);
            _context.ReleacePlan.Remove(releacePlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReleacePlanExists(int id)
        {
            return _context.ReleacePlan.Any(e => e.ReleacePlanId == id);
        }
    }
}
