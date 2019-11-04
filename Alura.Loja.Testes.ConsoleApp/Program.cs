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
            compra.Quantidade = 6;
            compra.Produto = pao;
            compra.Preco = pao.PrecoUnitario * compra.Quantidade;
        }

    }
}
