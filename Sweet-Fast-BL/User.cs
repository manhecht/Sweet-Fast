using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
