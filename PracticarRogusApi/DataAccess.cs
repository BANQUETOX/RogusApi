using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
namespace PracticarRogusApi

{
    public class DataAccess
    {
        
        private readonly string _connectionString;
        public DataAccess(string connectionString) {
            _connectionString = connectionString;
        }
        
       /* private string connectionString = lol.GetValue<string>("ConnectionStrings:Main") ;*/
        public  Person requestLinq(string id)
        {
            return new Person();
        }

        public  List<Dictionary<string, object>> requestSqlCommand(string id)
        {
            var connectionString = _connectionString ;
            Console.WriteLine(connectionString);
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
