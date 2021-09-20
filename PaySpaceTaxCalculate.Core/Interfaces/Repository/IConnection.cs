using System;
using System.Data.SqlClient;

namespace PaySpaceTaxCalculate.Core.Interfaces.Repository
{
    public interface IConnection : IDisposable
    {
        SqlConnection Connect { get; }
        SqlConnection Open();
        void Close();
        SqlCommand CreateCommand();
    }
}
