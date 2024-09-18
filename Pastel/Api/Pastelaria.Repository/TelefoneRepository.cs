using Pastelaria.Domain.Telefone;
using Pastelaria.Repository.Infra;
using Pastelaria.Domain.Telefone.Dto;
using System.Collections.Generic;
using Pastelaria.Repository.Infra.Extensions;

namespace Pastelaria.Repository
{
    public class TelefoneRepository : BaseRepository, ITelefoneRepository  // Definindo a classe e implementando a interface
    {
        public TelefoneRepository(IDatabaseConnection connection) : base(connection)  // Construtor para inicializar com conexão de banco de dados
        {
        }

        // Enumeração que define os procedimentos armazenados (supondo nomes de procedimentos)
        private enum Procedures
        {
            CadastrarTelefoneUsuario,
            DeletarTelefoneUsuario,
            buscarTodosTelefones
        }
        // Obter todos os telefone
        public IEnumerable<TelefoneDto> Get()
        {
            ExecuteProcedure(Procedures.buscarTodosTelefones);
            using (var r = ExecuteReader())
                return r.CastEnumerable<TelefoneDto>();
        }
     
        public IEnumerable<TelefoneDto> Get(int? IdUsuario = default(int?), string nome = null)
        {
            ExecuteProcedure(Procedures.buscarTodosTelefones);

            AddParameter("@IdUsuario", IdUsuario);
            using (var r = ExecuteReader())
                return r.CastEnumerable<TelefoneDto>();
        }

        public void Delete(int id)
        {
            ExecuteProcedure(Procedures.DeletarTelefoneUsuario);
            AddParameter("@IdTelefone", id);
            ExecuteNonQuery();  // Executando comando não-query (operação de inserção)
        }

        public void Post(TelefoneDto telefone)
        {
            ExecuteProcedure(Procedures.CadastrarTelefoneUsuario);  // Chamando procedimento armazenado para adicionar telefone para usuário existente
            AddParameter("@IdUsuario", telefone.IdUsuario);  // Adicionando parâmetros para o procedimento armazenado
            AddParameter("@Telefone", telefone.Telefone);
            AddParameter("@Tipo", telefone.Tipo);

            ExecuteNonQuery();  // Executando comando não-query (operação de inserção)
        }
    }
}