using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
namespace AspQuizz
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Server=.;DataBase=Site;trusted_connection=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From Konu", baglanti);
            DataTable t = new DataTable();
            adtr.Fill(t);
            repeater.DataSource = t;
            repeater.DataBind();
            SqlDataAdapter adtr2 = new SqlDataAdapter("Select * From GununSozu Where SozId=@id", baglanti);
            adtr2.SelectCommand.Parameters.AddWithValue("id", DateTime.Now.Hour);
            DataTable t2 = new DataTable();
            adtr2.Fill(t2);
            gununSozuRepeat.DataSource = t2;
            gununSozuRepeat.DataBind();
        }
        int a;
        protected void repeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
         
          
        }

        protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            a = int.Parse((e.Item.DataItem as DataRowView).Row["KonuId"].ToString());
            Repeater r = e.Item.FindControl("repeater2") as Repeater;
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From AltKonu Where KonuId=@id", baglanti);
            adtr.SelectCommand.Parameters.AddWithValue("id", a);
            DataTable t = new DataTable();
            adtr.Fill(t);
            r.DataSource = t;
            r.DataBind();
        }
    }
}