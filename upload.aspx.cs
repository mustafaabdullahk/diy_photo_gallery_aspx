using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Drawing;

public partial class upload : System.Web.UI.Page
{
  FileUpload[] fu = new FileUpload[20];
  OleDbConnection bg;
    protected void Page_Load(object sender, EventArgs e)
    {
      bg = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=" + Server.MapPath("~/App_Data/resgalvt.mdb"));
      kontrol_ekle();
      if (!IsPostBack)
      {
          Panel1.Visible = false;
          Panel2.Visible = false;
      }
      
    }

  public static System.Drawing.Image Olcekle(string resimYolu, int wid, int hei)
  {
    System.Drawing.Image imgOrg = System.Drawing.Image.FromFile(resimYolu);
    System.Drawing.Image imgOlceklenmis = imgOrg.GetThumbnailImage(wid, hei, null, IntPtr.Zero);
    imgOrg.Dispose();
    return imgOlceklenmis;
  }

  public void uploads()
  {
    for (int i = 0; i < int.Parse(adet_sec.SelectedValue); i++)
    {
      FileUpload f = fu[i];
      if (f.HasFile)
      {
        f.SaveAs(Server.MapPath("~/Img/") + fu[i].FileName);
        System.Drawing.Image Kucuk = Olcekle(Server.MapPath("~/Img/" + f.FileName), 150, 80);
        Kucuk.Save(Server.MapPath("~/Img/Thumbs/" + f.FileName));
      }
    }
  }

  public void kontrol_ekle()
  {
    for (int i = 0; i < int.Parse(adet_sec.SelectedValue); i++)
    {
      fu[i] = new FileUpload();
      fu[i].ID = "fu_" + i.ToString();
      resimler.Controls.Add(fu[i]);
    }
  }

  public string resim_adlari()
  {
    string sonuc = "";
    for (int i = 0; i < int.Parse(adet_sec.SelectedValue); i++)
    {
      FileUpload f = fu[i];
      if (f.HasFile)
      {
        sonuc += f.FileName.Replace("ß", "") + "ß";
      }
    }
    return sonuc;
  }
  protected void Button1_Click(object sender, EventArgs e)
  {
    uploads();
    kayit(resim_adlari());
  }

  public void kayit(string resimler)
  {
    OleDbCommand komut = new OleDbCommand("insert into albumt (albumadi,resimler) values('"+TextBox1.Text+"','"+resimler+"')", bg);
    bg.Open();
    komut.ExecuteNonQuery();
    bg.Close();
  }
  protected void btnkntrl_Click(object sender, EventArgs e)
  {
      bg.Close();
      bg.Open();
      Session["album"] = TextBox1.Text;
      string sorgu = "select * from albumt where AlbumAdi=@1";
      OleDbCommand kontrol = new OleDbCommand(sorgu, bg);
      kontrol.Parameters.Add("@1", Session["album"].ToString());
      OleDbDataReader oku;
      oku = kontrol.ExecuteReader();
      while (oku.Read())
      {
          Session["kontrol_album"] = oku[1].ToString();
      }
      if (Session["kontrol_album"].ToString() != TextBox1.Text)
      {
          Panel1.Visible = true;
          Panel2.Visible = true;
          Image1.ImageUrl = "~/Images/ok.png";
          Label1.Text = "bu ismi kullanabilirsiniz";
          Label1.BackColor = Color.LightGreen;
          Label1.BorderColor = Color.Green;          
      }
      else
      {
          Panel2.Visible = true;
          Label1.Text = "ayný isimde baska bir album bulunmaktadýr";
          Image1.ImageUrl = "~/Images/red.png";
          Panel2.BackColor = Color.LightPink;
          Panel2.BorderColor = Color.Red;
      }
  }
}
