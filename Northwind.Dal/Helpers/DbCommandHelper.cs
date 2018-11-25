using System;
using System.Data;
using System.Data.Common;
using System.Resources;

namespace Northwind.Dal.Helpers
{
    internal static class DbCommandHelper
    {
        public static void AddParameter(this DbCommand command, string name, object value)
        {
            command.AddParam(name, value);
        }

        public static void AddParameter(this DbCommand command, string name, DbType type, object value)
        {
            var parameter = command.AddParam(name, value);
            parameter.DbType = type;
        }

        private static DbParameter AddParam(this DbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
            return parameter;
        }
    }
}
