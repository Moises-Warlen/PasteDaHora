using Pastelaria.Domain.Teste.Dto;
using System.Collections.Generic;

namespace Pastelaria.Domain.Teste
{
    public interface ITesteRepository
    {
        IEnumerable<TesteDto> Get();
        void Post(TesteDto teste);
    }
}