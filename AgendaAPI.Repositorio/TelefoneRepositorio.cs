using AgendaAPI.Dominio.Entidades;
using AgendaAPI.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaAPI.Repositorio
{
    public class TelefoneRepositorio : ITelefoneRepositorio
    {
        private readonly AgendaContext contexto;

        public TelefoneRepositorio(AgendaContext contexto)
        {
            this.contexto = contexto;
        }

        public void Atualizar(Telefone telefone)
        {
            contexto.Entry<Telefone>(telefone).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Criar(Telefone telefone)
        {
            contexto.Telefones.Add(telefone);
            contexto.SaveChanges();
        }

        public void Excluir(Telefone telefone)
        {
            contexto.Telefones.Remove(telefone);
            contexto.SaveChanges();
        }

        public List<Telefone> ObterPorContato(int contatoId)
        {
            return contexto.Telefones.ToList();
        }

        public Telefone Obter(int id)
        {
            return contexto.Telefones.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
