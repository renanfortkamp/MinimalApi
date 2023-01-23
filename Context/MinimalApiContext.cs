using Microsoft.EntityFrameworkCore;
using MinimalApi.Models.Entities;

namespace MinimalApi.Context
{
    public class MinimalApiContext : DbContext
    {
        public MinimalApiContext(DbContextOptions<MinimalApiContext> options): base(options)
        {
        }

        public DbSet<Usuario> UsuarioDbSet { get; set; }
    }
}
