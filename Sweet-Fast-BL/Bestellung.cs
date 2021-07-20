using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweet_Fast_BL
{
    public class Bestellung
    {
        private int bestellungID;
        private int orderFromID;
        private decimal gesamtpreis;
        private TimeSpan ankunftszeit;
        private int kundeID;
        private List<Essen> essensliste = new List<Essen>();

        public int BestellungID
        {
            get { return bestellungID; }
            internal set { bestellungID = value; }
        }
        public int OrderFromID
        {
            get { return orderFromID; }
            internal set { orderFromID = value; }
        }
        public decimal Gesamtpreis
        {
            get { return gesamtpreis; }
            internal set { gesamtpreis = value; }
        }
        public TimeSpan Ankunftszeit
        {
            get { return ankunftszeit; }
            internal set { ankunftszeit = value; }
        }
        public int KundeID
        {
            get { return kundeID; }
            internal set { kundeID = value; }
        }
        public List<Essen> Essensliste
        {
            get { return essensliste; }
            internal set { essensliste = value; }
        }
        //Erstellt eine Bestellungsobjekt 

       public Bestellung(int konditorID, int bestellerID)
        {
            this.OrderFromID = konditorID;
            this.KundeID = bestellerID;

        }


        
        public void setEssenToBestellung(Essen mahlzeit)
        {

            string SQL = "INSERT INTO [Einzelbestellungen] ([bestEssenID],[rechnungsID]) values(@essenID,@rechnungsID)";
            SqlCommand cmd = new SqlCommand(SQL);
            cmd.Connection = Main.getConnection();
            cmd.Parameters.AddWithValue("essenID", mahlzeit.EssenID);
            cmd.Parameters.AddWithValue("rechnungsID", BestellungID);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            Gesamtpreis += mahlzeit.Preis;//Erhöht Preis
            
        }
        public void removeEssenFromBestellung(Essen mahlzeit)
        {
            string SQL = "DELETE TOP (1) FROM [Einzelbestellungen] where rechnungsID = @BestellungID and bestEssenID = @EssenID";
            SqlCommand cmd = new SqlCommand(SQL);
            cmd.Connection = Main.getConnection();
            cmd.Parameters.Add(new SqlParameter("BestellungID", BestellungID));
            cmd.Parameters.Add(new SqlParameter("EssenID", mahlzeit.EssenID));
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            Gesamtpreis -= mahlzeit.Preis;

        }

        public void createBestellung()
        {
            string SQL = "INSERT INTO [Bestellungen] ([orderFromID],[gesamtpreis],[ankuftszeit],[kundeID]) values(@orderFrom,@gesamt,@ankuftszeit,@kundeID); SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(SQL);
            cmd.Connection = Main.getConnection();
            cmd.Parameters.AddWithValue("orderFrom", OrderFromID);
            cmd.Parameters.AddWithValue("gesamt", 0);
            cmd.Parameters.AddWithValue("ankuftszeit", DateTime.Now.AddMinutes(30).TimeOfDay);
            cmd.Parameters.AddWithValue("kundeID", KundeID);

            this.BestellungID = Convert.ToInt32(cmd.ExecuteScalar());//returned erstellte ID und speichert diese -> PL sollte diese im Session aufbewahren um nachher getBestellung() aufrufen zu können
            cmd.Connection.Close();
        }
        //Trägt Gesamtpreis ein 
        public void bestellen()
        {

            string SQL = "UPDATE [Bestellungen] SET [gesamtpreis]=@gesamt WHERE bestellungID=@bestellungID";
            SqlCommand cmd = new SqlCommand(SQL);
            cmd.Connection = Main.getConnection();
            cmd.Parameters.AddWithValue("bestellungID", bestellungID);
            cmd.Parameters.AddWithValue("gesamt", Gesamtpreis);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //Erstellt ein Bestellungsobjekt anhand vorhandenem in der Datenbank
        public static Bestellung getBestellung(int bestellungID)
        {
            string SQL = "select * from [Bestellungen] where bestellungID = @id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.getConnection();
            cmd.Parameters.Add(new SqlParameter("id", bestellungID));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read(); //setzt den Reader auf den ersten / nächsten DS
                return fillBestellungFromSQLDataReader(reader);
            }
            else
                return null;

        }


        private static Bestellung fillBestellungFromSQLDataReader(SqlDataReader reader)
        {
            Bestellung eineBestellung = new Bestellung(reader.GetInt32(1),reader.GetInt32(4));
            eineBestellung.BestellungID = reader.GetInt32(0);
            eineBestellung.Gesamtpreis = reader.GetDecimal(2);
            eineBestellung.Ankunftszeit = reader.GetTimeSpan(3);



            return eineBestellung;
        }
    }
}
