using AgendaAPI.Dominio.Entidades;
using AgendaAPI.Dominio.Scopes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Teste.Scopes
{
    [TestClass]
    public class ContatoScopeTeste
    {
        [TestMethod]
        public void Contato_sem_nome()
        {
            var contato = new Contato();
            var erros = contato.ValidarCriacao();
            Assert.IsTrue(erros.Count == 1 && erros[0] == "Nome não informado.");
        }

        [TestMethod]
        public void Contato_com_nome()
        {
            var contato = new Contato { Nome = "Sérgio" };
            var erros = contato.ValidarCriacao();
            Assert.IsTrue(erros.Count == 0);
        }
    }
}
