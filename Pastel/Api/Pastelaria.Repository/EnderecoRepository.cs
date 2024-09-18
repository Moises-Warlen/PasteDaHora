using System;
using System.Collections.Generic;
using Pastelaria.Domain.Endereco;
using Pastelaria.Domain.Endereco.Dto;
using Pastelaria.Repository.Infra;
using Pastelaria.Repository.Infra.Extensions;

namespace Pastelaria.Repository
{
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        public EnderecoRepository(IDatabaseConnection connection) : base(connection)
        {
        }

        // Enumeração que lista os procedimentos disponíveis para execução.
        private enum Procedures
        {
            CadastrarEnderecoUsuario,
            DeletarEnderecoUsuario,
            buscarTodosEndereco
        }
        public IEnumerable<EnderecoDto> Get()
        {
            ExecuteProcedure(Procedures.buscarTodosEndereco);
            using (var r = ExecuteReader())
                return r.CastEnumerable<EnderecoDto>();
        }

        public IEnumerable<EnderecoDto> Get(int? IdUsuario = default(int?), string nome = null)
        {
            ExecuteProcedure(Procedures.buscarTodosEndereco);
            AddParameter("@IdUsuario", IdUsuario);
            using (var r = ExecuteReader())
                return r.CastEnumerable<EnderecoDto>();
        }
        public void Post(EnderecoDto endereco)
        {
            ExecuteProcedure(Procedures.CadastrarEnderecoUsuario); // Executar procedimento armazenado para inserir endereço
            // Adicionar parâmetros para os dados do endereço
            AddParameter("@IdUsuario", endereco.IdUsuario);
            AddParameter("@Cep", endereco.Cep);
            AddParameter("@Cidade", endereco.Cidade);
            AddParameter("@Bairro", endereco.Bairro);
            AddParameter("@Rua", endereco.Rua);
            AddParameter("@Numero", endereco.Numero);
            AddParameter("@Complemento", endereco.Complemento);
            ExecuteNonQuery();  // Executar comando não-query (operação de inserção)
        }


        public void Delete(int id)
        {
            ExecuteProcedure(Procedures.DeletarEnderecoUsuario);
            AddParameter("@IdEndereco", id);
            ExecuteNonQuery();  // Executando comando não-query (operação de inserção)
        }

      
    }
}
