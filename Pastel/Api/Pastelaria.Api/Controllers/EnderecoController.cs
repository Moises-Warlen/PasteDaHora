
using Pastelaria.Domain.Endereco;
using Pastelaria.Domain.Endereco.Dto;
using System.Web.Http;

namespace Pastelaria.Api.Controllers
{
    [RoutePrefix("api/endereco")]  
    public class EnderecoController : ApiController
    {
        private readonly IEnderecoRepository _enderecoRepository;  
        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;  
        }
       
        //[HttpPost, Route("adicionar")] 
        //public IHttpActionResult Post(EnderecoDto endereco)
        //{
        //    _enderecoRepository.Post(endereco);
        //    return Ok(); 
        //}

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var endereco = _enderecoRepository.Get(id);
            return Ok(endereco);
        }
      
        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _enderecoRepository.Delete(id); 

            return Ok(); 
        }
    }
}