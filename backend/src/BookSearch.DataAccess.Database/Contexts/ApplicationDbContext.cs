using BookSearch.DataAccess.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookSearch.DataAccess.Database.Contexts
{
    public sealed class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions options) : base(options) { } 

        public DbSet<Book>? Books { get; set; } 
        
        protected override void OnModelCreating(ModelBuilder builder) 
        { 
            base.OnModelCreating(builder);
            builder.Entity<Book>()
                .Property(e => e.Authors).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<IEnumerable<Author>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

        }
	}
}
