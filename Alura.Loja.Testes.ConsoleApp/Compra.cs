namespace Alura.Loja.Testes.ConsoleApp
{
    internal class Compra
    {
        
        public int Id { get; set; }
        public int Quantidade { get; internal set; }

        //Esta propriedade ProdutoId foi adicionada, apra que no momento em que fosse executado o Migration ele pudesse setar esta coluna como not null
        public int ProdutoId { get; set; }
        public Produto Produto { get; internal set; }
        public double Preco { get; internal set; }
    }
}
