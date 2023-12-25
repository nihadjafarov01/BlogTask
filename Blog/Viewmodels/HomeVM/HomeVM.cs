using Blog.Viewmodels.SliderVM;
using Blog.Models;
using Blog.Viewmodels.SliderVM;
using Microsoft.EntityFrameworkCore;

namespace Blog.Viewmodels.HomeVM
{
    public class HomeVM
    {
        public List<SliderContentListItemVM> SliderContents { get; set; }
        public List<SliderImageListItemVM> SliderImages { get; set; }
    }
}
