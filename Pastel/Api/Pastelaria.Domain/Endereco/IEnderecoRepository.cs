using Pastelaria.Domain.Endereco.Dto;  // Importação do namespace que contém o Dto de Endereço
using System.Collections.Generic;

namespace Pastelaria.Domain.Endereco
{
    // Esta interface define o contrato para interação com dados de Endereço.
    public interface IEnderecoRepository
    {
  
        IEnumerable<EnderecoDto> Get();
        IEnumerable<EnderecoDto> Get(int? id = null, string nome = null);
        void Delete(int id);
        void Post(int idUsuario, EnderecoDto endereco);
        void DeletePorUsuario(int idUsuario);
    }
}