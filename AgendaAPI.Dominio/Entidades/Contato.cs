using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Dominio.Entidades
{
    public class Contato
    {
        public Contato()
        {
            Telefones = new List<Telefone>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Telefone> Telefones { get; set; }

    }

    public static class QQNome
    {
        public static void Teste(this Contato contato)
        {
            //
        }
    }
}
