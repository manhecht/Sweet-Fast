using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace Sweet_Fast_BL
{
    public class User
    {
        private int userId;
        private String vorname;
        private String zuname;
        private String passwort;
        private String email;
        private String strasse;
        private int hausnummer;
        private int türnummer;
        private int plz;
        private String ort;
        private string telefonnummer;


        public int UserId
        {
            get { return userId; }
            internal set { userId = value; }
        }
        public string Vorname
        {
            get { return vorname; }
            internal set { vorname = value; }
        }
        public string Zuname
        {
            get { return zuname; }
            internal set { zuname = value; }
        }
        public string Passwort
        {
            get { return passwort; }
            internal set { passwort = value; }
        }
        public string Email
        {
            get { return email; }
            internal set { email = value; }
        }
        public string Telefonnummer
        {
            get { return telefonnummer; }
            internal set { telefonnummer = value; }
        }
        public String Strasse
        {
            get { return strasse; }
            internal set { strasse = value; }
        }
        public int Hausnummer
        {
            get { return hausnummer; }
            internal set { hausnummer = value; }
        }
        public int Türnummer
        {
            get { return türnummer; }
            internal set { türnummer = value; }
        }
        public int Plz
        {
            get { return plz; }
            internal set { plz = value; }
        }
        public string Ort
        {
            get { return ort; }
            internal set { ort = value; }
        }


        //registriert den user in dem ein Datenbank Eintrag angelegt wird
        public static bool registrieren(String vorname, String zuname, String passwort, String strasse, int hNr, int tNr, String telNr, int plz, String ort, String email)
        {
            try
            {
                string SQL = "INSERT INTO [User] ([vorname],[zuname],[passwort],[email],[telefonnummer],[strasse],[hausnummer],[türnummer],[plz],[ort]) values(@vorname,@zuname,@passwort,@email,@telefonnummer,@strasse,@hausnummer,@türnummer,@plz,@ort)";
                SqlCommand cmd = new SqlCommand(SQL);
                cmd.Connection = Main.getConnection();
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

        public static bool registrierenTwo(String vorname, String zuname, String passwort, String strasse, int hNr,  String telNr, int plz, String ort, String email)
        {
            try
            {
                string SQL = "INSERT INTO [User] ([vorname],[zuname],[passwort],[email],[telefonnummer],[strasse],[hausnummer],[plz],[ort]) values(@vorname,@zuname,@passwort,@email,@telefonnummer,@strasse,@hausnummer,@plz,@ort)";
                SqlCommand cmd = new SqlCommand(SQL);
                cmd.Connection = Main.getConnection();
                cmd.Parameters.AddWithValue("vorname", vorname);
                cmd.Parameters.AddWithValue("zuname", zuname);
                cmd.Parameters.AddWithValue("passwort", passwort);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("telefonnummer", telNr);
                cmd.Parameters.AddWithValue("strasse", strasse);
                cmd.Parameters.AddWithValue("hausnummer", hNr);
              
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
        private static User fillUserFromSQLDataReader(SqlDataReader reader)
        {
            User einKunde = new User();
            einKunde.UserId = reader.GetInt32(0);
            einKunde.Vorname = reader.GetString(1);
            einKunde.Zuname = reader.GetString(2);
            einKunde.Passwort = reader.GetString(3);
            einKunde.Email = reader.GetString(4);
            einKunde.Telefonnummer = reader.GetString(5);
            einKunde.Strasse = reader.GetString(6);
            einKunde.Hausnummer = reader.GetInt32(7);
            einKunde.Plz = reader.GetInt32(9);
            einKunde.Ort = reader.GetString(10);

            try
            {

                einKunde.Türnummer = reader.GetInt32(8);
            }
            catch { }


            return einKunde;
        }
        public static User getUser(int UserID)
        {
            string SQL = "select * from [User] where userID = @id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.getConnection();
            cmd.Parameters.Add(new SqlParameter("id", UserID));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read(); //setzt den Reader auf den ersten / nächsten DS
                return fillUserFromSQLDataReader(reader);
            }
            else
                return null;
        }
        //vergleicht email + passwort 
        public static User einloggen(String email, String passwort)
        {
            User meinUser = new User();
            string sql = "Select userID from [User] where email=@email AND passwort=@passwort";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.getConnection();
            cmd.Parameters.Add(new SqlParameter("email", email));
            cmd.Parameters.Add(new SqlParameter("passwort", passwort));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read(); //setzt den Reader auf den ersten / nächsten DS
                meinUser = getUser(reader.GetInt32(0));
            }

            return meinUser;
        }

       
    }
}
