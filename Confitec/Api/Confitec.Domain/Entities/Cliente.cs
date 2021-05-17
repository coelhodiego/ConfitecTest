using System;

namespace Confitec.Domain.Entities
{
    /// <summary>
    /// Modelo referente ao cliente
    /// </summary>
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Escolaridade { get; set; }

        public void validaData()
        {
            if (DataNascimento.Date > DateTime.Now.Date)
                throw new Exception("Data de nascimento inválida");
        }
    }


}
