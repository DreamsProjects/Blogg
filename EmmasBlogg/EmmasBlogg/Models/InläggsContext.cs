using Microsoft.EntityFrameworkCore;

namespace EmmasBlogg.Models
{
    public class InläggsContext : DbContext
    {
        public InläggsContext(DbContextOptions<InläggsContext> options) : base(options)
        {
        }

        public InläggsContext()
        {
        }

        public virtual DbSet<Inlägg> Poster { get; set; }
        public virtual DbSet<Kategori> Kategorier { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Inlägg>().ToTable("Poster").HasKey(x => x.InläggsID).HasName("PK_InläggsID");
             modelBuilder.Entity<Kategori>().ToTable("Kategori").HasKey(x => x.KategoriID).HasName("PK_KategoriID");
        }
    }
}

