using Crud_mvc_cSharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Crud_mvc_cSharp.Context
{
    public class MeuDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MeuDbContext(DbContextOptions<MeuDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Banda> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("VariavelConexao"));
            }
        }
    }
}
