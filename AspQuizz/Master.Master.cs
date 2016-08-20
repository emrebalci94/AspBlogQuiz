using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AspQuizz
{
    public partial class Master : System.Web.UI.MasterPage
    {
        SqlConnection baglanti = new SqlConnection("Server=.;DataBase=Site;trusted_connection=true");
        private void hakkimdaDoldur()
        {
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from Kisiler k join Meslek m on m.MeslekId=k.Meslek Where k.KisiId=@id", baglanti);
            adtr.SelectCommand.Parameters.AddWithValue("id", Session["kulId"]);
            DataTable t = new DataTable();
            adtr.Fill(t);
            repeatHakkimda.DataSource = t;
            repeatHakkimda.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            if (Request.QueryString["altId"]!=null)
            {
                Control ctrl = LoadControl("AltKategori.ascx");
                bodyYer.Controls.Add(ctrl);
            }

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

            if (Session["kulId"]!=null)
            {
                GirisPaneli.Visible = false;
                Hakkimzda.Visible = true;
                Cikis.Visible = true;
                hakkimdaDoldur();
            }
            else
            {
                GirisPaneli.Visible = true;
                Hakkimzda.Visible = false;
                Cikis.Visible = false;
            }

            DuyuruDoldur();
        }
        int a;
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
        private void DuyuruDoldur()
        {
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From Duyuru", baglanti);
            DataTable t = new DataTable();
            adtr.Fill(t);
            repeatDuyuru.DataSource = t;
            repeatDuyuru.DataBind();
        }
        protected void txtKullanici_TextChanged1(object sender, EventArgs e)
        {
           
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From Kisiler Where Kuladi=@kuladi and Sifre=@Sifre", baglanti);
            adtr.SelectCommand.Parameters.AddWithValue("kuladi", txtKullanici.Text);
            adtr.SelectCommand.Parameters.AddWithValue("Sifre", txtSifre.Text);
            DataTable t = new DataTable();
            adtr.Fill(t);
            if (t.Columns.Count>=1)
            {
                foreach (DataRow item in t.Rows)
                {
                    Session["kulId"] = item["KisiId"];
                    Hakkimzda.Visible = true;
                    hakkimdaDoldur();
                    break;
                }
                GirisPaneli.Visible = false;
               Cikis.Visible = true;
               
            }
        }

        protected void cikisYap_Click(object sender, EventArgs e)
        {
            Session["kulId"] = null;
            Response.Redirect("MasterDefault.aspx");
        }
    }
}