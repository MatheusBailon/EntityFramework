﻿namespace Alura.Loja.Testes.ConsoleApp
{
    public class Endereco
    {
        public int Numero { get; internal set; }
        public string Logradouro { get; internal set; }
        public string Complemento { get; set; }
        public string Bairro { get; internal set; }
        public string Cidade { get; internal set; }
    }
}