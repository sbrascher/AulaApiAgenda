using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Repositorio.Transacao
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
