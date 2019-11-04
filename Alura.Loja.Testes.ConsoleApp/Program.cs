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
            //GravarUsandoAdoNet();
            //GravarUsandoEntity();
            RecuperarProdutos();
            //RemoveProduto();
            AtualizaProduto();
            RecuperarProdutos();
        }

        private static void AtualizaProduto()
        {
            using (var repo = new ProdutoEntityDAO())
            {
                var primeiro = repo.Produtos.First();
                primeiro.Nome = "Alterado";
                primeiro.Categoria = "Filme";
                repo.Produtos.Update(primeiro);
                repo.SaveChanges();
            }
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new ProdutoEntityDAO())
            {
                var produtos = repo.Produtos.ToList();

                foreach (Produto p in produtos)
                {
                    Console.WriteLine(p);
                }
            }

            Console.ReadLine();
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            Produto p2 = new Produto();
            p2.Nome = "A Arte da Guerra";
            p2.Categoria = "Livros";
            p2.Preco = 20.99;

            Produto p3 = new Produto();
            p3.Nome = "Curso Entity Framework Core para leitos";
            p3.Categoria = "Livros";
            p3.Preco = 12;

            using (var contexto = new ProdutoEntityDAO())
            {
                contexto.Adicionar(p);
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoEntityDAO())
            {
                repo.Adicionar(p);
            }
        }

        private static void RemoveProduto(int idProduto = 0)
        {
            if (idProduto == 0)
            {
                Console.WriteLine("Informe um id");
                idProduto = Convert.ToInt32(Console.ReadLine());
            }
            
            using(var repo = new ProdutoEntityDAO())
            {
                var produto = repo.Produtos.Find(idProduto);
                repo.Produtos.Remove(produto);
                repo.SaveChanges();
            }
            RecuperarProdutos();
        }
    }
}
