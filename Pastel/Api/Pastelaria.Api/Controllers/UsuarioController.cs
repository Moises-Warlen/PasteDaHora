using Pastelaria.Api.Infra.Configuration;
using Pastelaria.Domain.Endereco;
using Pastelaria.Domain.Telefone;
using Pastelaria.Domain.Usuario;
using Pastelaria.Domain.Usuario.Dto;
using System.Web.Http;

namespace Pastelaria.Api.Controllers
{
    // Controlador responsável por gerenciar operações relacionadas aos usuários da aplicação.
    [RoutePrefix("api/usuario")] // Define um prefixo de rota para todos os endpoints deste controlador.
    public class UsuarioController : AuthApiController
    {
        // Repositórios utilizados para acessar e manipular dados relacionados a usuários, endereços e telefones.
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly ITelefoneRepository _telefoneRepository;

        // Construtor que recebe instâncias dos repositórios para operações de CRUD.
        public UsuarioController(IUsuarioRepository usuarioRepository, IEnderecoRepository enderecoRepository, ITelefoneRepository telefoneRepository)
        {
            _usuarioRepository = usuarioRepository;
            _enderecoRepository = enderecoRepository;
            _telefoneRepository = telefoneRepository;
        }

        // Endpoint para obter todos os usuários.
        [HttpGet, Route("todos")]
        public IHttpActionResult GetUsuarios()
        {
            var usuarios = _usuarioRepository.Get();
            return Ok(usuarios);
        }

        // Endpoint para obter um usuário específico por ID (opcional).
        [HttpGet, Route("{idUsuario}")]
        public IHttpActionResult Get(int? idUsuario = null)
        {
            var usuarios = _usuarioRepository.Get(idUsuario);
            return Ok(usuarios);
        }

        // Endpoint para desativar um usuário (ao invés de deletar).
        [HttpDelete, Route("{idUsuario}")]
        public IHttpActionResult Delete(int idUsuario)
        {
            _usuarioRepository.PutDesativaUsuario(idUsuario);
            return Ok();
        }
    }
}