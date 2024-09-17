using System;
using System.Data;
using System.Data.SqlClient;

namespace Pastelaria.Repository.Infra
{
    public class DatabaseConnection : IDatabaseConnection, IDisposable
    {
        public DatabaseConnection()
        {
            SqlConnection = new SqlConnection(
                $"server=10.30.26.4;" +
                $"Database=GrupoKasilHomolog;" +
                $"user id=homolog;" +
                $"password=Homo1452@;" +
                "Connection Timeout=300"
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