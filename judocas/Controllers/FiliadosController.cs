using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using judocas.Data;
using judocas.Models;

namespace judocas.Controllers
{
    public class FiliadosController : Controller
    {
        private readonly judocasContext _context;

        public FiliadosController(judocasContext context)
        {
            _context = context;
        }

        // GET: Filiados
        public async Task<IActionResult> Index()
        {
            var judocasContext = _context.Filiados.Include(f => f.RG);
            return View(await judocasContext.ToListAsync());
        }

        // GET: Filiados/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiado = await _context.Filiados
                .Include(f => f.RG)
                .FirstOrDefaultAsync(m => m.IdFiliado == id);
            if (filiado == null)
            {
                return NotFound();
            }

            return View(filiado);
        }

        // GET: Filiados/Create
        public IActionResult Create()
        {
            ViewData["IdFiliado"] = new SelectList(_context.RG, "IdRG", "IdRG");
            return View();
        }

        // POST: Filiados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFiliado,Nome,RegistroCbj,Telefone1,Telefone2,Email,CPF,Observacoes,IdRG,DataNascimento")] Filiado filiado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filiado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFiliado"] = new SelectList(_context.RG, "IdRG", "IdRG", filiado.IdFiliado);
            return View(filiado);
        }

        // GET: Filiados/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiado = await _context.Filiados.FindAsync(id);
            if (filiado == null)
            {
                return NotFound();
            }
            ViewData["IdFiliado"] = new SelectList(_context.RG, "IdRG", "IdRG", filiado.IdFiliado);
            return View(filiado);
        }

        // POST: Filiados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IdFiliado,Nome,RegistroCbj,Telefone1,Telefone2,Email,CPF,Observacoes,IdRG,DataNascimento")] Filiado filiado)
        {
            if (id != filiado.IdFiliado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filiado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiliadoExists(filiado.IdFiliado))
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
            ViewData["IdFiliado"] = new SelectList(_context.RG, "IdRG", "IdRG", filiado.IdFiliado);
            return View(filiado);
        }

        // GET: Filiados/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiado = await _context.Filiados
                .Include(f => f.RG)
                .FirstOrDefaultAsync(m => m.IdFiliado == id);
            if (filiado == null)
            {
                return NotFound();
            }

            return View(filiado);
        }

        // POST: Filiados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var filiado = await _context.Filiados.FindAsync(id);
            _context.Filiados.Remove(filiado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiliadoExists(long? id)
        {
            return _context.Filiados.Any(e => e.IdFiliado == id);
        }
    }
}
