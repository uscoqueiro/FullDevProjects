using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Core.Shared.Functions
{
    public class GlobalFunction
    {
        public static DateTime? GetIsoDateTime(string text)
        {
            if (DateTime.TryParseExact(text, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                return dt;
            else
                return null;
        }

        public static Guid GetGuid(string text)
        {
            if (Guid.TryParse(text, out var result))
                return result;
            else
                return Guid.Empty;
        }

        public static void AppendField(StringBuilder sb, string value)
        {
            if (value != null)
            {
                value = value.Replace(";", "##$$##");
                sb.Append(value);
            }

            sb.Append(';');
        }

        public static void AppendField(StringBuilder sb, Guid value)
        {
            sb.Append(value);
            sb.Append(';');
        }

        public static void AppendField(StringBuilder sb, DateTime? value)
        {
            if (value != null)
            {
                sb.Append(((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss"));
            }

            sb.Append(';');
        }

        public static void AppendField(StringBuilder sb, int value)
        {
            sb.Append(value);
            sb.Append(';');
        }

        public static bool TryCalcYearsOld(string birthDate, out int value)
        {
            value = 0;
            return false;
        }
    }
}
