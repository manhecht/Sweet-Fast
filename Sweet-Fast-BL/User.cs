using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

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

        public static string ComputeHash(string plainText, string hashAlgorithm, byte[] saltBytes)
        {
            // If salt is not specified, generate it.
            if (saltBytes == null)
            {
                // Define min and max salt sizes.
                int minSaltSize = 4;
                int maxSaltSize = 8;

                // Generate a random number for the size of the salt.
                Random random = new Random();
                int saltSize = random.Next(minSaltSize, maxSaltSize);

                // Allocate a byte array, which will hold the salt.
                saltBytes = new byte[saltSize];

                // Initialize a random number generator.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                // Fill the salt with cryptographically strong byte values.
                rng.GetNonZeroBytes(saltBytes);
            }

            // Convert plain text into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Allocate array, which will hold plain text and salt.
            byte[] plainTextWithSaltBytes =
            new byte[plainTextBytes.Length + saltBytes.Length];

            // Copy plain text bytes into resulting array.
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            // Append salt bytes to the resulting array.
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

            HashAlgorithm hash;

            // Make sure hashing algorithm name is specified.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Initialize appropriate hashing algorithm class.
            switch (hashAlgorithm.ToUpper())
            {

                case "SHA384":
                    hash = new SHA384Managed();
                    break;

                case "SHA512":
                    hash = new SHA512Managed();
                    break;

                default:
                    hash = new MD5CryptoServiceProvider();
                    break;
            }

            // Compute hash value of our plain text with appended salt.
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            // Create array which will hold hash and original salt bytes.
            byte[] hashWithSaltBytes = new byte[hashBytes.Length +
            saltBytes.Length];

            // Copy hash bytes into resulting array.
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            // Append salt bytes to the result.
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // Convert result into a base64-encoded string.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Return the result.
            return hashValue;
        }

        public static bool VerifyHash(string plainText, string hashAlgorithm, string hashValue)
        {

            // Convert base64-encoded hash value into a byte array.
            byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);

            // We must know size of hash (without salt).
            int hashSizeInBits, hashSizeInBytes;

            // Make sure that hashing algorithm name is specified.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Size of hash is based on the specified algorithm.
            switch (hashAlgorithm.ToUpper())
            {

                case "SHA384":
                    hashSizeInBits = 384;
                    break;

                case "SHA512":
                    hashSizeInBits = 512;
                    break;

                default: // Must be MD5
                    hashSizeInBits = 128;
                    break;
            }

            // Convert size of hash from bits to bytes.
            hashSizeInBytes = hashSizeInBits / 8;

            // Make sure that the specified hash value is long enough.
            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return false;

            // Allocate array to hold original salt bytes retrieved from hash.
            byte[] saltBytes = new byte[hashWithSaltBytes.Length - hashSizeInBytes];

            // Copy salt from the end of the hash to the new array.
            for (int i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

            // Compute a new hash string.
            string expectedHashString = ComputeHash(plainText, hashAlgorithm, saltBytes);

            // If the computed hash matches the specified hash,
            // the plain text value must be correct.
            return (hashValue == expectedHashString);
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
                string passHash = ComputeHash(passwort, "SHA512", null);

                cmd.Parameters.AddWithValue("passwort", passHash);
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

        public static bool registrierenTwo(String vorname, String zuname, String passwort, String strasse, int hNr, String telNr, int plz, String ort, String email)
        {
            try
            {
                string SQL = "INSERT INTO [User] ([vorname],[zuname],[passwort],[email],[telefonnummer],[strasse],[hausnummer],[plz],[ort]) values(@vorname,@zuname,@passwort,@email,@telefonnummer,@strasse,@hausnummer,@plz,@ort)";
                SqlCommand cmd = new SqlCommand(SQL);
                cmd.Connection = Main.getConnection();
                cmd.Parameters.AddWithValue("vorname", vorname);
                cmd.Parameters.AddWithValue("zuname", zuname);
                string passHash = ComputeHash(passwort, "SHA512", null);

                cmd.Parameters.AddWithValue("passwort", passHash);
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


        public static bool checkDuplicate(String email)
            {
            string SQL = "Select * from [User] where email=@email";
            SqlCommand cmd = new SqlCommand(SQL);
            cmd.Connection = Main.getConnection();
            cmd.Parameters.AddWithValue("email", email);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            } else
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

        public static User einloggenTwo(String email, String passwort)
        {
            User meinUser = new User();
            string sql = "Select userID,email,passwort from [User] where email=@email";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.getConnection();
            cmd.Parameters.AddWithValue("@email", email);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            string userid = dt.Rows[0]["email"].ToString();
            string password = dt.Rows[0]["passwort"].ToString();
            bool flag = VerifyHash(passwort, "SHA512", password);
            SqlDataReader reader = cmd.ExecuteReader();

            if (userid == email && flag == true)
            {
                reader.Read();
                meinUser = getUser(reader.GetInt32(0));
            }

            return meinUser;

        }


    }
}
