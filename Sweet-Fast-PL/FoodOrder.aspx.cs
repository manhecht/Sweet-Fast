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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                currentBusinessID = (int)Session["selectedBusiness"];
                currentBusiness = Konditorei.getKonditorei(currentBusinessID);
                lblFoodOrderPlace.Text = currentBusiness.KondName;
            }


        }
    }
}