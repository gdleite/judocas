using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using judocas.Data;
using judocas.Models.Aluno;

namespace judocas.Controllers
{
    public class AlunosController : Controller
    {
        private readonly judocasContext _context;

        public AlunosController(judocasContext context)
        {
            _context = context;
        }

        // GET: Alunos
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

            var alunos = from s in _context.Alunos
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                alunos = alunos.Where(s => s.Nome.ToLower().Contains(searchString.ToLower())
                                       || s.RegistroCbj.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    alunos = alunos.OrderByDescending(s => s.Nome);
                    break;
                case "Date":
                    alunos = alunos.OrderBy(s => s.DataNascimento);
                    break;
                case "date_desc":
                    alunos = alunos.OrderByDescending(s => s.DataNascimento);
                    break;
                default:
                    alunos = alunos.OrderBy(s => s.Nome);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<Aluno>.CreateAsync(alunos.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include(s => s.Faixa)
                    .Include(e => e.RG)
                     .Include(c => c.Endereco)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            aluno.Faixa = _context.FaixasAlunos.Where(o => o.IdAluno == id).Distinct().ToList();
            aluno.RG = _context.RGAlunos.Where(t => t.IdAluno == id).Distinct().Single();
            aluno.Endereco = _context.EnderecosAlunos.Where(t => t.IdAluno == id).Distinct().Single();

            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,RegistroCbj,Telefone1,Telefone2,Email,CPF,Observacoes,DataNascimento,RG,Endereco")] Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(aluno);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException e)
            {
                ModelState.AddModelError("", "Não foi possivel salvar. " +
            "Tente novamente, se o problema persistir" +
            "procure o administrador do sistema.");
            }
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
               .Include(s => s.Faixa)
                   .Include(e => e.RG)
                    .Include(c => c.Endereco)
               .AsNoTracking()
               .FirstOrDefaultAsync(m => m.Id == id);

            aluno.Faixa = _context.FaixasAlunos.Where(o => o.IdAluno == id).Distinct().ToList();
            aluno.RG = _context.RGAlunos.Where(t => t.IdAluno == id).Distinct().Single();
            aluno.Endereco = _context.EnderecosAlunos.Where(t => t.IdAluno == id).Distinct().Single();

            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
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
            Aluno alunoToUpdate = await _context.Alunos.FirstOrDefaultAsync(s => s.Id == id);
            RG rgToUpdate = await _context.RGAlunos.FirstOrDefaultAsync(s => s.IdAluno == id);
            Endereco enderecoToUpdate = await _context.EnderecosAlunos.FirstOrDefaultAsync(s => s.IdAluno == id);
            if (await TryUpdateModelAsync<Aluno>(alunoToUpdate, "",
            s => s.Nome,
            s => s.RegistroCbj,
            s => s.Telefone1,
            s => s.Telefone2,
            s => s.Email,
            s => s.CPF,
            s => s.Telefone2,
            s => s.Observacoes,
            s => s.DataNascimento
            ))
                if (await TryUpdateModelAsync(rgToUpdate,
                "",
                s => s.OrgaoExpedidor,
                s => s.Numero
                ))
                    if (await TryUpdateModelAsync(enderecoToUpdate,
                    "",
                    s => s.Estado,
                    s => s.Cidade,
                    s => s.CEP,
                    s => s.Rua,
                    s => s.Numero,
                    s => s.Bairro
                    ))
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
            return View(alunoToUpdate);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include(s => s.Faixa)
                    .Include(e => e.RG)
                     .Include(c => c.Endereco)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            aluno.Faixa = _context.FaixasAlunos.Where(o => o.IdAluno == id).Distinct().ToList();
            aluno.RG = _context.RGAlunos.Where(t => t.IdAluno == id).Distinct().Single();
            aluno.Endereco = _context.EnderecosAlunos.Where(t => t.IdAluno == id).Distinct().Single();

            if (aluno == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete falhou. Tente denovo, se o problema persistir " +
                    "contacte o administrador do sistema.";
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool AlunoExists(long id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}
