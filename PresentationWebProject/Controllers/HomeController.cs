using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentationWebProject.Models;
using System.Diagnostics;

namespace PresentationWebProject.Controllers
{
	public class HomeController : Controller
	{

		private readonly PresentationDbContext _context;

		public HomeController(PresentationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> Presentations(int? page = 1)
		{
			if (page == null)
			{
				var presentationDbContext = _context.Presentations.Include(p => p.Teacher);
				return View(await presentationDbContext.Include(x => x.Teacher).ToListAsync());
			}
			else
			{
				int count = 3;
				var presentationDbContext = _context.Presentations.Include(p => p.Teacher);

				int countPresentation = await presentationDbContext.CountAsync();
				int countPage = Convert.ToInt32(Math.Ceiling(countPresentation * 1.0 / count));

				List<Presentation> list = await presentationDbContext.Include(p => p.Teacher).Skip((Convert.ToInt32(page) - 1) * count).Take(count).ToListAsync();
				PageViewModel viewModel = new PageViewModel(countPage, list);
				return View(viewModel);
			}
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


	}
}