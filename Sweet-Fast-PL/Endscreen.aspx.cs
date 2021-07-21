using Sweet_Fast_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sweet_Fast_PL
{
    public partial class Endscreen : System.Web.UI.Page
    {
  

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["loggedInUser"] == null)
            {
                Response.Redirect("Index.aspx");
            }

            String vorname = Sweet_Fast_BL.User.getUser((int)Session["loggedInUser"]).Vorname;
            String zuname = Sweet_Fast_BL.User.getUser((int)Session["loggedInUser"]).Zuname;

            int orderFromID = (int)Session["selectedBusiness"];
            String orderFrom = Konditorei.getKonditorei(orderFromID).KondName;
            Bestellung best = (Bestellung)Session["Bestellung"];

            lblThanks.Text = "Vielen Dank für Ihre Bestellung von " + orderFrom + ", " + vorname +" "+zuname +"!";

            lblDeliveryTime.Text = "Ihre Bestellung kommt pünktlich um " + best.Ankunftszeit.ToString() + " an!";
            List<Essen> bestelltesEssen = Essen.getEssenFromBestellung(best.BestellungID);
            GVEndscreen.DataSource = bestelltesEssen;
            GVEndscreen.DataBind();

        }

        protected void btnReorder_Click(object sender, EventArgs e)
        {
            Response.Redirect("KonditoreiUebersicht.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
            Session["loggedInUser"] = "";
        }
    }
}