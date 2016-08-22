using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Guoli.Bll;

namespace Guoli.WebTest.DbProviderTest
{
    public partial class framwork_text : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var feedBackBll = new FeedbackBll();
            var list = feedBackBll.QueryAll();

            var a = 0;
        }
    }
}