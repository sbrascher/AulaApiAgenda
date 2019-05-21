using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Dominio.Entidades
{
    public class Telefone
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public ETipoTelefone TipoTelefone { get; set; }

        public Contato Contato { get; set; }
        public int ContatoId { get; set; }
    }
}
