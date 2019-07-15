using AgendaAPI.Dominio.Entidades;
using AgendaAPI.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaAPI.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AgendaContext contexto;

        public UsuarioRepositorio(AgendaContext contexto)
        {
            this.contexto = contexto;
        }

        public void Atualizar(Usuario usuario)
        {
            contexto.Entry<Usuario>(usuario).State = EntityState.Modified;
        }

        public void Criar(Usuario usuario)
        {
            contexto.Usuarios.Add(usuario);
        }

        public void Excluir(Usuario usuario)
        {
            contexto.Usuarios.Remove(usuario);
        }

        public List<Usuario> Obter()
        {
            return contexto.Usuarios.ToList();
        }

        public Usuario Obter(int id)
        {
            return contexto.Usuarios
                .Where(x => x.Id == id).SingleOrDefault();
        }

        public Usuario Obter(string email)
        {
            return contexto.Usuarios
                .Where(x => x.Email == email).SingleOrDefault();
        }
    }
}
