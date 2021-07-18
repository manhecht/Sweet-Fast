using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        private String ankunftszeit;
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
        public String Ankunftszeit
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

       public Bestellung(int konditorID, int bestellerID)
        {
            this.OrderFromID = konditorID;
            this.KundeID = bestellerID;
            string SQL = "INSERT INTO [Bestellungen] ([orderFromID],[gesamtpreis],[ankuftszeit],[kundeID]) values(@orderFrom,@gesamt,@ankuftszeit,@kundeID); SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(SQL);
            cmd.Connection = Main.getConnection();
            cmd.Parameters.AddWithValue("orderFrom", konditorID);
            cmd.Parameters.AddWithValue("gesamt", 0);
            cmd.Parameters.AddWithValue("ankuftszeit", DateTime.Now.TimeOfDay);
            cmd.Parameters.AddWithValue("kundeID", bestellerID);
       
            this.BestellungID= Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();

 
        }
        //TODO
        //getBestellung() oder getWarenkorb()
        //bestellen()


        public void setEssenToBestellung(Essen mahlzeit)
        {

            Gesamtpreis += mahlzeit.Preis;
            Essensliste.Add(mahlzeit);
        }


    }
}
