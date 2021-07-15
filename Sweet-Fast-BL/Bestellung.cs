using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweet_Fast_BL
{
    class Bestellung
    {
        private int bestellungID;
        private int orderFromID;
        private int gesamtpreis;
        private String ankunftszeit;
        private int kundeID;

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
        public int Gesamtpreis
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



    }
}
