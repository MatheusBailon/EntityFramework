using Microsoft.EntityFrameworkCore;
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
        public static object PromocaoDePascoa { get; private set; }

        static void Main(string[] args)
        {
            
            using(var segContexto = new LojaContext())
            {
                var serviceProvider = segContexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());


                var promocao = segContexto
                    .Promocoes
                    .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                    .FirstOrDefault();

                Console.WriteLine($"\nMostrando os itens da promocao {promocao.Descricao}");
                foreach (var p in promocao.Produtos)
                {
                    Console.WriteLine(p.Produto);
                }
            }


            Console.ReadLine();
        }

        private static void IncluirPromocao()
        {
            using (var contexto = new LojaContext())
            {
                var promocao = new Promocao();
                promocao.Descricao = "Queima Total Segundo semestre 2017";
                promocao.DataInicio = new DateTime(2017, 6, 1);
                promocao.DataTermino = new DateTime(2017, 10, 31);

                var produtos = contexto.Produtos.Where(p => p.Categoria == "Livros").ToList();
                foreach (var p in produtos)
                {
                    promocao.IncluirProduto(p);
                }

                contexto.Promocoes.Add(promocao);

                ExibeEntries(contexto.ChangeTracker.Entries());
                contexto.SaveChanges();
            }
        }

        private static void UmParaUm()
        {
            var mano = new Cliente();
            mano.Nome = "Osvaldo Oliveira";

            mano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 4,
                Logradouro = "Rua dos Ex-Treinadores",
                Bairro = "Centro",
                Cidade = "São Paulo"
            };

            using (var contexto = new LojaContext())
            {

                contexto.Clientes.Add(mano);
                contexto.SaveChanges();
            }
        }

        private static void MuitosParaMuitos()
        {
            Produto p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 1.25, Unidade = "Litros" };
            Produto p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.48, Unidade = "Gramas" }; ;
            Produto p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 3.79, Unidade = "Gramas" }; ;

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);


            //Adicionando produtos
            promocaoDePascoa.IncluirProduto(p1);
            promocaoDePascoa.IncluirProduto(p2);
            promocaoDePascoa.IncluirProduto(p3);


            //Adicionando a classe de Logger
            using (var contexto = new LojaContext())
            {
                //*** Adicionando Log (para exibir as consultas realizadas pelo Entity) ***
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());
                //*** Fim do Log ***

                //contexto.Promocoes.Add(promocaoDePascoa);
                var promocao = contexto.Promocoes.Find(1);
                contexto.Promocoes.Remove(promocao);
                contexto.SaveChanges();
            }
        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }

    }
}
