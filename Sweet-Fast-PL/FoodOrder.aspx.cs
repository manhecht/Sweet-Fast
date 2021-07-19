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




                lblFoodOrderPlaceName.Text = best.BestellungID.ToString();
                lblFoodOrderPlaceOpening.Text = "Das Lokal hat bis " + closingHour + " offen!";
                alleSpeisen = Essen.getAllEssen(currentBusinessID);
                GVEssen.DataSource = alleSpeisen;
                GVEssen.DataBind();

                Session["Bestellung"] = best;
            }
            else
            {
                int essenSelected = (int)Session["selected"];
                best =(Bestellung)Session["Bestellung"];
                lblFoodOrderPlaceName.Text = essenSelected.ToString();
                essenImWarenkorb = Essen.getEssenFromWarenkorb(best.BestellungID);
                alleSpeisen = Essen.getAllEssen(currentBusinessID);
                GVEssen.DataSource = alleSpeisen;
                GVEssen.DataBind();
                GVWarenkorb.DataSource = essenImWarenkorb;
                GVWarenkorb.DataBind();
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GVEssen.SelectedRow;
            int essenSelected = alleSpeisen[row.RowIndex].EssenID;
            
            best.setEssenToBestellung(Essen.getEssen(essenSelected));
            Session["Bestellung"] = best;
            Session["selected"] = 2;

        }

        protected void GVWarenkorb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}