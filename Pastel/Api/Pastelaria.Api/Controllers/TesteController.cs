using Pastelaria.Api.Infra.Configuration;
using Pastelaria.Domain.Teste;
using Pastelaria.Domain.Teste.Dto;
using System.Web.Http;

namespace Pastelaria.Api.Controllers
{
    [RoutePrefix("api/teste")]
    public class TesteController : AuthApiController
    {
        private readonly ITesteRepository _testeRepository;

        public TesteController(ITesteRepository testeRepository)
        {
            _testeRepository = testeRepository;
        }

        [HttpGet, Route("todos")]
        public IHttpActionResult GetTestes()
        {
            return Ok(_testeRepository.Get());
        }


        [HttpPost, Route("")]
        public IHttpActionResult Post(TesteDto teste)
        {
            _testeRepository.Post(teste);

            return Ok();
        }
    }
}
