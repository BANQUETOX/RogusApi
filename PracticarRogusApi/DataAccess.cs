using Microsoft.Data.SqlClient;
using System.Data;
namespace PracticarRogusApi
{
    public class DataAccess
    {
        /*Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;*/
        /*"Data Source=201.237.248.149,1433;Initial Catalog=PracticaUtilidades;User ID=pruebas2016;Password=pruebas2016; Trusted_Connection=True;"*/
        private static string connectionString = "Server=201.237.248.149,1433;Database=PracticaUtilidades;User ID=pruebas2016;Password=pruebas2016;TrustServerCertificate=true;";
        public static Person requestLinq(string id)
        {
            return new Person();
        }

        public static List<Dictionary<string, object>> requestSqlCommand(string id)
        {
            List<Dictionary<string, object>> lstResults = new List<Dictionary<string, object>>();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlParameter parameter = new SqlParameter("@cedula",id);


            SqlCommand command = new()
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ObtenerPersonaFelipeMena",
                Parameters = {parameter}
            };

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Dictionary<string, object> rowDicc = new Dictionary<string, object>();
                        for (var fieldCount = 0; fieldCount < reader.FieldCount; fieldCount++)
                        {
                            rowDicc.Add(reader.GetName(fieldCount), reader.GetValue(fieldCount));
                        }
                        lstResults.Add(rowDicc);
                    }
                }
                connection.Close();
                return lstResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
