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
    public class ProductTypesController : Controller
    {
        private readonly ApplicationContext _context;

        public ProductTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ProductTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductTypes.ToListAsync());
        }

        // GET: ProductTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTypes = await _context.ProductTypes
                .SingleOrDefaultAsync(m => m.ProductTypesId == id);
            if (productTypes == null)
            {
                return NotFound();
            }

            return View(productTypes);
        }

        // GET: ProductTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductTypesId,ProductTypeName")] ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }

        // GET: ProductTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTypes = await _context.ProductTypes.SingleOrDefaultAsync(m => m.ProductTypesId == id);
            if (productTypes == null)
            {
                return NotFound();
            }
            return View(productTypes);
        }

        // POST: ProductTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductTypesId,ProductTypeName")] ProductTypes productTypes)
        {
            if (id != productTypes.ProductTypesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTypesExists(productTypes.ProductTypesId))
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
            return View(productTypes);
        }

        // GET: ProductTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTypes = await _context.ProductTypes
                .SingleOrDefaultAsync(m => m.ProductTypesId == id);
            if (productTypes == null)
            {
                return NotFound();
            }

            return View(productTypes);
        }

        // POST: ProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productTypes = await _context.ProductTypes.SingleOrDefaultAsync(m => m.ProductTypesId == id);
            _context.ProductTypes.Remove(productTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTypesExists(int id)
        {
            return _context.ProductTypes.Any(e => e.ProductTypesId == id);
        }
    }
}
