using System;

namespace ContactManager.Model
{
    public class Contato
    {
        public string NomeCompleto { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Grupo { get; set; }
    }
}
