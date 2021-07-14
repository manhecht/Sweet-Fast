using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
            dirs.RemoveAt(dirs.Count - 1); //letztes Verzeichnis entfernen
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + String.Join(@"\", dirs) + @"\DL_Zitate\Zitate.mdf;Integrated Security=True;Connect Timeout=5";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            return conn;
        }
    }
}
