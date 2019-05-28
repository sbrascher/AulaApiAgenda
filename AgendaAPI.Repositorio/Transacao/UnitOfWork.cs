using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Repositorio.Transacao
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AgendaContext _context;

        public UnitOfWork(AgendaContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Não faz nada :)
        }
    }
}
