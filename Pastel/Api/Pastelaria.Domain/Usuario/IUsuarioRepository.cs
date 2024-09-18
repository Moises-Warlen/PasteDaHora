using Pastelaria.Domain.Usuario.Dto;
using System.Collections.Generic;

namespace Pastelaria.Domain.Usuario
{
    public interface IUsuarioRepository
    {
       
        IEnumerable<UsuariosDto> Get();
      
       
        UsuariosDto Get(int? id = null, string nome = null);

    
        int Post(UsuariosDto usuario);

        UsuariosDto PutDesativaUsuario(int IdUsuario);

       
        void Put(UsuariosDto usuario);
       
        UsuariosDto PostLogin(UsuariosDto usuario);
    }
}