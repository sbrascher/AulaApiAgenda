using AgendaAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AgendaAPI.Dominio.Scopes
{
    public static class UsuarioScope
    {
        public static List<string> ValidarCriacao(this Usuario usuario)
        {
            var erros = new List<string>();

            if (String.IsNullOrEmpty(usuario.Nome))
                erros.Add("Nome não informado.");

            return erros;
        }

        public static List<string> ValidarAlteracao(this Usuario usuario)
        {
            return ValidarCriacao(usuario);
        }

        public static List<string> ValidarLogin(this Usuario usuario, string email, string senha)
        {
            var erros = new List<string>();

            if (String.IsNullOrEmpty(email))
                erros.Add("Email não informado.");

            if (String.IsNullOrEmpty(senha))
                erros.Add("Email não informado.");

            return erros;
            
        }

    }
}
