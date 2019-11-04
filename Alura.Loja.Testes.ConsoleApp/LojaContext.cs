using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class LojaContext : DbContext
    {
        //No contexto do Entity sempre será criado uma propriedade para a classe que quermos que seja implementada no banco de dados
        //O tipo dessas classes será DbSet<CLASSE DO DOMÍNIO>
        public DbSet<Produto> Produtos { get; set; }

        public LojaContext()
        {
            //O método Migrate serve para sincronizar as alterações nas classes da aplica~ção, com o banco de dados
            //Este método deve ser executado antes de qualquer acesso aos objetos gereciados pelo contexto
            //this.Database.Migrate();
        }

        public LojaContext(DbContextOptions<LojaContext> options) : base(options)
        {

        }

        //Método para definir qual o bando de dados e o seu endereço
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
            }
        }
    }
}
