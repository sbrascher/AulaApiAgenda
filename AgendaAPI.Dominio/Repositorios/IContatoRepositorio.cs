using AgendaAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Dominio.Repositorios
{
    public interface IContatoRepositorio
    {
        void Criar(Contato contato);
        void Atualizar(Contato contato);
        void Excluir(Contato contato);
        List<Contato> Obter();
        Contato Obter(int id);
    }
}
