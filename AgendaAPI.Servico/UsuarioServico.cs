using AgendaAPI.Dominio.Entidades;
using AgendaAPI.Dominio.Repositorios;
using AgendaAPI.Dominio.Scopes;
using AgendaAPI.Dominio.Servicos;
using AgendaAPI.Repositorio.Transacao;
using AgendaAPI.Servico.Interfaces;
using AgendaAPI.Servico.Seguranca;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace AgendaAPI.Servico
{
    public class UsuarioServico : ServicoBase, IUsuarioServico
    {
        private readonly IUsuarioRepositorio repositorio;
        private readonly ICriptografiaServico criptografiaServico;
        private readonly SigningConfigurations signingConfigurations;
        private TokenConfigurations tokenConfigurations;

        public UsuarioServico(
            IUsuarioRepositorio repositorio, 
            IUnitOfWork uow, 
            ICriptografiaServico criptografiaServico,
            SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations) : base(uow)
        {
            this.repositorio = repositorio;
            this.criptografiaServico = criptografiaServico;
            this.signingConfigurations = signingConfigurations;
            this.tokenConfigurations = tokenConfigurations;
        }

        public List<string> Autenticar(string email, string senha, out string accessToken)
        {
            accessToken = String.Empty;

            var usuario = repositorio.Obter(email);

            if (usuario == null)
                return new List<string> { "Usuário ou senha inválidos" };

            var erros = usuario.ValidarLogin(email, senha);

            senha = criptografiaServico.Criptografar(senha);

            if (senha != usuario.Senha)
                return new List<string> { "Usuário ou senha inválidos" };
            else
            {
                var token = GenerateToken(usuario);
                accessToken = token.AccessToken;
            }

            return erros;
        }

        public Token GenerateToken(Usuario usuario)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(usuario.Id.ToString(), "Login"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Id.ToString())
                }
            );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return new Token()
            {
                Authenticated = true,
                Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                Message = "OK"
            };
        }

        public List<string> Atualizar(Usuario usuario)
        {
            var erros = usuario.ValidarAlteracao();

            if (erros.Count == 0)
            {
                repositorio.Atualizar(usuario);
                Commit();
            }

            return erros;
        }

        public List<string> Criar(Usuario usuario)
        {
            var erros = usuario.ValidarCriacao();

            if (erros.Count == 0)
            {
                usuario.Senha = criptografiaServico.Criptografar(usuario.Senha);
                repositorio.Criar(usuario);
                Commit();
            }

            return erros;
        }

        public void Excluir(Usuario usuario)
        {
            repositorio.Excluir(usuario);
            Commit();
        }

        public List<Usuario> Obter()
        {
            return repositorio.Obter();
        }

        public Usuario Obter(int id)
        {
            return repositorio.Obter(id);
        }

        public Usuario Obter(string email)
        {
            return repositorio.Obter(email);
        }
    }
}
