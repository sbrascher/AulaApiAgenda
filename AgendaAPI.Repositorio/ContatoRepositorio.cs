using AgendaAPI.Dominio.Entidades;
using AgendaAPI.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaAPI.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly AgendaContext contexto;

        public ContatoRepositorio(AgendaContext contexto)
        {
            this.contexto = contexto;
        }

        public void Atualizar(Contato contato)
        {
            contexto.Entry<Contato>(contato).State = EntityState.Modified;
        }

        public void Criar(Contato contato)
        {
            contexto.Contatos.Add(contato);
        }

        public void Excluir(Contato contato)
        {
            contexto.Contatos.Remove(contato);
        }

        public List<Contato> Obter()
        {
            return contexto.Contatos.ToList();
        }

        public Contato Obter(int id)
        {
            return contexto.Contatos
                .Include(x => x.Telefones)
                .Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
