using FormulaOneDLL;
using FormulaOneDLL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormulaOneWebForm
{
    public partial class Default : System.Web.UI.Page
    {
        DBtools db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DBtools();
            if (!IsPostBack)
            {
                tb1.DataSource = db.GetTableList();
                tb1.DataBind();

                tb2.DataSource = db.GetHeaders("Country");
                tb2.DataBind();

                tb3.Items.Insert(0,"ASC");
                tb3.Items.Insert(1, "DESC");
            }
            GetCountry();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            tb2.DataSource = db.GetHeaders(tb1.SelectedItem.Value);
            tb2.DataBind();
            setDGV();
        }

        protected void OnSelectedIndexChangedTB23(object sender, EventArgs e)
        {
            setDGV();
        }

        protected void setDGV()
        {
            dgv.DataSource = db.GetData(tb1.SelectedItem.Value, tb2.SelectedItem.Value, tb3.SelectedItem.Value);
            dgv.DataBind();
        }

        public void GetCountry()
        {
            HttpWebRequest apiRequest = WebRequest.Create("https://localhost:44346/api/Country/") as HttpWebRequest;
            string apiResponse = "";
            try
            {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                    Country[] oCountry = Newtonsoft.Json.JsonConvert.DeserializeObject<Country[]>(apiResponse);
                    lbx.DataSource = oCountry;
                    lbx.DataBind();
                    lbx.Visible = true;
                }
            }
            catch (System.Net.WebException ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}