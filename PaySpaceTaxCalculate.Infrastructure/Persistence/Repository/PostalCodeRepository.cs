using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PaySpaceTaxCalculate.Core.Entities;
using PaySpaceTaxCalculate.Core.Interfaces.Repository;

namespace PaySpaceTaxCalculate.Infrastructure.Persistence.Repository
{
    public class PostalCodeRepository : IDal<PostalCode>
    {
        private readonly IConnection _connection;
        public PostalCodeRepository(IConnection connection)
        {
            _connection = connection;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public PostalCode Insert(PostalCode value)
        {
            using var command = _connection.CreateCommand();

            command.CommandText = "INSERT INTO PostalCode (Code, TaxCalculationTypeId) VALUES (@Code, @TaxCalculationTypeId); SELECT @@IDENTITY;";
            command.Parameters.Add("@Code", SqlDbType.VarChar, 5).Value = value.Code;
            command.Parameters.Add("@TaxCalculationTypeId", SqlDbType.Int).Value = value.TaxCalculationTypeId;
                
            if (int.TryParse(command.ExecuteScalar().ToString(), out var id))
            {
                value.Id = id;
            }

            return value;
        }

        public bool Edit(PostalCode value)
        {
            var ret = false;
            using var command = _connection.CreateCommand();
            command.CommandText = "UPDATE PostalCode SET Code = @Code, TaxCalculationTypeId = @TaxCalculationTypeId WHERE Id = @Id";
            command.Parameters.Add("@Code", SqlDbType.VarChar, 5).Value = value.Code;
            command.Parameters.Add("@TaxCalculationTypeId", SqlDbType.Int).Value = value.TaxCalculationTypeId;
            command.Parameters.Add("@Id", SqlDbType.Int).Value = value.Id;
            ret = command.ExecuteNonQuery() > 0;
            return ret;
        }

        public bool Delete(PostalCode value)
        {
            return Delete(value.Id);
        }

        public bool Delete(object id)
        {
            var ret = false;
            using var command = _connection.CreateCommand();
            command.CommandText = "DELETE FROM PostalCode WHERE Id = @Id";
            command.Parameters.Add("@Id", SqlDbType.Int).Value = (int)id;
            ret = command.ExecuteNonQuery() > 0;
            return ret;
        }

        public PostalCode Find(object id)
        {
            PostalCode postalCode = null;
            using var _command = _connection.CreateCommand();

            _command.CommandText = "SELECT Id, Code, TaxCalculationTypeId FROM PostalCode WHERE Id=@Id";
            _command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            
            using var reader = _command.ExecuteReader();
            if (!reader.HasRows) 
                return postalCode;

            reader.Read();
            postalCode = new PostalCode(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));

            return postalCode;
        }

        public IEnumerable<PostalCode> List()
        {
            using var command = _connection.CreateCommand();

            command.CommandText = "SELECT Id, Code, TaxCalculationTypeId FROM PostalCode ORDER BY Id";
            using var reader = command.ExecuteReader();
            if (!reader.HasRows) yield break;

            while (reader.Read())
            {
                yield return new PostalCode(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
            }
        }
    }
}
