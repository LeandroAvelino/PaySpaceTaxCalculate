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
    public class TaxCalculationTypeRepository : IDal<TaxCalculationType>
    {
        private readonly IConnection _connection;
        public TaxCalculationTypeRepository(IConnection connection)
        {
            _connection = connection;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TaxCalculationType Insert(TaxCalculationType value)
        {
            using var command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO TaxCalculationType (Name) VALUES (@Name); SELECT @@IDENTITY;";
            command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = value.Name;
    
            if (int.TryParse(command.ExecuteScalar().ToString(), out var id))
            {
                value.Id = id;
            }

            return value;
        }

        public bool Edit(TaxCalculationType value)
        {
            var ret = false;
            using var command = _connection.CreateCommand();
            command.CommandText = "UPDATE TaxCalculationType SET Name = @Name WHERE Id = @Id";
            command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = value.Name;
            command.Parameters.Add("@Id", SqlDbType.Int).Value = value.Id;
            ret = command.ExecuteNonQuery() > 0;
            return ret;
        }

        public bool Delete(TaxCalculationType value)
        {
            return Delete(value.Id);
        }

        public bool Delete(object id)
        {
            var ret = false;
            using var command = _connection.CreateCommand();
            command.CommandText = "DELETE FROM TaxCalculationType WHERE Id = @Id";
            command.Parameters.Add("@Id", SqlDbType.Int).Value = (int)id;
            ret = command.ExecuteNonQuery() > 0;
            return ret;
        }

        public TaxCalculationType Find(object id)
        {
            TaxCalculationType taxCalculationType = null;
            using var command = _connection.CreateCommand();

            command.CommandText = "SELECT Id, Name FROM TaxCalculationType WHERE Id=@Id";
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            using var reader = command.ExecuteReader();
            if (!reader.HasRows)
                return taxCalculationType;

            reader.Read();
            taxCalculationType = new TaxCalculationType(reader.GetInt32(0), reader.GetString(1));

            return taxCalculationType;
        }

        public IEnumerable<TaxCalculationType> List()
        {
            using var command = _connection.CreateCommand();

            command.CommandText = "SELECT Id, Name FROM TaxCalculationType ORDER BY Id";
            using var reader = command.ExecuteReader();
            if (!reader.HasRows) yield break;

            while (reader.Read())
            {
                yield return new TaxCalculationType(reader.GetInt32(0), reader.GetString(1));
            }
        }
    }
}
