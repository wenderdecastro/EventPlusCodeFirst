using Microsoft.EntityFrameworkCore;
using webApi.EventPlus.Domains;

namespace webApi.EventPlus.Contexts
{
    public class EventContext : DbContext
    {

        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<TiposEvento> TiposEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet< Usuario> Usuario { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<PresencaEvento> PresencaEvento { get; set; }
        public DbSet<ComentariosEvento> ComentariosEvento { get; set; }

        // Define as opções de construção do banco (string conexao)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE10-S15; Database = Event; User = sa; Pwd = Senai@134; TrustServerCertificate = True");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
