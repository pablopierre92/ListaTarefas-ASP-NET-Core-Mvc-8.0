using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ListaDeTarefas.Controllers
{
	public class HomeController : Controller
	{
		

		public IActionResult Index()
		{
			return View();
		}

		
	}
}
