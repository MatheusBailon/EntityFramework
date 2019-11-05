using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Promocao
    {
        public Promocao()
        {
            this.Produtos = new List<PromocaoProduto>();
        }
        public int Id { get; internal set; }
        public string Descricao { get; internal set; }
        public DateTime DataInicio { get; internal set; }
        //Referencia a classe auxiliar (que liga a entidade de relacionamento N:N)
        public IList<PromocaoProduto> Produtos { get; internal set; }
        public DateTime DataTermino { get; internal set; }

        internal void IncluirProduto(Produto produto)
        {
            var promProd = new PromocaoProduto();
            promProd.produto = produto;
            Produtos.Add(promProd);
        }
    }
}
