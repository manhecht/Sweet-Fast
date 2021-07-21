using Sweet_Fast_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sweet_Fast_PL
{
    public partial class KonditoreiUebersicht : System.Web.UI.Page
    {
        List<Konditorei> kon = Konditorei.getAllKonditoreien();
        int userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["selectedBusiness"] = "";

            
            
            if (Session["loggedInUser"] == null)  
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                 userID = (int)Session["loggedInUser"];
            }

         
            lblHalloUser.Text = "Hallo " + Sweet_Fast_BL.User.getUser(userID).Vorname + " diese Unternehmen liefern zu dir: ";
            GVKonditorei.DataSource = kon;
            GVKonditorei.DataBind();
        }

        protected void GVKonditorei_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GVKonditorei.SelectedRow;
            Session["selectedBusiness"] = kon[row.RowIndex].KondID;
            bool offen = Konditorei.checkÖffnungszeit(kon[row.RowIndex].KondID);
            if (offen)
            {
                Response.Redirect("FoodOrder.aspx");
            }
            else
            {
               
            }
           
        }
           public string öffnung(int kondID)
        {

            bool offen = Konditorei.checkÖffnungszeit(kondID);
            if (offen)
            {
                return "geöffnet";

            }
            else
            {
                return "geschlossen";
            }

     
        }
    }
}