using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sweet_Fast_BL;

namespace Sweet_Fast_PL
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Eintrag meinEintrag;
        protected void Page_Load(object sender, EventArgs e)
        {
            meinEintrag = Sweet_Fast_BL.Starter.newEintrag();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            meinEintrag = Sweet_Fast_BL.Starter.getEintragById("428d428c-e8c6-49a7-8190-0dc2e90bbaef");
            txt.Text = meinEintrag.Zitattext;
        }
    }
}