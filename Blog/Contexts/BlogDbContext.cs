using Blog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Contexts
{
    public class BlogDbContext : IdentityDbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SliderContent> SliderContents { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
    }
}
