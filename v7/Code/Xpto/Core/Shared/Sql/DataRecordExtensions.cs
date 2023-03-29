using System.Data.SqlClient;

namespace Xpto.Core.Shared.Sql
{
    public static class DataRecordExtensions
    {
        public static bool GetBoolean(this SqlDataReader reader, string name)
        {
            bool.TryParse(reader[name]?.ToString(), out var result);
            return result;
        }

        public static byte GetByte(this SqlDataReader reader, string name)
        {
            byte.TryParse(reader[name]?.ToString(), out var result);
            return result;
        }

        public static DateTime GetDateTime(this SqlDataReader reader, string name)
        {
            DateTime.TryParse(reader[name]?.ToString(), out var result);
            return result;
        }

        public static decimal GetDecimal(this SqlDataReader reader, string name)
        {
            decimal.TryParse(reader[name]?.ToString(), out var result);
            return result;
        }

        public static double GetDouble(this SqlDataReader reader, string name)
        {
            double.TryParse(reader[name]?.ToString(), out var result);
            return result;
        }

        public static float GetFloat(this SqlDataReader reader, string name)
        {
            float.TryParse(reader[name]?.ToString(), out var result);
            return result;
        }

        public static Guid GetGuid(this SqlDataReader reader, string name)
        {
            Guid.TryParse(reader[name]?.ToString(), out var result);
            return result;
        }

        public static short GetInt16(this SqlDataReader reader, string name)
        {
            short.TryParse(reader[name]?.ToString(), out var result);
            return result;
        }

        public static int GetInt32(this SqlDataReader reader, string name)
        {
            int.TryParse(reader[name]?.ToString(), out var result);
            return result;
        }

        public static long GetInt64(this SqlDataReader reader, string name)
        {
            long.TryParse(reader[name]?.ToString(), out var result);
            return result;
        }

        public static string GetString(this SqlDataReader reader, string name)
        {
            try
            {
                return Convert.ToString(reader[name]);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static bool IsDbNull(this SqlDataReader reader, string name)
        {
            return DBNull.Value.Equals(reader[name]);

        }

        public static bool? GetNullableBoolean(this SqlDataReader reader, string name)
        {
            return reader.IsDbNull(name) ? (bool?)null : reader.GetBoolean(name);
        }

        public static byte? GetNullableByte(this SqlDataReader reader, string name)
        {
            return reader.IsDbNull(name) ? (byte?)null : reader.GetByte(name);
        }

        public static DateTime? GetNullableDateTime(this SqlDataReader reader, string name)
        {
            return reader.IsDbNull(name) ? (DateTime?)null : reader.GetDateTime(name);
        }

        public static decimal? GetNullableDecimal(this SqlDataReader reader, string name)
        {
            return reader.IsDbNull(name) ? (decimal?)null : reader.GetDecimal(name);
        }

        public static double? GetNullableDouble(this SqlDataReader reader, string name)
        {
            return reader.IsDbNull(name) ? (double?)null : reader.GetDouble(name);
        }

        public static float? GetNullableFloat(this SqlDataReader reader, string name)
        {
            return reader.IsDbNull(name) ? (float?)null : reader.GetFloat(name);
        }

        public static Guid? GetNullableGuid(this SqlDataReader reader, string name)
        {
            return reader.IsDbNull(name) ? (Guid?)null : reader.GetGuid(name);
        }

        public static short? GetNullableInt16(this SqlDataReader reader, string name)
        {
            return reader.IsDbNull(name) ? (short?)null : reader.GetInt16(name);
        }

        public static int? GetNullableInt32(this SqlDataReader reader, string name)
        {
            return reader.IsDbNull(name) ? (int?)null : reader.GetInt32(name);
        }

        public static long? GetNullableInt64(this SqlDataReader reader, string name)
        {
            return reader.IsDbNull(name) ? (long?)null : reader.GetInt64(name);
        }

        public static string GetNullableString(this SqlDataReader reader, string name)
        {
            return reader.IsDbNull(name) ? null : reader.GetString(name);
        }
    }
}
