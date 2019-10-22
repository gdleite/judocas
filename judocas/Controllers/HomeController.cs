using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using judocas.Models.Professor;
using judocas.Models;
using Microsoft.EntityFrameworkCore;
using judocas.Data;

namespace judocas.Controllers
{
    

    public class HomeController : Controller
    {
        private readonly judocasContext _context;
        public HomeController(judocasContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> About()
        {
            IQueryable<ProfessorGrupo> data =
                from professor in _context.Professores
                group professor by professor.DataNascimento into dateGroup
                select new ProfessorGrupo()
                {
                    DataNascimento = dateGroup.Key,
                    ContagemProfessores = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }
    }
}
