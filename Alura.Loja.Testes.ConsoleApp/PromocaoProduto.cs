﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class PromocaoProduto
    {
        public int ProdutoId { get; set; }
        public Produto produto { get; set; }

        public int PromocaoId { get; set; }
        public Promocao promocao { get; set; }
    }
}
