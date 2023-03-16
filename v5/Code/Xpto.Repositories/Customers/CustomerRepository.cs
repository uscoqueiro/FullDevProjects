// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2023-02-12

using System.Data;
using System.Data.SqlClient;
using System.Text;
using Xpto.Core.Customers;
using Xpto.Repositories.Shared;
using Xpto.Repositories.Shared.Sql;

namespace Xpto.Repositories.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlConnectionProvider _connectionProvider;

        public CustomerRepository(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public Customer Insert(Customer customer)
        {
            var commandText = new StringBuilder()
            .AppendLine(" INSERT INTO [tb_customer]")
            .AppendLine(" (")
            .AppendLine(" [id],")
            .AppendLine(" [name],")
            .AppendLine(" [nickname],")
            .AppendLine(" [birth_date],")
            .AppendLine(" [person_type],")
            .AppendLine(" [identity],")
            .AppendLine(" [note],")
            .AppendLine(" [creation_date],")
            .AppendLine(" [creation_user_id],")
            .AppendLine(" [creation_user_name],")
            .AppendLine(" [change_date],")
            .AppendLine(" [change_user_id],")
            .AppendLine(" [change_user_name]")
            .AppendLine(" )")
            .AppendLine(" VALUES")
            .AppendLine(" (")
            .AppendLine(" @id,")
            .AppendLine(" @name,")
            .AppendLine(" @nickname,")
            .AppendLine(" @birth_date,")
            .AppendLine(" @person_type,")
            .AppendLine(" @identity,")
            .AppendLine(" @note,")
            .AppendLine(" @creation_date,")
            .AppendLine(" @creation_user_id,")
            .AppendLine(" @creation_user_name,")
            .AppendLine(" @change_date,")
            .AppendLine(" @change_user_id,")
            .AppendLine(" @change_user_name")
            .AppendLine(" )")
            .AppendLine(" SET @code = SCOPE_IDENTITY(); ");



            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);

            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            var code = cm.Parameters.Add(new SqlParameter("@code", customer.Code) { Direction = ParameterDirection.Output });

            this.SetParameters(customer, cm);

            cm.ExecuteNonQuery();

            customer.Code = (int)code.Value;

            return customer;
        }

        public void Update(Customer customer)
        {
            var commandText = new StringBuilder()
            .AppendLine(" UPDATE [tb_customer]")
            .AppendLine(" SET")
            .AppendLine(" [id] = @id,")
            .AppendLine(" [name] = @name,")
            .AppendLine(" [nickname] = @nickname,")
            .AppendLine(" [birth_date] = @birth_date,")
            .AppendLine(" [person_type] = @person_type,")
            .AppendLine(" [note] = @note,")
            .AppendLine(" [creation_date] = @creation_date,")
            .AppendLine(" [creation_user_id] = @creation_user_id,")
            .AppendLine(" [creation_user_name] = @creation_user_name,")
            .AppendLine(" [change_date] = @change_date,")
            .AppendLine(" [change_user_id] = @change_user_id,")
            .AppendLine(" [change_user_name] = @change_user_name")
            .AppendLine(" WHERE [id] = @id");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            this.SetParameters(customer, cm);

            cm.ExecuteNonQuery();

            connection.Close();
        }

        public int Delete(Guid id)
        {
            var commandText = new StringBuilder()
            .AppendLine(" DELETE FROM [tb_customer]")
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

        public Customer Get(Guid id)
        {
            var commandText = this.GetSelectQuery()
                    .AppendLine(" WHERE [id] = @id");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@id", id));

            var dataReader = cm.ExecuteReader();

            Customer customer = null;

            while (dataReader.Read())
            {
                customer = LoadDataReader(dataReader);
            }

            connection.Close();

            return customer;

        }

        public Customer Get(int code)
        {
            var commandText = this.GetSelectQuery()
               .AppendLine(" WHERE [code] = @code");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@code", code));

            var dataReader = cm.ExecuteReader();

            Customer customer = null;

            while (dataReader.Read())
            {
                customer = LoadDataReader(dataReader);
            }

            connection.Close();

            return customer;

        }

        public IList<Customer> Find()
        {
            var l = new List<Customer>();

            var commandText = this.GetSelectQuery();

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            var dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                var customer = LoadDataReader(dataReader);

                l.Add(customer);
            }

            return l;
        }

        private static Customer LoadDataReader(SqlDataReader dataReader)
        {
            var customer = new Customer();
 
            customer.Id = dataReader.GetGuid("id");
            customer.Code = dataReader.GetInt32("code");
            customer.Name = dataReader.GetString( "name");
            customer.Nickname = dataReader.GetString("nickname");
            customer.BirthDate = dataReader.GetDateTime("birth_date");


            customer.PersonType = dataReader["person_type"].ToString();

            customer.Note = dataReader["note"].ToString();

            DateTime.TryParse(dataReader["creation_date"].ToString(), out var creationDate);
            customer.CreationDate = creationDate;

            Guid.TryParse(dataReader["creation_user_id"]?.ToString(), out var creationUserId);
            customer.CreationUserId = creationUserId;

            customer.CreationUserName = dataReader["creation_user_name"].ToString();

            DateTime.TryParse(dataReader["change_date"].ToString(), out var changeDate);
            customer.ChangeDate = changeDate;

            Guid.TryParse(dataReader["change_user_id"]?.ToString(), out var changeUserId);
            customer.ChangeUserId = changeUserId;

            customer.ChangeUserName = dataReader["change_user_name"].ToString();
            return customer;
        }

        public DataTable LoadDataTable()
        {
            var commandText = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine(" A.[id],")
                .AppendLine(" A.[code],")
                .AppendLine(" A.[name],")
                .AppendLine(" A.[nickname],")
                .AppendLine(" A.[birth_date],")
                .AppendLine(" A.[person_type],")
                .AppendLine(" A.[note],")
                .AppendLine(" A.[creation_date],")
                .AppendLine(" A.[creation_user_id],")
                .AppendLine(" A.[creation_user_name],")
                .AppendLine(" A.[change_date],")
                .AppendLine(" A.[change_user_id],")
                .AppendLine(" A.[change_user_name]")
                .AppendLine(" FROM [tb_customer] AS A");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();
            cm.CommandText = commandText.ToString();

            var da = new SqlDataAdapter(cm);
            var dataTable = new DataTable();
            da.Fill(dataTable);
            connection.Close();
            da.Dispose();

            return dataTable;
        }

        public long Count()
        {
            var commandText = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine(" COUNT(*) AS [COUNT]")
                .AppendLine(" FROM [tb_customer] AS A");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            var count = cm.ExecuteScalar();

            var result = count == null ? 0 : Convert.ToInt64(count);

            return result;
        }

        public StringBuilder GetSelectQuery()
        {
            var sb = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine(" A.[id],")
                .AppendLine(" A.[code],")
                .AppendLine(" A.[name],")
                .AppendLine(" A.[nickname],")
                .AppendLine(" A.[birth_date],")
                .AppendLine(" A.[person_type],")
                .AppendLine(" A.[note],")
                .AppendLine(" A.[creation_date],")
                .AppendLine(" A.[creation_user_id],")
                .AppendLine(" A.[creation_user_name],")
                .AppendLine(" A.[change_date],")
                .AppendLine(" A.[change_user_id],")
                .AppendLine(" A.[change_user_name]")
                .AppendLine(" FROM [tb_customer] AS A");

            return sb;
        }

        private void SetParameters(Customer customer, SqlCommand cm)
        {
            cm.Parameters.Add(new SqlParameter("@id", customer.Id.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@name", customer.Name.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@nickname", customer.Nickname.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@birth_date", customer.BirthDate.GetDbValue()));


            if (string.IsNullOrWhiteSpace(customer.PersonType))
                cm.Parameters.Add(new SqlParameter("@person_type", DBNull.Value));

            else
                cm.Parameters.Add(new SqlParameter("@person_type", customer.PersonType));

            if (string.IsNullOrWhiteSpace(customer.Identity))
                cm.Parameters.Add(new SqlParameter("@identity", DBNull.Value));

            else
                cm.Parameters.Add(new SqlParameter("@identity", customer.Identity));

            if (string.IsNullOrWhiteSpace(customer.Note))
                cm.Parameters.Add(new SqlParameter("@note", DBNull.Value));

            else
                cm.Parameters.Add(new SqlParameter("@note", customer.Note));


            if (customer.CreationDate == null || customer.CreationDate <= new DateTime(1900, 01, 01))
                cm.Parameters.Add(new SqlParameter("@creation_date", DBNull.Value));
            else
                cm.Parameters.Add(new SqlParameter("@creation_date", customer.CreationDate));


            cm.Parameters.Add(new SqlParameter("@creation_user_id", customer.CreationUserId));

            if (string.IsNullOrWhiteSpace(customer.CreationUserName))
                cm.Parameters.Add(new SqlParameter("@creation_user_name", DBNull.Value));

            else
                cm.Parameters.Add(new SqlParameter("@creation_user_name", customer.CreationUserName));


            if (customer.ChangeDate == null)
                cm.Parameters.Add(new SqlParameter("@change_date", DBNull.Value));
            else
                cm.Parameters.Add(new SqlParameter("@change_date", customer.ChangeDate));

            cm.Parameters.Add(new SqlParameter("@change_user_id", customer.ChangeUserId));


            if (string.IsNullOrWhiteSpace(customer.ChangeUserName))
                cm.Parameters.Add(new SqlParameter("@change_user_name", DBNull.Value));
            else
                cm.Parameters.Add(new SqlParameter("@change_user_name", customer.ChangeUserName));
        }

    }
}
