using System.ComponentModel.DataAnnotations;

namespace Blog.Areas.Admin.Viewmodels.Sliders
{
    public class SliderUpdateVM
    {
        [Required, MaxLength(200)]
        public string Title { get; set; }
        [Required, Range(0.5, 4)]
        public float Rating { get; set; }
    }
}
