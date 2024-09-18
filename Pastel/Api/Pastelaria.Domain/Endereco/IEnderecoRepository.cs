using Pastelaria.Domain.Endereco.Dto;  // Importação do namespace que contém o Dto de Endereço
using System.Collections.Generic;

namespace Pastelaria.Domain.Endereco
{
    // Esta interface define o contrato para interação com dados de Endereço.
    public interface IEnderecoRepository
    {
        // Método para adicionar um novo endereço
        // Aceita um objeto EnderecoDto representando o endereço a ser adicionado
        void Post(EnderecoDto endereco);
        IEnumerable<EnderecoDto> Get();
        IEnumerable<EnderecoDto> Get(int? id = null, string nome = null);
        void Delete(int id);
    }
}