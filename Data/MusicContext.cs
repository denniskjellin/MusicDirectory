using MusicDirectory.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicDirectory.Data
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {

        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<MusicDirectory.Models.Member> Member { get; set; } = default!;
        public DbSet<MusicDirectory.Models.Loan> Loan { get; set; } = default!;

    }
}