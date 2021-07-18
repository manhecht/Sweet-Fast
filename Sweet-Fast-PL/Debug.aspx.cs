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
        Bestellung best = new Sweet_Fast_BL.Bestellung(2,2);
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnDebug_Click(object sender, EventArgs e)
        {
            best.setEssenToBestellung(Essen.getEssen(1));
            lblDebug.Text =best.BestellungID.ToString();

        }
    }
}