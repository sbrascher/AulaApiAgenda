using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
