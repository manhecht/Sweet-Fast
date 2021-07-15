using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using System.IO;
using System.Runtime.CompilerServices;

namespace Sweet_Fast_BL
{
    public  class Konditorei
    {
        //Variablen 
        private int kondID; //Konditorei ID
        private string kondName;//Name der Konditorei
        private string kondStrasse; //Straße der Konditorei
        private int kondHausnummer; //HNr der Konditorei
        private int kondTuernummer; //TNr der Konditorei
        private int kondPlz; //Postleitzahl
        private string kondOrt; //Ort
        private string startH; //Öffnungszeiten
        private string endH;
        private string businessType; //Art der Konditorei        
        //Properties
        //Zugriff auf alle erlaubt aber überschreiben nicht außerhalb BL
        public int KondID
        {
            get { return kondID; }
            internal set { kondID = value; }
        }
        public string KondName
        {
            get { return kondName; }
            internal set { kondName = value; }
        }
        public string KondStrasse
        {
            get { return kondStrasse; }
            internal set { kondStrasse = value; }
        }
        public int KondHausnummer
        {
            get { return kondHausnummer; }
            internal set { kondHausnummer = value; }
        }
        public int KondTuernummer
        {
            get { return kondTuernummer; }
            internal set { kondTuernummer = value; }
        }
        public int KondPlz
        {
            get { return kondPlz; }
            internal set { kondPlz = value; }
        }
        public string KondOrt
        {
            get { return kondOrt; }
            internal set { kondOrt = value; }
        }
        public string StartH
        {
            get { return startH; }
            internal set { startH = value; }
        }
        public string EndH
        {
            get { return endH; }
            internal set { endH = value; }
        }
        public string BusinessType
        {
            get { return businessType; }
            internal set { businessType = value; }
        }


        //Methoden
        private static Konditorei fillKonditoreiFromSQLDataReader(SqlDataReader reader)
        {
            Konditorei einKunde = new Konditorei();
            einKunde.KondID = reader.GetInt32(0);
            einKunde.KondName = reader.GetString(1);
            einKunde.KondStrasse = reader.GetString(2);
            einKunde.KondHausnummer = reader.GetInt32(3);
            try {

                einKunde.KondTuernummer = reader.GetInt32(4);
            }
            catch{ }
            
            einKunde.KondPlz = reader.GetInt32(5);
            einKunde.KondOrt = reader.GetString(6);
            einKunde.StartH = reader.GetTimeSpan(7).ToString();
            einKunde.EndH = reader.GetTimeSpan(8).ToString();
            einKunde.BusinessType = reader.GetString(9);
            return einKunde;
        }
        public static Konditorei getKonditorei(int KonditorID)
        {
            string SQL = "select * from Konditoreien where kondID = @id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.getConnection();
            cmd.Parameters.Add(new SqlParameter("id", KonditorID));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read(); //setzt den Reader auf den ersten / nächsten DS
                return fillKonditoreiFromSQLDataReader(reader);
            }
            else
                return null;
        }
        public static List<Konditorei> getAllKonditoreien()
        {
            SqlCommand cmd = new SqlCommand("select * from Konditoreien", Main.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            List<Konditorei> alleKonditoreien = new List<Konditorei>();
            while (reader.Read())
            {
                Konditorei einKunde = fillKonditoreiFromSQLDataReader(reader);
                alleKonditoreien.Add(einKunde);
            }


            return alleKonditoreien;
        }

    }

}
