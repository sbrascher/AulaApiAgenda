using AgendaAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Dominio.Repositorios
{
    public interface IUsuarioRepositorio
    {
        void Criar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Excluir(Usuario usuario);
        List<Usuario> Obter();
        Usuario Obter(int id);
        Usuario Obter(string email);
    }
}
