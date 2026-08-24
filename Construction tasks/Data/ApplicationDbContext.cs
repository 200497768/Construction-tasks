using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Construction_tasks.Models;

namespace Construction_tasks.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Construction_tasks.Models.Task> Task { get; set; } = default!;
    }
}
