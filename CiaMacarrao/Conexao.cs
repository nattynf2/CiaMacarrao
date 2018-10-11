using System.Data.SqlClient;

namespace CiaMacarrao
{
    class Conexao
    {
        public static SqlConnection getConnection()
        {
            SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=CrudBasico;Data Source=DESKTOP-91QR5GQ\\SQLSERVER");

            return conn;
        }
    }
}
