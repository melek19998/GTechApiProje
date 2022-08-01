using Microsoft.EntityFrameworkCore;

namespace GTechProje.API.Models
{
    public class NumbersAPIContext : DbContext
    {
        public NumbersAPIContext(DbContextOptions options) : base(options) { }
        DbSet<Number> Numbers { get; set; }
    }
}
