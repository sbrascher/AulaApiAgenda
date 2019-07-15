using AgendaAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace AgendaAPI.Dominio.Spacs
{
    public static class UsuarioSpacs
    {
        public static Expression<Func<Usuario, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }


    }
}
