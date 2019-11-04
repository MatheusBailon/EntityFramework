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

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());


                var produtos = contexto.Produtos.ToList();
                foreach (Produto p in produtos)
                {
                    Console.WriteLine(p);
                }
                var p1 = contexto.Produtos.Last();
                p1.Nome = "Carga Explosiva";
                Console.WriteLine("*".PadRight(10));

                var entriesList = contexto.ChangeTracker.Entries();
                foreach (var e in entriesList)
                {
                    Console.WriteLine(e.State);
                }

                contexto.SaveChanges();
            }


            //var p1 = contexto.Produtos.First();
            //p1.Nome = "Processo de Update sem usar o metodo UPDATE";
            //contexto.SaveChanges();

            //Console.ReadLine();
            //Console.WriteLine("*** APÓS A ATUALIZAÇÃO ***");
            //Console.ReadLine();

            //produtos = contexto.Produtos.ToList();
            //foreach (Produto p in produtos)
            //{
            //    Console.WriteLine(p);
            //}

            Console.ReadLine();
        }

    }
}
