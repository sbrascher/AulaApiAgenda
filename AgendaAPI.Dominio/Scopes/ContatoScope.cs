﻿using AgendaAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Dominio.Scopes
{
    public static class ContatoScope
    {
        public static List<string> ValidarCriacao(this Contato contato)
        {
            var erros = new List<string>();

            if (String.IsNullOrEmpty(contato.Nome))
                erros.Add("Nome não informado.");

            return erros;
        }

        public static List<string> ValidarAlteracao(this Contato contato)
        {
            return ValidarCriacao(contato);
        }
    }
}
