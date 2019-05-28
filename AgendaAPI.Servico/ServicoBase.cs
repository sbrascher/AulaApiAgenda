using AgendaAPI.Repositorio.Transacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Servico
{
    public class ServicoBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicoBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Commit()
        {
            _unitOfWork.Commit();
            return true;
        }

        public void Rollback(string message)
        {
            _unitOfWork.Rollback();
        }

        public void Rollback()
        {
            _unitOfWork.Rollback();
        }
    }
}
