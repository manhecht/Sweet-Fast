using Sweet_Fast_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sweet_Fast_PL
{
    public partial class KonditoreiUebersicht : System.Web.UI.Page
    {
        List<Konditorei> kon = Konditorei.getAllKonditoreien();
        String user;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["selectedBusiness"] = "";

            user = (string)Session["loggedInUser"];
            
            if (user == "")  //noch funktioniert es nicht aber es sollt eig redirecten
            {
                Response.Redirect("Index.aspx");
            }


            lblHalloUser.Text = "Hallo " + user + " diese Unternehmen liefern zu dir: ";


            kon = Konditorei.getAllKonditoreien();
            GVKonditorei.DataSource = kon;
            GVKonditorei.DataBind();
        }

        protected void GVKonditorei_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GVKonditorei.SelectedRow;
            Session["selectedBusiness"] = kon[row.RowIndex].KondID;
            Response.Redirect("FoodOrder.aspx");
        }
    }
}