using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class SliderContent
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }
        [Required, Range(0.5,4)]
        public float Rating { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
