using Sweet_Fast_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sweet_Fast_PL
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDebug_Click(object sender, EventArgs e)
        {
            List<Konditorei> kon = Konditorei.getAllKonditoreien();

            bool zeit=Konditorei.checkÖffnungszeit(2);

            lblDebug.Text = zeit.ToString();
        }
    }
}