using AgendaAPI.Dominio.Entidades;
using AgendaAPI.Dominio.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ContatosController : ControllerBase
    {
        public IContatoServico servico { get; }

        public ContatosController(IContatoServico servico)
        {
            this.servico = servico;



        }

        // GET: api/Contato
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(servico.Obter());
        }

        // GET: api/Contato/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var contato = servico.Obter(id);

            if (contato == null)
                return NotFound();

            return Ok(contato);
        }

        // POST: api/Contato
        [HttpPost]
        public ActionResult Post([FromBody] Contato contato)
        {
            var erros = servico.Criar(contato);

            if (erros.Count > 0)
            {
                return BadRequest(erros);
            }

            return CreatedAtAction("Get", new { id = contato.Id }, contato);
        }

        // PUT: api/Contato/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Contato contato)
        {
            if (id != contato.Id)
                return BadRequest();

            var contatoSalvo = servico.Obter(id);

            if (contatoSalvo == null)
                return NotFound();

            contatoSalvo.Nome = contato.Nome;

            var erros = servico.Atualizar(contatoSalvo);

            if (erros.Count > 0)
                return BadRequest(erros);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var contato = servico.Obter(id);

            if (contato == null)
                return NotFound();

            servico.Excluir(contato);

            return Ok();
        }
    }
}
