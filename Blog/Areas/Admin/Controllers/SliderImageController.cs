using Blog.Areas.Admin.Viewmodels.SliderImage;
using Blog.Areas.Admin.Viewmodels.Sliders;
using Blog.Contexts;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Cryptography;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderImageController : Controller
    {
        BlogDbContext _context { get; }

        public SliderImageController(BlogDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var datas = _context.SliderImages.Select(s => new SliderImageListItemVM
            {
                Id = s.Id,
                ImageUrl = s.ImageUrl,
            }).ToList();
            return View(datas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderImageCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", vm.ImageFile.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await vm.ImageFile.CopyToAsync(stream);
            }
            
            SliderImage slider = new SliderImage
            {
                ImageUrl = path,
            };
            _context.SliderImages.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");}
        }

        //public IActionResult Update(int id)
        //{
        //    if (id <= 0 || id == null) return BadRequest();
        //    var data = _context.SliderImages.Find(id);
        //    if (data == null) return NotFound();
        //    SliderImageUpdateVM slider = new SliderImageUpdateVM
        //    {
        //        ImageUrl = data.ImageUrl,
        //    };
        //    return View(slider);
        //}
        //[HttpPost]
        //public IActionResult Update(SliderImageUpdateVM vm, int id)
        //{
        //    if (id <= 0 || id == null) return BadRequest();
        //    var data = _context.SliderImages.Find(id);
        //    if (data == null) return NotFound();
        //    data.ImageUrl = vm.ImageUrl;
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //public IActionResult Delete(int id)
        //{
        //    if (id <= 0 || id == null) return BadRequest();
        //    var data = _context.SliderImages.Find(id);
        //    if (data == null) return NotFound();
        //    _context.SliderImages.Remove(data);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    
}
