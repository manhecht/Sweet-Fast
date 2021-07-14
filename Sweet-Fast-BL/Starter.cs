using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweet_Fast_BL
{
    public static class Starter
    {
        public static Eintrag newEintrag()
        {
            return new Eintrag();
        }

        public static Eintrag getEintragById(string Id) 
        {
            return Eintrag.getEintragById(Id);
        }
        internal static SqlConnection getConnection()
        {
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jerem\source\repos\manhecht\Sweet-Fast-New\DL_Zitate\Zitate.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            return conn;
        }
    }
}
