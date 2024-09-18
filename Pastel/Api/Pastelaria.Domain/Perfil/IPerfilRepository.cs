using Pastelaria.Domain.Perfil.Dto;
using System.Collections.Generic;

namespace Pastelaria.Domain.Perfil
{
   public interface IPerfilRepository
    {
        IEnumerable<PerfilDto> Get();
    }
}
