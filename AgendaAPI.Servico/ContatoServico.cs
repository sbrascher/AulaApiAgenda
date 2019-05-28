using AgendaAPI.Dominio.Entidades;
using AgendaAPI.Dominio.Repositorios;
using AgendaAPI.Dominio.Servicos;
using AgendaAPI.Repositorio.Transacao;
using System;
using System.Collections.Generic;

namespace AgendaAPI.Servico
{
    public class ContatoServico : ServicoBase, IContatoServico
    {
        private readonly IContatoRepositorio repositorio;

        public ContatoServico(IContatoRepositorio repositorio, IUnitOfWork uow) : base(uow)
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
                Commit();
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
                Commit();
            }

            return erros;
        }

        public void Excluir(Contato contato)
        {
            repositorio.Excluir(contato);
            Commit();
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
