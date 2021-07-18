using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Sweet_Fast_BL
{
    public class Essen
    {

        private int essenID;
        private int unternehmenID;
        private string foodName;
        private decimal preis;

        public int EssenID
        {
            get { return essenID; }
            internal set { essenID = value; }
        }
        public int UnternehmenID
        {
            get { return unternehmenID; }
            internal set { unternehmenID = value; }
        }
        public string FoodName
        {
            get { return foodName; }
            internal set { foodName = value; }
        }
        public decimal Preis
        {
            get { return preis; }
            internal set { preis = value; }
        }


        private static Essen fillEssenFromSQLDataReader(SqlDataReader reader)
        {
 
            Essen einEssen = new Essen();
            einEssen.EssenID = reader.GetInt32(0);
            einEssen.UnternehmenID = reader.GetInt32(1);
            einEssen.FoodName = reader.GetString(2);
            einEssen.Preis = reader.GetDecimal(3);
       
            return einEssen;
        }
        public static Essen getEssen(int SpeiseID)
        {
            string SQL = "select * from Essen where essenID = @id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.getConnection();
            cmd.Parameters.Add(new SqlParameter("id", SpeiseID));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read(); //setzt den Reader auf den ersten / nächsten DS
                return fillEssenFromSQLDataReader(reader);
            }
            else
                return null;
        }
        public static List<Essen> getAllEssen()
        {
            SqlCommand cmd = new SqlCommand("select * from Essen", Main.getConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            List<Essen> alleEssen = new List<Essen>();
            while (reader.Read())
            {
                Essen einEssen = fillEssenFromSQLDataReader(reader);
                alleEssen.Add(einEssen);
            }


            return alleEssen;
        }

        //TODO
        //Methode setEssentoBestellung
    }
}
