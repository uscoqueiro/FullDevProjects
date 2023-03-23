namespace Xpto.Repositories.Shared.Sql
{
    public static class DataExtensions
    {
        public static object GetDbValue(this object value)
        {
            try
            {
                if (value == null)
                    return DBNull.Value;
 
                var type = value.GetType();
                if (type == typeof(DateTime))
                {
                    var date = Convert.ToDateTime(value);
                    if (date <= new DateTime(1753, 1, 1, 12, 0, 0) || date >= new DateTime(9999, 12, 31, 11, 59, 59))
 
                        return DBNull.Value;
                }

                if (value is not string str)
                    return value;

                return string.IsNullOrWhiteSpace(str) ? DBNull.Value : str;
            }
            catch
            {
                return DBNull.Value;
            }
        }
    }
}
