using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweet_Fast_BL
{
    class Essen
    {

        private int essenID;
        private int unternehmenID;
        private string foodName;
        private int preis;

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
        public int Preis
        {
            get { return preis; }
            internal set { preis = value; }
        }
        //TODO
        //Methode getAllSpeisen
        //Methode setSpeisetoWarenkorb

    }
}
