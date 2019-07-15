using AgendaAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AgendaAPI.Dominio.Spacs
{
    public static class ContatoSpacs
    {
        public static Expression<Func<Contato, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }
    }
}
