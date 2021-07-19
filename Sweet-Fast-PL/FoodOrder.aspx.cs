using Sweet_Fast_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sweet_Fast_PL
{
    public partial class FoodOrder : System.Web.UI.Page
    {
        int currentBusinessID;
        Konditorei currentBusiness;

        String closingHour;
        List<Essen> essenImWarenkorb;
        List<Essen> alleSpeisen;
        Bestellung best;
        int essenSelected;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedInUser"] == null)  
            {
                Response.Redirect("Index.aspx");
            }
            if (!IsPostBack)//Erster Aufruf
            {
                currentBusinessID = (int)Session["selectedBusiness"];

                currentBusiness = Konditorei.getKonditorei(currentBusinessID);
                best = new Bestellung(currentBusinessID, (int)Session["loggedInUser"]);
                best.createBestellung();
                
                closingHour = currentBusiness.EndH;




                lblFoodOrderPlaceName.Text = best.Gesamtpreis.ToString();
                lblFoodOrderPlaceOpening.Text = "Das Lokal hat bis " + closingHour + " offen!";
                alleSpeisen = Essen.getAllEssen(currentBusinessID);
                GVEssen.DataSource = alleSpeisen;
                GVEssen.DataBind();

                Session["Bestellung"] = best;
                Session["selected"] = essenSelected;
                Session["selectedBusiness"] = currentBusinessID;

            }
            else
            {
                currentBusinessID = (int)Session["selectedBusiness"];
                best = (Bestellung)Session["Bestellung"];

            }


        }

        protected void GVEssen_SelectedIndexChanged(object sender, EventArgs e)
        {


            GridViewRow row = GVEssen.SelectedRow;
            essenSelected = Essen.getAllEssen(currentBusinessID)[row.RowIndex].EssenID;
            best.setEssenToBestellung(Essen.getEssen(essenSelected));
            Session["Bestellung"] = best;
            Session["selected"] = essenSelected;

        }

        protected void GVWarenkorb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}