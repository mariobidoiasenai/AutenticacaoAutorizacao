using AutenticacaoAutorizacao.Models;
using Microsoft.EntityFrameworkCore;

namespace AutenticacaoAutorizacao.WebAPI.Data
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; } 
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<CarrinhoItem> CarrinhoItens { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasData(
                    new Usuario
                    {
                        Id = 1,
                        Nome = "Senai ADMIN",
                        Username = "senai",
                        Password = "senai123",
                        Role = "Admin"
                    },
                    new Usuario
                    {
                        Id = 2,
                        Nome = "Senai Aluno",
                        Username = "aluno",
                        Password = "senai123",
                        Role = "Aluno"
                    }
                );

            modelBuilder.Entity<Categoria>()
                .HasData(new Categoria { Id = 1, Nome = "Ferramentas" }, new Categoria { Id = 2, Nome = "Papelaria" }, new Categoria { Id = 3, Nome = "Games" });
        }
    }
}
