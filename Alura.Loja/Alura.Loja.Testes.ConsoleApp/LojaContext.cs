using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    // Nossa classe de contexto será utilizada para persistir todas as classes que devem ser persistidas
    // pela aplicação. Ela deve fazer 3 coisas:
    // 1 - Permitir que seja utilizada dentro dela a API do EF Core. (Herdamos de DbContext, do EntityFrameworkCore)
    // 2 - Devemos informar as classes a serem persistidas pelo EF Core (Aqui, por enquanto, a classe Produto)
    // 3 - A classe deve definir também qual será o banco de dados, fazemos isso no evento de configuração da classe, sobrescrevendo 
    // o metódo OnConfiguring da classe DbContext

    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compra { get; set; }

        public LojaContext()
        { }

        public LojaContext(DbContextOptions<LojaContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
            }
        }

        // Adicionamos construtores na nossa classe LojaContext, que tornam a classe independente do banco de dados empregados.
        // Assim, passando as opções necessárias para utilizar o MySQL, chamamos o construtor da classe base DbContext.
        // Por último, o metódo OnConfiguring() deve utilizar o SQLServer apenas se as opções ainda não estiverem sido configuradas.
    }
}