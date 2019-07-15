using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Servico.Interfaces
{
    public interface ICriptografiaServico
    {
        string Criptografar(string stringDecriptografada);
    }
}
