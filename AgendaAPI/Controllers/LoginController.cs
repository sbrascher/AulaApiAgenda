using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaAPI.Dominio.Servicos;
using AgendaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioServico _servico;
        public LoginController(IUsuarioServico servico)
        {
            _servico = servico;
        }

        [HttpPost]
        public ActionResult Post([FromBody] LoginModel model)
        {
            string accessToken = String.Empty;
            var erros = _servico.Autenticar(model.Email, model.Senha, out accessToken);

            if (erros.Count > 0)
                return BadRequest(erros);

            return Ok(new { accessToken });
        }
    }
}