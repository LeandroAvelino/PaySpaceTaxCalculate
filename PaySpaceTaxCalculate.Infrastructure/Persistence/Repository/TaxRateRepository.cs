using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaySpaceTaxCalculate.Core.Entities;
using PaySpaceTaxCalculate.Core.Interfaces.Repository;

namespace PaySpaceTaxCalculate.Infrastructure.Persistence.Repository
{
    public class TaxRateRepository : IDal<TaxRate>
    {
        private readonly IConnection _connection;
        public TaxRateRepository(IConnection connection)
        {
            _connection = connection;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TaxRate Insert(TaxRate value)
        {
            using var command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO TaxRate (MaxEarns, TaxPercentage, TaxCalculationTypeId) VALUES (@MaxEarns, @TaxPercentage, @TaxCalculationTypeId); SELECT @@IDENTITY;";
            command.Parameters.Add("@MaxEarns", SqlDbType.Decimal).Value = value.MaxEarns;
            command.Parameters.Add("@TaxPercentage", SqlDbType.Decimal).Value = value.TaxPercentage;
            command.Parameters.Add("@TaxCalculationTypeId", SqlDbType.Int).Value = value.TaxCalculationTypeId;

            if (int.TryParse(command.ExecuteScalar().ToString(), out var id))
            {
                value.Id = id;
            }

            return value;
        }

        public bool Edit(TaxRate value)
        {
            var ret = false;
            using var command = _connection.CreateCommand();
            command.CommandText = "UPDATE TaxRate SET MaxEarns = @MaxEarns, TaxPercentage = @TaxPercentage, TaxCalculationTypeId = @TaxCalculationTypeId WHERE Id = @Id";
            command.Parameters.Add("@MaxEarns", SqlDbType.Decimal).Value = value.MaxEarns;
            command.Parameters.Add("@TaxPercentage", SqlDbType.Decimal).Value = value.TaxPercentage;
            command.Parameters.Add("@TaxCalculationTypeId", SqlDbType.Int).Value = value.TaxCalculationTypeId;
            command.Parameters.Add("@Id", SqlDbType.Int).Value = value.Id;
            ret = command.ExecuteNonQuery() > 0;
            return ret;
        }

        public bool Delete(TaxRate value)
        {
            return Delete(value.Id);
        }

        public bool Delete(object id)
        {
            var ret = false;
            using var command = _connection.CreateCommand();
            command.CommandText = "DELETE FROM TaxRate WHERE Id = @Id";
            command.Parameters.Add("@Id", SqlDbType.Int).Value = (int)id;
            ret = command.ExecuteNonQuery() > 0;
            return ret;
        }

        public TaxRate Find(object id)
        {
            TaxRate taxRate = null;
            using var command = _connection.CreateCommand();

            command.CommandText = "SELECT Id, MaxEarns, TaxPercentage, TaxCalculationTypeId FROM TaxRate WHERE Id=@Id";
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            using var reader = command.ExecuteReader();
            if (!reader.HasRows)
                return taxRate;

            reader.Read();
            taxRate = new TaxRate(reader.GetInt32(0), reader.GetDecimal(1), reader.GetDecimal(2), reader.GetInt32(3));

            return taxRate;
        }

        public IEnumerable<TaxRate> List()
        {
            using var command = _connection.CreateCommand();

            command.CommandText = "SELECT Id, MaxEarns, TaxPercentage, TaxCalculationTypeId FROM TaxRate ORDER BY Id";
            using var reader = command.ExecuteReader();
            if (!reader.HasRows) 
                yield break;

            while (reader.Read())
            {
                yield return new TaxRate(reader.GetInt32(0), reader.GetDecimal(1), reader.GetDecimal(2), reader.GetInt32(3));
            }
        }
    }
}
