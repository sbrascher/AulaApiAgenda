using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaAPI.Dominio.Entidades;
using AgendaAPI.Dominio.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonesController : ControllerBase
    {
        private readonly ITelefoneServico servico;

        public TelefonesController(ITelefoneServico servico)
        {
            this.servico = servico;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Telefone telefone)
        {
            var erros = servico.Criar(telefone);

            if (erros.Count > 0)
            {
                return BadRequest(erros);
            }

            return CreatedAtAction("Get", new { id = telefone.Id }, telefone);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var contato = servico.Obter(id);

            if (contato == null)
                return NotFound();

            return Ok(contato);
        }
    }
}