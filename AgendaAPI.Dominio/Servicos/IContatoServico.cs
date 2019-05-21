using AgendaAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Dominio.Servicos
{
    public interface IContatoServico
    {
        List<string> Criar(Contato contato);
        List<string> Atualizar(Contato contato);
        void Excluir(Contato contato);
        List<Contato> Obter();
        Contato Obter(int id);

    }
}
