using AgendaAPI.Dominio.Entidades;
using AgendaAPI.Dominio.Spacs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaAPI.Teste.Spacs
{
    [TestClass]
    public class ContatoSpacsTeste
    {
        List<Contato> contadosFake = new List<Contato>();
        public ContatoSpacsTeste()
        {
            contadosFake.Add(new Contato
            {
                Id = 1,
                Nome = "Maria"
            });

            contadosFake.Add(new Contato
            {
                Id = 2,
                Nome = "João"
            });

            contadosFake.Add(new Contato
            {
                Id = 3,
                Nome = "Paulo"
            });
        }

        [TestMethod]
        public void Obter_usuario_por_id()
        {
            var contato = contadosFake.AsQueryable().Where(ContatoSpacs.GetById(1)).SingleOrDefault();

            Assert.IsTrue(contato.Id == 1);
        }

        [TestMethod]
        public void Obter_usuario_por_id_nao_encontrado()
        {
            var contato = contadosFake.AsQueryable().Where(ContatoSpacs.GetById(5)).SingleOrDefault();

            Assert.IsNull(contato);
        }
    }
}
