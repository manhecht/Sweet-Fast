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
        Random rnd;
        int deliverytime;

        protected void Page_Load(object sender, EventArgs e)
        {

            String user = "RoboGrischa";
            String orderFrom = "McDonalds";


            lblThanks.Text = "Vielen Dank für Ihre Bestellung von " + orderFrom + ", " + user + "!";

            rnd = new Random();
            deliverytime = rnd.Next(25, 142);

            lblDeliveryTime.Text = "Ihre Bestellung komm in " + deliverytime.ToString() + " Minuten an!";


        }

        protected void btnReorder_Click(object sender, EventArgs e)
        {
            Response.Redirect("KonditoreiUebersicht.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}