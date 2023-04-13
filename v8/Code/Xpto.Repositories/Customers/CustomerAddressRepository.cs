// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2023-02-12

using System.Data.SqlClient;
using System.Text;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities;
using Xpto.Repositories.Shared.Sql;

namespace Xpto.Repositories.Customers
{
    public class CustomerAddressRepository : ICustomerAddressRepository
    {
        private readonly SqlConnectionProvider _connectionProvider;

        public CustomerAddressRepository(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public Address Insert(int customerCode, Address address)
        {
            var commandText = new StringBuilder()
                .AppendLine(" INSERT INTO [tb_customer_address]")
                .AppendLine(" (")
                .AppendLine(" [id],")
                .AppendLine(" [customer_code],")
                .AppendLine(" [type],")
                .AppendLine(" [street],")
                .AppendLine(" [number],")
                .AppendLine(" [complement],")
                .AppendLine(" [district],")
                .AppendLine(" [city],")
                .AppendLine(" [state],")
                .AppendLine(" [zip_code],")
                .AppendLine(" [note]")
                .AppendLine(" )")
                .AppendLine(" VALUES")
                .AppendLine(" (")
                .AppendLine(" @id,")
                .AppendLine(" @customer_code,")
                .AppendLine(" @type,")
                .AppendLine(" @street,")
                .AppendLine(" @number,")
                .AppendLine(" @complement,")
                .AppendLine(" @district,")
                .AppendLine(" @city,")
                .AppendLine(" @state,")
                .AppendLine(" @zip_code,")
                .AppendLine(" @note")
                .AppendLine(" )");

            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);

            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            this.SetParameters(customerCode, address, cm);

            cm.ExecuteNonQuery();

            return address;
        }

        public void Update(int customerCode, Address address)
        {
            var commandText = new StringBuilder()
                .AppendLine(" UPDATE [tb_customer_address]")
                .AppendLine(" SET")
                .AppendLine(" [id] = @id,")
                .AppendLine(" [customer_code] = @customer_code,")
                .AppendLine(" [type] = @type,")
                .AppendLine(" [street] = @street,")
                .AppendLine(" [number] = @number,")
                .AppendLine(" [complement] = @complement,")
                .AppendLine(" [district] = @district,")
                .AppendLine(" [city] = @city,")
                .AppendLine(" [state] = @state,")
                .AppendLine(" [zip_code] = @zip_code,")
                .AppendLine(" [note] = @note")
                .AppendLine(" WHERE [id] = @id");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            this.SetParameters(customerCode, address, cm);

            cm.ExecuteNonQuery();

            connection.Close();
        }

        public int Delete(Guid id)
        {
            var commandText = new StringBuilder()
                .AppendLine(" DELETE FROM [tb_customer_address]")
                .AppendLine(" WHERE [id] = @id");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@id", id));

            var result = cm.ExecuteNonQuery();

            connection.Close();

            return result;
        }

        public int DeleteByCustomer(int customerCode)
        {
            var commandText = new StringBuilder()
                .AppendLine(" DELETE FROM [tb_customer_address]")
                .AppendLine(" WHERE [customer_code] = @customer_code");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@customer_code", customerCode));

            var result = cm.ExecuteNonQuery();

            connection.Close();

            return result;
        }

        public Address Get(Guid id)
        {
            var commandText = this.GetSelectQuery()
                    .AppendLine(" WHERE [id] = @id");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@id", id));

            var dataReader = cm.ExecuteReader();

            Address address = null;

            while (dataReader.Read())
            {
                address = GetDataRecord(dataReader);
            }

            connection.Close();

            return address;

        }
  
        public IList<Address> FindByCustomer(int customerCode)
        {
            var l = new List<Address>();

            var commandText = this.GetSelectQuery()
                .AppendLine(" WHERE [customer_code] = @customer_code");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@customer_code", customerCode));

            var dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                var customer = GetDataRecord(dataReader);

                l.Add(customer);
            }

            return l;
        }

        private static Address GetDataRecord(SqlDataReader dataRecord)
        {
            var address = new Address
            {
                Id = dataRecord.GetGuid("id"), 
                Type = dataRecord.GetNullableString("type"),
                Street = dataRecord.GetString("street"),
                Number = dataRecord.GetNullableString("number"),
                Complement = dataRecord.GetNullableString("complement"),
                District = dataRecord.GetNullableString("district"),
                City = dataRecord.GetNullableString("city"),
                State = dataRecord.GetNullableString("state"),
                ZipCode = dataRecord.GetNullableString("zip_code"),
                Note = dataRecord.GetNullableString("note")
            };

            return address;
        }
 
        public StringBuilder GetSelectQuery()
        {
            var commandText = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine(" A.[id],")
                .AppendLine(" A.[customer_code],")
                .AppendLine(" A.[type],")
                .AppendLine(" A.[street],")
                .AppendLine(" A.[number],")
                .AppendLine(" A.[complement],")
                .AppendLine(" A.[district],")
                .AppendLine(" A.[city],")
                .AppendLine(" A.[state],")
                .AppendLine(" A.[zip_code],")
                .AppendLine(" A.[note]")
                .AppendLine(" FROM [tb_customer_address] AS A");

            return commandText;
        }

        private void SetParameters(int customerCode, Address address, SqlCommand cm)
        {
            cm.Parameters.Add(new SqlParameter("@id", address.Id.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@customer_code", customerCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@type", address.Type.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@street", address.Street.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@number", address.Number.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@complement", address.Complement.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@district", address.District.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@city", address.City.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@state", address.State.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@zip_code", address.ZipCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@note", address.Note.GetDbValue()));
        }
    }
}
