using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerOrderManagementApp.DataStorage;
using PMIS.Models.EntityModels;
using PMIS.Repositories.Abstractions;

namespace CustomerOrderManagementApp.Controllers
{
    public class ProductsController : Controller
    {
       // private readonly EcommerceDbContext _context;
        IProductRepository _context;

        public ProductsController(IProductRepository context)
        {
            _context = context;
        }

        // GET: Products
        public IActionResult Index()
        {
        
       
            return View(_context.GetAll());
         
        }

        // GET: Products/Details/5
    public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product =  _context.GetFirstOrDefault(x => x.Id == id);
                
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
     public IActionResult Create()
       {
           return View();
       }

       // POST: Products/Create
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public IActionResult Create([Bind("Id,Name,Code,Description,UnitPrice")] Product product)
       {
           if (ModelState.IsValid)
           {
               _context.Add(product);
                
               return RedirectToAction(nameof(Index));
           }
           return View(product);
       }

       // GET: Products/Edit/5
       public IActionResult Edit(int? id)
       {
           if (id == null)
           {
               return NotFound();
           }

            var product = _context.GetFirstOrDefault(x => x.Id == id);
           if (product == null)
           {
               return NotFound();
           }
           return View(product);
       }
 
         // POST: Products/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public IActionResult Edit(int id, [Bind("Id,Name,Code,Description,UnitPrice")] Product product)
         {
             if (id != product.Id)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(product);
                    
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                    return NotFound();
                }
                 return RedirectToAction(nameof(Index));
             }
             return View(product);
         }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
      {
          if (id == null)
          {
              return NotFound();
          }

          var product =  _context.GetFirstOrDefault(m => m.Id == id);
          if (product == null)
          {
              return NotFound();
          }

          return View(product);
      }

      // POST: Products/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public IActionResult DeleteConfirmed(int id)
      {
           
            var product = _context.GetFirstOrDefault(m => m.Id == id);
           
        
          if (product != null)
          {
                _context.Delete(product);
            }

         
          return RedirectToAction(nameof(Index));
      }

    }
}
