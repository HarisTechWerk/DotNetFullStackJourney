using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Core
{
    public static class DateExtensions
    {
        public static DateTime ParseCustomDate(this string dateString)
        {
            if (string.IsNullOrEmpty(dateString))
            {
                throw new ArgumentNullException("Date string cannot be null or empty", nameof(dateString));
            }

            string[] formats = { "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy" };
            if (DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))

            {
                return result;
            }

            throw new ArgumentException($"Date string '{dateString}' does not match any of the supported formats: {string.Join(", ", formats)}");
        }

        public static string ToStandardDateString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }
}
