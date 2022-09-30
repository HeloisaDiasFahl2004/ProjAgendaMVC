using Controllers;
using Models;
using System;
using System.Collections.Generic;

namespace ProjAgendaMVC
{
    internal class Program
    {
        // VIEW DO MVC
        static void Main(string[] args)
        {
            Console.WriteLine("\n<<< Contatos >>>");

            Contato c = new()
            {
                Nome = "Heloísa",
                Telefone = "12345678901"
            };
            new ContatoController().InserirContato(c);

           List<Contato> agendaContato = new ContatoController().ConsultaTodos();
            foreach (var item in agendaContato)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
