// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2023-02-12

using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Xpto.Core.Customers
{
    public class CustomerRepository
    {
        private readonly string connectionString = "server=.;database=db_xpto;user=xpto;password=123456";


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


            var connection = new SqlConnection(this.connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText = commandText.ToString();

            var item = command.Parameters.Add(new SqlParameter("@code", customer.Code) { Direction = ParameterDirection.Output });

            command.Parameters.Add(new SqlParameter("@id", customer.Id));
            command.Parameters.Add(new SqlParameter("@name", customer.Name));

            command.Parameters.Add(new SqlParameter("@nickname", customer.Nickname)); 

            if (customer.BirthDate == null)
                command.Parameters.Add(new SqlParameter("@birth_date", DBNull.Value));
            else
                command.Parameters.Add(new SqlParameter("@birth_date", Convert.ToDateTime(customer.BirthDate)));


            command.Parameters.Add(new SqlParameter("@person_type", customer.PersonType));
            command.Parameters.Add(new SqlParameter("@identity", customer.Identity));
            command.Parameters.Add(new SqlParameter("@note", customer.Note));

            if (customer.CreationDate == null)
                command.Parameters.Add(new SqlParameter("@creation_date", DBNull.Value));
            else
                command.Parameters.Add(new SqlParameter("@creation_date", Convert.ToDateTime(customer.CreationDate)));

 
            command.Parameters.Add(new SqlParameter("@creation_user_id", customer.CreationUserId));
            command.Parameters.Add(new SqlParameter("@creation_user_name", customer.CreationUserName));


            if (customer.ChangeDate == null)
                command.Parameters.Add(new SqlParameter("@change_date", DBNull.Value));
            else
                command.Parameters.Add(new SqlParameter("@change_date", Convert.ToDateTime(customer.ChangeDate)));

 
            command.Parameters.Add(new SqlParameter("@change_user_id", customer.ChangeUserId));
            command.Parameters.Add(new SqlParameter("@change_user_name", customer.ChangeUserName));

            command.ExecuteNonQuery();

            customer.Code = (int)item.Value;

            connection.Close();

            return customer;
        }
    }
}
