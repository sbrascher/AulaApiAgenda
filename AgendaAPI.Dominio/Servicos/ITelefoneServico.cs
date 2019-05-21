using AgendaAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Dominio.Servicos
{
    public interface ITelefoneServico
    {
        List<string> Criar(Telefone contato);
        List<string> Atualizar(Telefone contato);
        void Excluir(Telefone contato);
        List<Telefone> ObterPorContato(int contatoId);
        Telefone Obter(int id);

    }
}
