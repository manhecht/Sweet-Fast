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
            try {
                conn.Open(); 
            }
            catch { }

                return conn;
        }
        //registriert den user in dem ein Datenbank Eintrag angelegt wird
        public static bool registrieren(String vorname, String zuname,String passwort, String strasse, int hNr, int tNr, String telNr, int plz, String ort, String email)
        {
            try
            {
                string SQL = "INSERT INTO [User] ([vorname],[zuname],[passwort],[email],[telefonnummer],[strasse],[hausnummer],[türnummer],[plz],[ort]) values(@vorname,@zuname,@passwort,@email,@telefonnummer,@strasse,@hausnummer,@türnummer,@plz,@ort)";
                SqlCommand cmd = new SqlCommand(SQL);
                cmd.Connection = getConnection();
                cmd.Parameters.AddWithValue("vorname", vorname);
                cmd.Parameters.AddWithValue("zuname", zuname);
                cmd.Parameters.AddWithValue("passwort", passwort);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("telefonnummer", telNr);
                cmd.Parameters.AddWithValue("strasse", strasse);
                cmd.Parameters.AddWithValue("hausnummer", hNr);
                cmd.Parameters.AddWithValue("türnummer", tNr);
                cmd.Parameters.AddWithValue("plz", plz);
                cmd.Parameters.AddWithValue("ort", ort);
                cmd.ExecuteNonQuery();

                cmd.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }

            
        }

        //vergleicht email + passwort 
        public static User einloggen(String email, String passwort)
        {
            User meinUser = new User();

            //User Properties -> Manu?
            //fillUserfromSQL
            //getUser
            return meinUser;
        }
        
    }

}
