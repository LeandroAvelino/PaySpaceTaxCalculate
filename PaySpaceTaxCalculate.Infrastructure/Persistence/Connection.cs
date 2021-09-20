using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PaySpaceTaxCalculate.Core.Interfaces.Repository;

namespace PaySpaceTaxCalculate.Infrastructure.Persistence
{
    public class Connection : IConnection
    {
        public Connection(string connectionString)
        {
            Connect = new SqlConnection(connectionString);
        }
        public void Dispose()
        {
            Close();
        }

        public SqlConnection Connect { get; }
        public SqlConnection Open()
        {
            if (Connect == null)
                throw new Exception("No instance class implemented.");
            if (Connect.State != System.Data.ConnectionState.Open)
            {
                Connect.Open();
            }
            return Connect;
        }

        public void Close()
        {
            if (Connect == null || Connect.State != System.Data.ConnectionState.Open) 
                return;
            Connect.Close();
            Connect.Dispose();
        }

        public SqlCommand CreateCommand()
        {
            return Open()
                .CreateCommand();
        }
    }
}
