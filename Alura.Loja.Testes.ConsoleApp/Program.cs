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

            var mano = new Cliente();
            mano.Nome = "Dino da Silva Sauro";

            mano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 4,
                Logradouro = "Rua dos Alferneiros",
                Bairro = "Centro",
                Cidade = "Inglaterra"
            };

            using(var contexto = new LojaContext())
            {
                contexto.Clientes.Add(mano);
                contexto.SaveChanges();
            }

            Console.ReadLine();
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
