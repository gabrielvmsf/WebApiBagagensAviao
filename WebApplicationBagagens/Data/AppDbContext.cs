using Microsoft.EntityFrameworkCore;
using WebApplicationBagagens.Models;

namespace WebApplicationBagagens.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<BagagemModel> Bagagens { get; set; }
        public DbSet<HistoricoMovimentacaoModel> HistoricoMovimentacoes { get; set; }

    }
}