using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using judocas.Data;
using judocas.Models.Entidade;
using judocas.Models.Relacao;
using System;

namespace judocas.Controllers
{
    public class EntidadesController : Controller
    {
        private readonly JudocasContext _context;

        public EntidadesController(JudocasContext context)
        {
            _context = context;
        }

        // GET: Entidades
        public async Task<IActionResult> Index(int? id, string searchString)
        {
            var viewModel = new ProfessorIndexData();

            if (!String.IsNullOrEmpty(searchString))
            {
                viewModel.Entidades = await _context.Entidades
                        .Where(s => s.Nome.ToLower().Contains(searchString.ToLower()))
                      .Include(i => i.ProfessorEntidade)
                      .ThenInclude(i => i.Professor)
                      .ToListAsync();
            }
            else
            {
                viewModel.Entidades = await _context.Entidades
                      .Include(i => i.ProfessorEntidade)
                      .ThenInclude(i => i.Professor)
                      .ToListAsync();
            }

            if (id != null)
            {
                ViewData["EntidadeID"] = id.Value;
                Entidade entidade = viewModel.Entidades.Single(
                    i => i.Id == id.Value);
                viewModel.Professores = entidade.ProfessorEntidade.Select(s => s.Professor);
            }

            return View(viewModel);
        }

        // GET: Entidades/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidade = await _context.Entidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entidade == null)
            {
                return NotFound();
            }

            return View(entidade);
        }

        // GET: Entidades/Create
        public IActionResult Create()
        {
            var entidade = new Entidade();
            entidade.ProfessorEntidade = new List<ProfessorEntidade>();
            PopulateAssignedProfessorData(entidade);
            return View();
        }

        // POST: Entidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CNPJ,Telefone1,Telefone2,Rua,Numero,Bairro,Cidade,Estado,CEP")] Entidade entidade, string[] selectedProfessores)
        {
            if (selectedProfessores != null)
            {
                entidade.ProfessorEntidade = new List<ProfessorEntidade>();
                foreach (var professor in selectedProfessores)
                {
                    var professorToAdd = new ProfessorEntidade { EntidadeID = entidade.Id, ProfessorID = int.Parse(professor) };
                    entidade.ProfessorEntidade.Add(professorToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(entidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateAssignedProfessorData(entidade);
            return View(entidade);
        }

        // GET: Entidade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidade = await _context.Entidades
                .Include(i => i.ProfessorEntidade).ThenInclude(i => i.Professor)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entidade == null)
            {
                return NotFound();
            }
            PopulateAssignedProfessorData(entidade);
            return View(entidade);
        }

        // POST: Entidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedProfessores)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entidade entidadeToUpdate = await _context.Entidades
                .Include(i => i.ProfessorEntidade)
                    .ThenInclude(i => i.Professor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (await TryUpdateModelAsync<Entidade>(
                entidadeToUpdate,
                "",
                i => i.Nome, i => i.CNPJ, i => i.Telefone1, i => i.Telefone2, i => i.Rua, i => i.Numero, i => i.Bairro, i => i.Cidade, i => i.Estado, i => i.CEP, i => i.ProfessorEntidade))
            {
                UpdateEntidadeProfessores(selectedProfessores, entidadeToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            UpdateEntidadeProfessores(selectedProfessores, entidadeToUpdate);
            PopulateAssignedProfessorData(entidadeToUpdate);
            return View(entidadeToUpdate);
        }

        // GET: Entidades/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidade = await _context.Entidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entidade == null)
            {
                return NotFound();
            }

            return View(entidade);
        }

        // POST: Entidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Entidade entidade = await _context.Entidades
                .Include(i => i.ProfessorEntidade)
                .SingleAsync(i => i.Id == id);

            _context.Entidades.Remove(entidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntidadeExists(long id)
        {
            return _context.Entidades.Any(e => e.Id == id);
        }
        private void PopulateAssignedProfessorData(Entidade entidade)
        {
            var allProfessores = _context.Professores;
            var entidadesProfessores = new HashSet<long>(entidade.ProfessorEntidade.Select(c => c.ProfessorID));
            var viewModel = new List<AssignedProfessorData>();
            foreach (var professor in allProfessores)
            {
                viewModel.Add(new AssignedProfessorData
                {
                    ProfessorId = professor.Id,
                    Nome = professor.Nome,
                    Assigned = entidadesProfessores.Contains(professor.Id)
                });
            }
            ViewData["Professores"] = viewModel;
        }

        private void UpdateEntidadeProfessores(string[] selectedProfessores, Entidade entidadeToUpdate)
        {
            if (selectedProfessores == null)
            {
                entidadeToUpdate.ProfessorEntidade = new List<ProfessorEntidade>();
                return;
            }

            var selectedProfessoresHS = new HashSet<string>(selectedProfessores);
            var entidadeProfessores = new HashSet<long>
                (entidadeToUpdate.ProfessorEntidade.Select(c => c.Professor.Id));
            foreach (var professor in _context.Professores)
            {
                if (selectedProfessoresHS.Contains(professor.Id.ToString()))
                {
                    if (!entidadeProfessores.Contains(professor.Id))
                    {
                        entidadeToUpdate.ProfessorEntidade.Add(new ProfessorEntidade { EntidadeID = entidadeToUpdate.Id, ProfessorID = professor.Id });
                    }
                }
                else
                {

                    if (entidadeProfessores.Contains(professor.Id))
                    {
                        ProfessorEntidade professorToRemove = entidadeToUpdate.ProfessorEntidade.FirstOrDefault(i => i.ProfessorID == professor.Id);
                        _context.Remove(professorToRemove);
                    }
                }
            }
        }
    }
    
}
