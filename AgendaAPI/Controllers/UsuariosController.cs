using AgendaAPI.Dominio.Entidades;
using AgendaAPI.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IUsuarioServico servico { get; }

        public UsuariosController(IUsuarioServico servico)
        {
            this.servico = servico;
        }

        // GET: api/Usuarios
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(servico.Obter());
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            var contato = servico.Obter(id);

            if (contato == null)
                return NotFound();

            return Ok(contato);
        }

        // POST: api/Usuarios
        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            var erros = servico.Criar(usuario);

            if (erros.Count > 0)
            {
                return BadRequest(erros);
            }

            return CreatedAtAction("Get", new { id = usuario.Id }, usuario);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest();

            var usuarioSalvo = servico.Obter(id);

            if (usuarioSalvo == null)
                return NotFound();

            usuarioSalvo.Nome = usuario.Nome;

            var erros = servico.Atualizar(usuarioSalvo);

            if (erros.Count > 0)
                return BadRequest(erros);

            return Ok();
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var usuario = servico.Obter(id);

            if (usuario == null)
                return NotFound();

            servico.Excluir(usuario);

            return Ok();
        }
    }
}
