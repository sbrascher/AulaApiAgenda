using AgendaAPI.Dominio.Entidades;
using AgendaAPI.Dominio.Repositorios;
using AgendaAPI.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace AgendaAPI.Servico
{
    public class TelefoneServico : ITelefoneServico
    {
        private readonly ITelefoneRepositorio repositorio;

        public TelefoneServico(ITelefoneRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<string> Atualizar(Telefone telefone)
        {
            var erros = new List<string>();

            if (String.IsNullOrEmpty(telefone.Numero))
                erros.Add("Número não informado.");

            if (erros.Count == 0)
            {
                repositorio.Atualizar(telefone);
            }

            return erros;
        }

        public List<string> Criar(Telefone telefone)
        {
            var erros = new List<string>();

            if (String.IsNullOrEmpty(telefone.Numero))
                erros.Add("Número não informado.");

            if (erros.Count == 0)
            {
                repositorio.Criar(telefone);
            }

            return erros;
        }

        public void Excluir(Telefone telefone)
        {
            repositorio.Excluir(telefone);
        }

        public List<Telefone> ObterPorContato(int contatoId)
        {
            return repositorio.ObterPorContato(contatoId);
        }

        public Telefone Obter(int id)
        {
            return repositorio.Obter(id);
        }
    }
}
