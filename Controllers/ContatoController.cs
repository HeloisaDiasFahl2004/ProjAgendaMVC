using Models;
using Services;
using System;
using System.Collections.Generic;

namespace Controllers
{
    public class ContatoController
    {
        //Métodos de criação

        public Contato InserirContato(Contato contato)
        {
            return new ContatoServices().InserirContato(contato);
        }
        public List<Contato> ConsultaTodos()
        {
            return new ContatoServices().ConsultaTodos();
        }
    }
}
