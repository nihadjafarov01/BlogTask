using System.ComponentModel.DataAnnotations;

namespace Blog.Areas.Admin.Viewmodels.Sliders
{
    public class SliderListItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Rating { get; set; }
        public bool IsDeleted { get; set; }
    }
}
