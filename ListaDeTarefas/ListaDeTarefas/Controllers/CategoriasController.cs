using ListaDeTarefas.Data;
using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly AppDbContext _context;
        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Categoria> categoria = _context.Categorias;
            return View(categoria);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }


        public IActionResult Editar(string? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Categoria categoria = _context.Categorias.FirstOrDefault(x => x.CategoriaId == id);

            if(categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }


		public IActionResult Excluir(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Categoria categoria = _context.Categorias.FirstOrDefault(x => x.CategoriaId == id);

			if (categoria == null)
			{
				return NotFound();
			}

			return View(categoria);
		}

		[HttpPost]
        public IActionResult Cadastrar(Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Update(categoria);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(categoria);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Excluir(Categoria categoria)
		{
			if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return RedirectToAction("Index");

		}
	}
}
