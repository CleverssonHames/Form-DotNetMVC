using FormWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FormWeb.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options){}
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TipoB> TipoBs { get; set; }
        public DbSet<TipoA> TipoAs { get; set; }

    }
}
