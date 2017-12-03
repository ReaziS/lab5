using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FactoryProduction.Models;
using FactoryProduction.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FactoryProduction.Controllers
{
    public class FactoriesController : Controller
    {
        private readonly ApplicationContext _context;

        public FactoriesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Factories
        [Authorize(Roles = "admin,user")]
        public IActionResult Index(string ProductName, string UnitOfProduct, string FactName, string Head, string ProductTypeName, int? ImplePlan, int? Price, int? OutputPlan, int page = 1, SortState sortOrder = SortState.FactNameAsc)
        {
            int pageSize = 5;

            IQueryable<Factories> source = _context.Factories;

            if (FactName != null)
            {
                source = source.Where(x => x.FactName.Contains(FactName));
            }
            if (Head != null)
            {
                source = source.Where(x => x.Head == Head);
            }



            switch (sortOrder)
            {
                case SortState.FactNameAsc:
                    source = source.OrderBy(x => x.FactName);
                    break;
                case SortState.FactNameDesc:
                    source = source.OrderByDescending(x => x.FactName);
                    break;

                case SortState.HeadAsc:
                    source = source.OrderBy(x => x.Head);
                    break;
                case SortState.HeadDesc:
                    source = source.OrderByDescending(x => x.Head);
                    break;
            }


            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize);
            PageViewModel pageView = new PageViewModel(count, page, pageSize);
            IndexViewModel ivm = new IndexViewModel
            {
                PageViewModel = pageView,
                SortViewModels = new SortViewModels(sortOrder),
                FilterViewModels = new FilterViewModels(ProductName, UnitOfProduct, FactName, Head, ProductTypeName, ImplePlan, Price, OutputPlan),
                Factories = items
            };
            return View(ivm);

        }

        // GET: Factories/Details/5
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factories = await _context.Factories
                .SingleOrDefaultAsync(m => m.FactoriesId == id);
            if (factories == null)
            {
                return NotFound();
            }

            return View(factories);
        }

        // GET: Factories/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Factories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FactoriesId,FactName,Head")] Factories factories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factories);
        }

        // GET: Factories/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factories = await _context.Factories.SingleOrDefaultAsync(m => m.FactoriesId == id);
            if (factories == null)
            {
                return NotFound();
            }
            return View(factories);
        }

        // POST: Factories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FactoriesId,FactName,Head")] Factories factories)
        {
            if (id != factories.FactoriesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactoriesExists(factories.FactoriesId))
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
            return View(factories);
        }

        // GET: Factories/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factories = await _context.Factories
                .SingleOrDefaultAsync(m => m.FactoriesId == id);
            if (factories == null)
            {
                return NotFound();
            }

            return View(factories);
        }

        // POST: Factories/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factories = await _context.Factories.SingleOrDefaultAsync(m => m.FactoriesId == id);
            _context.Factories.Remove(factories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactoriesExists(int id)
        {
            return _context.Factories.Any(e => e.FactoriesId == id);
        }
    }
}
