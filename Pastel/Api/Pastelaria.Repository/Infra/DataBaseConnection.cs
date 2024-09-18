using System;
using System.Data;
using System.Data.SqlClient;

namespace Pastelaria.Repository.Infra
{
    public class DatabaseConnection : IDatabaseConnection, IDisposable
    {
        public DatabaseConnection()
        {
           // Configuração da conexão com o banco de dados SQL Server
                 SqlConnection = new SqlConnection(
                "Data Source=DESKTOP-NU4F6NT;" + // Nome do servidor
                "Initial Catalog=PastelDaHora;" + // Nome da base de dados
                "Integrated Security=True;" + // Usar a autenticação do Windows
                "Connection Timeout=300" // Tempo limite para conexão (em segundos)

            );
        }

        public SqlConnection SqlConnection { get; }
        public SqlTransaction SqlTransaction { get; set; }

        private void OpenConnection()
        {
            if (SqlConnection.State == ConnectionState.Broken)
            {
                SqlConnection.Close();
                SqlConnection.Open();
            }

            if (SqlConnection.State == ConnectionState.Closed)
                SqlConnection.Open();
        }

        public void OpenTransaction()
        {
            OpenConnection();
            SqlTransaction = SqlConnection.BeginTransaction();
        }

        public void OpenTransaction(IsolationLevel isolationLevel)
        {
            OpenConnection();
            SqlTransaction = SqlConnection.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            SqlTransaction.Commit();
            SqlTransaction.Dispose();
        }

        public void Rollback()
        {
            SqlTransaction.Rollback();
            SqlTransaction.Dispose();
        }

        public void Dispose()
        {
            SqlConnection.Close();
        }
    }
}