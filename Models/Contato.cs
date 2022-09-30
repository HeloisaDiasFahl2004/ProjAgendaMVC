using System;

namespace Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public override string ToString()
        {
            return "\nID: " + this.Id + "\nNome: " + this.Nome + "\nTelefone: " + this.Telefone;
        }


    }
}
