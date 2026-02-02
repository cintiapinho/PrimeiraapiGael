using Microsoft.AspNetCore.Mvc;
using PrimeiraapiGael.Models;
using PrimeiraapiGael.Services;

namespace PrimeiraapiGael.Controllers.v1
{
    [ApiController]
    // Define a rota com versionamento: api/v1/funcionarios
    [Route("api/v1/[controller]")]
    public class FuncionariosController : ControllerBase
    {
        private readonly FuncionarioService _service = new();

        [HttpGet]
        public ActionResult<List<Funcionario>> Get() => Ok(_service.ObterFuncionarios());

        [HttpPost]
        public IActionResult Post([FromBody] Funcionario funcionario)
        {
            _service.CriarFuncionario(funcionario);
            return CreatedAtAction(nameof(Get), funcionario);
        }
    }
}