using System;
using System.Data.Common;

namespace Northwind.Dal.Helpers
{
    internal static class DbDataReaderHelper
    {
        public static string GetString(this DbDataReader reader, string columnName)
        {
            return reader[columnName] as string;
        }

        public static T? GetNullable<T>(this DbDataReader reader, string columnName)
            where T : struct
        {
            return reader[columnName] as T?;
        }

        public static int GetInt16(this DbDataReader reader, string columnName)
        {
            var columnIndex = reader.GetOrdinal(columnName);
            return reader.GetInt16(columnIndex);
        }

        public static int GetInt32(this DbDataReader reader, string columnName)
        {
            var columnIndex = reader.GetOrdinal(columnName);
            return reader.GetInt32(columnIndex);
        }

        public static DateTime GetDateTime(this DbDataReader reader, string columnName)
        {
            var columnIndex = reader.GetOrdinal(columnName);
            return reader.GetDateTime(columnIndex);
        }

        public static decimal GetDecimal(this DbDataReader reader, string columnName)
        {
            var columnIndex = reader.GetOrdinal(columnName);
            return reader.GetDecimal(columnIndex);
        }

        public static float GetFloat(this DbDataReader reader, string columnName)
        {
            var columnIndex = reader.GetOrdinal(columnName);
            return reader.GetFloat(columnIndex);
        }

        public static bool GetBoolean(this DbDataReader reader, string columnName)
        {
            var columnIndex = reader.GetOrdinal(columnName);
            return reader.GetBoolean(columnIndex);
        }
    }
}
