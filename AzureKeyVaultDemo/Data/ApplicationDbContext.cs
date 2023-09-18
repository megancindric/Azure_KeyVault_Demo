using AzureKeyVaultDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureKeyVaultDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        
        }
    }
}
