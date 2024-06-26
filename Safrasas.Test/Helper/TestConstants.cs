using System;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Safrasas.Test.Helper
{
    public static class TestConstants
    {
        public static SqlException GetSqlException()
        {
            var sqlException = FormatterServices.GetUninitializedObject(typeof(SqlException)) as SqlException;

#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return sqlException;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public static Exception GetGeneralException()
        {
            return new Exception("Test Exception");
        }

        public static class ClientTest
        {
            public static string FirstName = "Julian";
            public static string LastName = "Castellanos";
            public static string Email = "guitarrajulian@gmail.com";
            public static string Document = "C:\\Test\\1.csv";
            public static string NewDocument = "C:\\Test\\2.csv";
        }
    }
}
