using System;

namespace Pastelaria.Repository.Infra.HandledExceptions
{
    public class DbException : Exception
    {
        public DbException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}