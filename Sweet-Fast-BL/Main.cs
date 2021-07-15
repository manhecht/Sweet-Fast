using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
namespace Sweet_Fast_BL
{
    public static class Main
    {
        //wird aufgerufen wann immer eine Connection zur DB benötigt wird
        internal static SqlConnection getConnection()
        {
            List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
            dirs.RemoveAt(dirs.Count - 1); //letztes Verzeichnis entfernen
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + String.Join(@"\", dirs) + @"\DL_Zitate\Zitate.mdf;Integrated Security=True;Connect Timeout=5";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open(); // sollte mit try catch gesichert werden
            return conn;
        }

        public static bool registrieren(String vorname, String zuname,String passwort, String strasse, int hNr, int tNr, String telNr, int plz, String ort, String email)
        {
            string SQL = "insert into User(vorname,zuname,passwort, email, telefonnummer, strasse, hausnummer, tuernummer, plz, ort) Values(@vorname,@zuname,@passwort,@email,@tNr,@strasse,@hNr,@tNr,@plz,@ort)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.getConnection();
            cmd.Parameters.Add(new SqlParameter("vorname", vorname));
            cmd.Parameters.Add(new SqlParameter("zuname", zuname));
            cmd.Parameters.Add(new SqlParameter("passwort", passwort));
            cmd.Parameters.Add(new SqlParameter("email", email));
            cmd.Parameters.Add(new SqlParameter("tNr", tNr));
            cmd.Parameters.Add(new SqlParameter("strasse", tNr));
            cmd.Parameters.Add(new SqlParameter("hausnummer", tNr));
            cmd.Parameters.Add(new SqlParameter("türnummer", tNr));
            cmd.Parameters.Add(new SqlParameter("plz", tNr));
            cmd.Parameters.Add(new SqlParameter("ort", tNr));

            SqlDataReader reader = cmd.ExecuteReader();


            return true;
        }
        
    }

}
