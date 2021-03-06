﻿using AgendaAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Dominio.Scopes
{
    public static class TelefoneScope
    {
        public static List<string> ValidarCriacao(this Telefone telefone)
        {
            var erros = new List<string>();

            if (String.IsNullOrEmpty(telefone.Numero))
                erros.Add("Número não informado.");

            if (telefone.ContatoId == 0)
                erros.Add("Contato não informado.");

            return erros;
        }

        public static List<string> ValidarAlteracao(this Telefone telefone)
        {
            return ValidarCriacao(telefone);
        }
    }
}
