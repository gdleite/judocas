﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using judocas.Data;
using judocas.Models.Aluno;
using judocas.Models.Professor;

namespace judocas.Controllers
{
    public class AlunosController : Controller
    {
        private readonly JudocasContext _context;

        public AlunosController(JudocasContext context)
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
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            aluno.Faixa = _context.FaixasAlunos.Where(o => o.IdAluno == id).Distinct().ToList();

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
        public async Task<IActionResult> Create([Bind("Nome,RegistroCbj,DataVencimentoCBJ,Telefone1,Telefone2,Email,CPF,Observacoes,DataNascimento,Numero,OrgaoExpedidor,Rua,NumeroResidencia,Bairro,Cidade,Estado,CEP,Faixa")] Aluno aluno)
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
            catch (DbUpdateException)
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
               .AsNoTracking()
               .FirstOrDefaultAsync(m => m.Id == id);

            aluno.Faixa = _context.FaixasAlunos.Where(o => o.IdAluno == id).Distinct().ToList();

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
            if (await TryUpdateModelAsync(alunoToUpdate, "",
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
            s => s.CEP
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
                     .Include(d => d.Faixa)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            aluno.Faixa = _context.FaixasAlunos.Where(o => o.IdAluno == id).Distinct().ToList();

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

        // GET: Alunos/Promote/5
        public async Task<IActionResult> Promote(long? id)
        {
            if (id == null) return NotFound();
            
            Aluno aluno = await _context.Alunos
                .Include(s => s.Faixa)
                     .Include(d => d.Faixa)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);


            aluno.Faixa = _context.FaixasAlunos.Where(o => o.IdAluno == id).Distinct().ToList();
            
            Professor professor;
            if (aluno == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                // Replicando professor
                professor = new Professor
                {
                    Nome = aluno.Nome,
                    CPF = aluno.CPF,
                    Email = aluno.Email,
                    DataNascimento = aluno.DataNascimento,
                    Observacoes = aluno.Observacoes,
                    Telefone1 = aluno.Telefone1,
                    Telefone2 = aluno.Telefone2,
                    RegistroCbj = aluno.RegistroCbj,
                    DataVencimentoCBJ = aluno.DataVencimentoCBJ,
                    Numero = aluno.Numero,
                    OrgaoExpedidor = aluno.OrgaoExpedidor,
                    Bairro = aluno.Bairro,
                    CEP = aluno.CEP,
                    Cidade = aluno.Cidade,
                    Estado = aluno.Estado,
                    Rua = aluno.Rua,
                    NumeroResidencia = aluno.NumeroResidencia
                };
                _context.Professores.Add(professor);
                _context.SaveChanges();

                // Replicando faixas
                List<Models.Professor.Faixa> listaFaixas = new List<Models.Professor.Faixa>();
                if (aluno.Faixa != null)
                {
                    foreach (var faixa in aluno.Faixa)
                    {
                        listaFaixas.Add(new Models.Professor.Faixa
                        {
                            IdProfessor = _context.Professores.Single(s => s.Nome == aluno.Nome).Id,
                            Cor = (Models.Professor.Faixa.Cores)faixa.Cor,
                            DataEntrega = faixa.DataEntrega,
                            Descricao = faixa.Descricao
                        }
                        );
                    }
                    foreach (var e in listaFaixas)
                    {
                        var faixaInDatabase = _context.FaixasProfessores.Where(
                            s => s.Professor.Id == e.IdProfessor).SingleOrDefault();
                        if (faixaInDatabase == null)
                        {
                            _context.FaixasProfessores.Add(e);
                        }
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
            return View(aluno);
        }

        public async Task<IActionResult> Renew(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoToUpdate = await _context.Alunos.FirstOrDefaultAsync(s => s.Id == id);

            alunoToUpdate.Faixa = _context.FaixasAlunos.Where(o => o.IdAluno == id).Distinct().ToList();

            if (alunoToUpdate != null)
            {
                alunoToUpdate.DataVencimentoCBJ = DateTime.Now.AddYears(1);
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

            return View(alunoToUpdate);
        }
    }
}
