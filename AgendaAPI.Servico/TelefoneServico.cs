﻿using AgendaAPI.Dominio.Entidades;
using AgendaAPI.Dominio.Repositorios;
using AgendaAPI.Dominio.Servicos;
using AgendaAPI.Repositorio.Transacao;
using System;
using System.Collections.Generic;

namespace AgendaAPI.Servico
{
    public class TelefoneServico : ServicoBase, ITelefoneServico
    {
        private readonly ITelefoneRepositorio repositorio;
        private readonly IContatoRepositorio contatoRepositorio;

        public TelefoneServico(
            ITelefoneRepositorio repositorio,
            IContatoRepositorio contatoRepositorio, IUnitOfWork uow) : base(uow)
        {
            this.repositorio = repositorio;
            this.contatoRepositorio = contatoRepositorio;
        }

        public List<string> Atualizar(Telefone telefone)
        {
            var erros = new List<string>();

            if (String.IsNullOrEmpty(telefone.Numero))
                erros.Add("Número não informado.");

            if (erros.Count == 0)
            {
                repositorio.Atualizar(telefone);
                Commit();
            }

            return erros;
        }

        public List<string> Criar(Telefone telefone)
        {
            var erros = new List<string>();

            if (String.IsNullOrEmpty(telefone.Numero))
                erros.Add("Número não informado.");

            if (telefone.ContatoId == 0)
                erros.Add("Contato não informado.");
            else
                telefone.Contato = contatoRepositorio.Obter(telefone.ContatoId);

            if (erros.Count == 0)
            {
                repositorio.Criar(telefone);
                Commit();
            }

            return erros;
        }

        public void Excluir(Telefone telefone)
        {
            repositorio.Excluir(telefone);
            Commit();
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
