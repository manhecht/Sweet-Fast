using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sweet_Fast_BL
{
    public class Eintrag
    {
        public string Id { get; private set; }
        public string Zitattext { get; set; }

        internal Eintrag()
        {
            Id = "";
            Zitattext = "";
        }

        public bool save()
        {
            SqlConnection conn = Starter.getConnection();
            SqlCommand cmd;
            string sql;
            int resultat;


            if (Id == "")
            {
                //Insert
                sql = "INSERT INTO Eintrag ([Id], [Zitattext]) values (@id,@zitattext)";
                this.Id = Guid.NewGuid().ToString();
            }
            else
            {
                sql = " UPDATE Eintrag set Zitattext=@zitattext where Id=@id";
            }

            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", this.Id);
            cmd.Parameters.AddWithValue("zitattext", this.Zitattext);

            resultat=cmd.ExecuteNonQuery();
            conn.Close();

            return resultat == 1;
        }
        internal static Eintrag getEintragById(string Id)
        {
            SqlConnection conn = Starter.getConnection();
            SqlCommand cmd;
            string sql;

            sql = "select Id, Zitattext from EIntrag where Id = @id";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", Id);
            

            SqlDataReader reader= cmd.ExecuteReader();
            Eintrag e = null;

            if (reader.Read())
            {
                e = new Eintrag();
                e.Id = reader.GetString(0);
                e.Zitattext = reader.GetString(1);
            }
            conn.Close();
            return e;

        }
    }
}
