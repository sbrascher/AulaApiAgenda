using AgendaAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Dominio.Repositorios
{
    public interface ITelefoneRepositorio
    {
        void Criar(Telefone telefone);
        void Atualizar(Telefone telefone);
        void Excluir(Telefone telefone);
        List<Telefone> ObterPorContato(int contatoId);
        Telefone Obter(int id);
    }
}
