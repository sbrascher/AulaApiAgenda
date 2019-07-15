using AgendaAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AgendaAPI.Dominio.Spacs
{
    public static class TelefoneSpacs
    {
        public static Expression<Func<Telefone, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }
    }
}
