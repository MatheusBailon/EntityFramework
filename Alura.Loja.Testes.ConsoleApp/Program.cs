using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var pao = new Produto()
            {
                Nome = "Pão Francês",
                PrecoUnitario = 0.4,
                Unidade = "Unidade",
                Categoria = "Padaria"
            };

            var compra = new Compra();
            compra.Quantidade = 16;
            compra.Produto = pao;
            compra.Preco = pao.PrecoUnitario * compra.Quantidade;

            //Adicionando a classe de Logger

            using (var contexto = new LojaContext())
            {
                //*** Adicionando Log (para exibir as consultas realizadas pelo Entity) ***
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());
                //*** Fim do Log ***

                contexto.Compras.Add(compra);

                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();
            }

            static void ExibeEntries(IEnumerable<EntityEntry> entries)
            {
                foreach (var item in entries)
                {
                    Console.WriteLine($"{item.Entity.ToString()} - {item.State}");
                }
            }

            Console.ReadLine();
        }

    }
}
