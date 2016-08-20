using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspQuizz
{
    public partial class AltKategori : System.Web.UI.UserControl
    {
        SqlConnection baglanti = new SqlConnection("Server=.;DataBase=Site;trusted_connection=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["altId"]);
            if (Request.QueryString["altId"]!=null)
            {

                SqlDataAdapter adtr = new SqlDataAdapter("Select * from AltKonu Where AltId=@id", baglanti);
                adtr.SelectCommand.Parameters.AddWithValue("id", id);
                DataTable t = new DataTable();
                adtr.Fill(t);      
                repeat.DataSource = t;
                repeat.DataBind();
                div.InnerText ="Not:Bilgiler Veritabanından geliyor.Eğer Veritabanında sayfanın tutacağı bilgiler yer almış olsaydı burda onu gösterebilirdik.";
            }
            
        }
    }
}