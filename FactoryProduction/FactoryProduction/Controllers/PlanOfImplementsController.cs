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
    public class PlanOfImplementsController : Controller
    {
        private readonly ApplicationContext _context;

        public PlanOfImplementsController(ApplicationContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "admin,user")]
        public IActionResult Index(string ProductName, string UnitOfProduct, string FactName, string Head, string ProductTypeName, int? ImplePlan, int? Price, int? OutputPlan, int page = 1, SortState sortOrder = SortState.FactNameAsc)
        {
            int pageSize = 5;

            IQueryable<PlanOfImplement> source = _context.PlanOfImplement;

            if (ImplePlan != null)
            {
                source = source.Where(x => x.ImplePlan.Equals(ImplePlan));
            }
            if (Price != null)
            {
                source = source.Where(x => x.Price.Equals(Price));
            }



            switch (sortOrder)
            {
                case SortState.ImplePlanAsc:
                    source = source.OrderBy(x => x.ImplePlan);
                    break;
                case SortState.ImplePlanDesc:
                    source = source.OrderByDescending(x => x.ImplePlan);
                    break;

                case SortState.PriceAsc:
                    source = source.OrderBy(x => x.Price);
                    break;
                case SortState.PriceDesc:
                    source = source.OrderByDescending(x => x.Price);
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
                PlanOfImplement = items
            };
            return View(ivm);

        }

        // GET: PlanOfImplements/Details/5
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planOfImplement = await _context.PlanOfImplement
                .Include(p => p.Product)
                .SingleOrDefaultAsync(m => m.PlanOfImplementId == id);
            if (planOfImplement == null)
            {
                return NotFound();
            }

            return View(planOfImplement);
        }

        // GET: PlanOfImplements/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductsId", "ProductsId");
            return View();
        }

        // POST: PlanOfImplements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanOfImplementId,ProductId,ImplePlan,Price")] PlanOfImplement planOfImplement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planOfImplement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductsId", "ProductsId", planOfImplement.ProductId);
            return View(planOfImplement);
        }

        // GET: PlanOfImplements/Edit/5.
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planOfImplement = await _context.PlanOfImplement.SingleOrDefaultAsync(m => m.PlanOfImplementId == id);
            if (planOfImplement == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductsId", "ProductsId", planOfImplement.ProductId);
            return View(planOfImplement);
        }

        // POST: PlanOfImplements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlanOfImplementId,ProductId,ImplePlan,Price")] PlanOfImplement planOfImplement)
        {
            if (id != planOfImplement.PlanOfImplementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planOfImplement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanOfImplementExists(planOfImplement.PlanOfImplementId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductsId", "ProductsId", planOfImplement.ProductId);
            return View(planOfImplement);
        }

        // GET: PlanOfImplements/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planOfImplement = await _context.PlanOfImplement
                .Include(p => p.Product)
                .SingleOrDefaultAsync(m => m.PlanOfImplementId == id);
            if (planOfImplement == null)
            {
                return NotFound();
            }

            return View(planOfImplement);
        }

        // POST: PlanOfImplements/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planOfImplement = await _context.PlanOfImplement.SingleOrDefaultAsync(m => m.PlanOfImplementId == id);
            _context.PlanOfImplement.Remove(planOfImplement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanOfImplementExists(int id)
        {
            return _context.PlanOfImplement.Any(e => e.PlanOfImplementId == id);
        }
    }
}
