using AgendaAPI.Dominio.Entidades;
using AgendaAPI.Dominio.Repositorios;
using AgendaAPI.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace AgendaAPI.Servico
{
    public class ContatoServico : IContatoServico
    {
        private readonly IContatoRepositorio repositorio;

        public ContatoServico(IContatoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<string> Atualizar(Contato contato)
        {
            var erros = new List<string>();

            if (String.IsNullOrEmpty(contato.Nome))
                erros.Add("Nome não informado.");

            if (erros.Count == 0)
            {
                repositorio.Atualizar(contato);
            }

            return erros;
        }

        public List<string> Criar(Contato contato)
        {
            var erros = new List<string>();

            if (String.IsNullOrEmpty(contato.Nome))
                erros.Add("Nome não informado.");

            if (erros.Count == 0)
            {
                repositorio.Criar(contato);
            }

            return erros;
        }

        public void Excluir(Contato contato)
        {
            repositorio.Excluir(contato);
        }

        public List<Contato> Obter()
        {
            return repositorio.Obter();
        }

        public Contato Obter(int id)
        {
            return repositorio.Obter(id);
        }
    }
}
