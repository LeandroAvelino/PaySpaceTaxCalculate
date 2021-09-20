using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaySpaceTaxCalculate.Core.Entities;
using PaySpaceTaxCalculate.Core.Interfaces.Repository;

namespace PaySpaceTaxCalculate.Infrastructure.Persistence.Repository
{
    public class LogCalculateTaxRepository : IDal<LogCalculateTax>
    {
        private readonly IConnection _connection;
        public LogCalculateTaxRepository(IConnection connection)
        {
            _connection = connection;
        }
        public LogCalculateTax Insert(LogCalculateTax value)
        {
            using var command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO LogCalculateTax (PostalCode, AnnualSalary, CalculateTaxValue, DateCalculate) VALUES (@PostalCode, @AnnualSalary, @CalculateTaxValue, GETDATE()); SELECT @@IDENTITY;";
            command.Parameters.Add("@PostalCode", SqlDbType.VarChar, 5).Value = value.PostalCode;
            command.Parameters.Add("@AnnualSalary", SqlDbType.Decimal).Value = value.AnnualSalary;
            command.Parameters.Add("@CalculateTaxValue", SqlDbType.Decimal).Value = value.CalculateTaxValue;

            if (int.TryParse(command.ExecuteScalar().ToString(), out var id))
            {
                value.Id = id;
            }

            return value;
        }

        public bool Edit(LogCalculateTax value)
        {
            throw new NotImplementedException();
        }

        public bool Delete(LogCalculateTax value)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public LogCalculateTax Find(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogCalculateTax> List()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
