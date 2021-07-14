using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sweet_Fast_BL
{
    public class Konditorei
    {
        internal static SqlConnection getConnection()
        {
            string conSTring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jerem\source\repos\Zitate\DL_Zitate\Zitate.mdf;Integrated Security=True;Connect Timeout=5";
            SqlConnection conn = new SqlConnection(conSTring);
            conn.Open(); // sollte mit try catch gesichert werden
            return conn;
        }


    }

}
