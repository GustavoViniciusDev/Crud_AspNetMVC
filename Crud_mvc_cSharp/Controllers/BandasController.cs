using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crud_mvc_cSharp.Context;
using Crud_mvc_cSharp.Models;

namespace Crud_mvc_cSharp.Controllers
{
    public class BandasController : Controller
    {
        private readonly MeuDbContext _context;

        public BandasController(MeuDbContext context)
        {
            _context = context;
        }

        // GET: Bandas
        public async Task<IActionResult> Index()
        {
              return _context.Produtos != null ? 
                          View(await _context.Produtos.ToListAsync()) :
                          Problem("Entity set 'MeuDbContext.Produtos'  is null.");
        }

        // GET: Bandas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var banda = await _context.Produtos
                .FirstOrDefaultAsync(m => m.IdBandas == id);
            if (banda == null)
            {
                return NotFound();
            }

            return View(banda);
        }

        // GET: Bandas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bandas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBandas,NomeBanda,Genero,QtdAlbuns")] Banda banda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banda);
        }

        // GET: Bandas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var banda = await _context.Produtos.FindAsync(id);
            if (banda == null)
            {
                return NotFound();
            }
            return View(banda);
        }

        // POST: Bandas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBandas,NomeBanda,Genero,QtdAlbuns")] Banda banda)
        {
            if (id != banda.IdBandas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BandaExists(banda.IdBandas))
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
            return View(banda);
        }

        // GET: Bandas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var banda = await _context.Produtos
                .FirstOrDefaultAsync(m => m.IdBandas == id);
            if (banda == null)
            {
                return NotFound();
            }

            return View(banda);
        }

        // POST: Bandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'MeuDbContext.Produtos'  is null.");
            }
            var banda = await _context.Produtos.FindAsync(id);
            if (banda != null)
            {
                _context.Produtos.Remove(banda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BandaExists(int id)
        {
          return (_context.Produtos?.Any(e => e.IdBandas == id)).GetValueOrDefault();
        }
    }
}
