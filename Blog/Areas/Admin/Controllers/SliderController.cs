using Blog.Areas.Admin.Viewmodels.Sliders;
using Blog.Contexts;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        BlogDbContext _context { get; }

        public SliderController(BlogDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var datas = _context.SliderContents.Select(s => new SliderListItemVM
            {
                Id = s.Id,
                IsDeleted = s.IsDeleted,
                Rating = s.Rating,
                Title = s.Title,
            }).ToList();
            return View(datas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SliderCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            SliderContent slider = new SliderContent
            {
                Rating = vm.Rating,
                Title = vm.Title,
            };
            _context.SliderContents.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            if (id <= 0 || id == null) return BadRequest();
            var data = _context.SliderContents.Find(id);
            if (data == null) return NotFound();
            SliderUpdateVM slider = new SliderUpdateVM
            {
                Rating = data.Rating,
                Title = data.Title,
            };
            return View(slider);
        }
        [HttpPost]
        public IActionResult Update(SliderUpdateVM vm, int id)
        {
            if (id <= 0 || id == null) return BadRequest();
            var data = _context.SliderContents.Find(id);
            if (data == null) return NotFound();
            data.Rating = vm.Rating;
            data.Title = vm.Title;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (id <= 0 || id == null) return BadRequest();
            var data = _context.SliderContents.Find(id);
            if (data == null) return NotFound();
            data.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
