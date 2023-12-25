using Blog.Viewmodels.SliderVM;
using Blog.Contexts;
using Blog.Models;
using Blog.Viewmodels.HomeVM;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Controllers
{
	public class HomeController : Controller
	{
		BlogDbContext _context {  get; }

        public HomeController(BlogDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
		{
			HomeVM homeMV = new HomeVM { SliderContents = _context.SliderContents.Where(s => !s.IsDeleted).Select(s => new SliderContentListItemVM
            {
                Rating = s.Rating,
                Title = s.Title,
            }).ToList(),
            SliderImages = _context.SliderImages.Select(s => new SliderImageListItemVM { ImageUrl = s.ImageUrl}).ToList()};

			return View(homeMV);
		}
	}
}