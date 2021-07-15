using Sweet_Fast_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sweet_Fast_PL
{
    public partial class index : System.Web.UI.Page
    {
        User login = new User();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String inputEmail = txtEmailLogin.Text;
            String inputPasswort = txtPasswortLogin.Text;

            Sweet_Fast_BL.User.einloggen(inputEmail, inputPasswort);

            Session["loggedInUser"] = "Michael";
            Response.Redirect("KonditoreiUebersicht.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            String vorname = txtVornameRegister.Text;
            String nachname = txtZunameRegister.Text;
            String pwd = txtPasswortRegister.Text;
            String street = txtStreetRegister.Text;
            int hausnummer = Convert.ToInt32(txtHausnummerRegister.Text);
            int door = Convert.ToInt32(txtTürnummerRegister.Text);
            String telNr = txtTelefonRegister.Text;
            int plz = Convert.ToInt32(txtPLZRegister.Text);
            String ort = txtOrtRegister.Text;
            String email = txtEmailRegister.Text;

            bool erfolgreich = Sweet_Fast_BL.User.registrieren(vorname, nachname, pwd,street,hausnummer,door,telNr,plz,ort,email);

            if (erfolgreich)
            {
                lblResponse.Text = "Danke " + vorname + " du hast dich erfolgreich registriert! Jetzt kannst du dich einloggen";
            }
            else
            {
                lblResponse.Text = "Etwas ist schief gegangen, bitte versuche es erneut.";
            }
        }
    }
}