using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using judocas.Data;
using judocas.Models.Professor;

namespace judocas.Controllers
{
    public class ProfessoresController : Controller
    {
        private readonly JudocasContext _context;

        public ProfessoresController(JudocasContext context)
        {
            _context = context;
        }

        // GET: Professores
        public async Task<IActionResult> Index(
        string sortOrder,
        string currentFilter,
        string searchString,
        int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var professores = from s in _context.Professores
                              select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                professores = professores.Where(s => s.Nome.ToLower().Contains(searchString.ToLower())
                                       || s.RegistroCbj.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    professores = professores.OrderByDescending(s => s.Nome);
                    break;
                case "Date":
                    professores = professores.OrderBy(s => s.DataNascimento);
                    break;
                case "date_desc":
                    professores = professores.OrderByDescending(s => s.DataNascimento);
                    break;
                default:
                    professores = professores.OrderBy(s => s.Nome);
                    break;
            }
            return base.View(await PaginatedList<Professor>.CreateAsync(professores.AsNoTracking(), pageNumber ?? 1, 10));
        }

        // GET: Professores/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores
                .Include(s => s.Faixa)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            professor.Faixa = _context.FaixasProfessores.Where(o => o.IdProfessor == id).Distinct().ToList();

            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: Professores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,RegistroCbj,DataVencimentoCBJ,Telefone1,Telefone2,Email,CPF,Observacoes,DataNascimento,Numero,OrgaoExpedidor,Rua,NumeroResidencia,Bairro,Cidade,Estado,CEP,Faixa")] Professor professor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(professor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possivel salvar. " +
            "Tente novamente, se o problema persistir" +
            "procure o administrador do sistema.");
            }
            return View(professor);
        }

        // GET: Professores/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var professor = await _context.Professores
                .Include(s => s.Faixa)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            professor.Faixa = _context.FaixasProfessores.Where(o => o.IdProfessor == id).Distinct().ToList();

            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: Professores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var professorToUpdate = await _context.Professores.FirstOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Professor>(
                professorToUpdate,
                "",
                s => s.Nome,
                s => s.RegistroCbj,
                s => s.DataVencimentoCBJ,
                s => s.Telefone1,
                s => s.Telefone2,
                s => s.Email,
                s => s.CPF,
                s => s.Telefone2,
                s => s.Observacoes,
                s => s.DataNascimento,
                s => s.Numero,
                s => s.OrgaoExpedidor,
                s => s.Rua,
                s => s.NumeroResidencia,
                s => s.Bairro,
                s => s.Cidade,
                s => s.Estado,
                s => s.CEP))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(professorToUpdate);
        }

        // GET: Professores/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores
                .Include(s => s.Faixa)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            professor.Faixa = _context.FaixasProfessores.Where(o => o.IdProfessor == id).Distinct().ToList();
            if (professor == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete falhou. Tente denovo, se o problema persistir " +
                    "contacte o administrador do sistema.";
            }

            return View(professor);
        }

        // POST: Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var professor = await _context.Professores.FindAsync(id);
            if (professor == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Professores.Remove(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        public async Task<IActionResult> Renew(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorToUpdate = await _context.Professores.FirstOrDefaultAsync(s => s.Id == id);

            professorToUpdate.Faixa = _context.FaixasProfessores.Where(o => o.IdProfessor == id).Distinct().ToList();

            if (professorToUpdate != null)
            {
                professorToUpdate.DataVencimentoCBJ = DateTime.Now.AddYears(1);
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            else
            {
                return NotFound();
            }

            return View(professorToUpdate);
        }
    }
}
