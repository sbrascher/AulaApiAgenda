using AgendaAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Dominio.Servicos
{
    public interface IUsuarioServico
    {
        List<string> Criar(Usuario usuario);
        List<string> Atualizar(Usuario usuario);
        void Excluir(Usuario usuario);
        List<Usuario> Obter();
        Usuario Obter(int id);
        Usuario Obter(string email);

        List<string> Autenticar(string email, string senha, out string token);

    }
}
