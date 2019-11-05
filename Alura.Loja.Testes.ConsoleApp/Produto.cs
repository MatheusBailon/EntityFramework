using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Produto
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double PrecoUnitario { get; internal set; }
        public string Unidade{ get; internal set; }
        //Nesta classe da mesma forma que em promocao, ela irá apontar para a classe auxiliar
        public IList<PromocaoProduto> Promocoes { get; set; }

        public override string ToString()
        {
            return $"Produto: {Id} {Nome}, {Categoria}, {PrecoUnitario}";
        }
    }
}