namespace Xpto.Repositories.Shared.Sql
{
    public class SqlConnectionProvider
    {
        public string ConnectionString { get; }

        public SqlConnectionProvider(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}


 