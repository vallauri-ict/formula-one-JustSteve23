﻿using FormulaOneDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormulaOneWebForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBtools db = new DBtools();
            if (Page.IsPostBack)
            {

            }
            else
            {
                tb.DataSource = db.GetCountries();
                tb.DataBind();
            }
        }
    }
}