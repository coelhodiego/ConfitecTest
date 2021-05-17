using System;

namespace Confitec.Api.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Escolaridades Escolaridade { get; set; }
    }

    public enum Escolaridades
    {
        Infantil = 1,
        Fundamental = 2,
        Medio = 3,
        Superior = 4
    }
}
