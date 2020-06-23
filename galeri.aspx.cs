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

public partial class galeri : System.Web.UI.Page
{
    OleDbConnection bg;
    protected void Page_Load(object sender, EventArgs e)
    {
      bg = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=" + Server.MapPath("~/App_Data/resgalvt.mdb"));

      OleDbDataAdapter adaptor = new OleDbDataAdapter("select * from albumt order by Id desc", bg);
      DataTable table = new DataTable();
      adaptor.Fill(table);
      Repeater1.DataSource = table;
      Repeater1.DataBind();
    }

  public string resimleri_al(string resimler, string resim_id)
  {
    string[] dizi = resimler.Split('ß');
    string sonuc = "";

    for (int i = 0; i < dizi.Length-1; i++)
    {
      sonuc += "<a rel=slayt["+resim_id+"] href='Img/" + dizi[i] + "'><img src='Img/Thumbs/"+dizi[i]+"' border=0/></a> ";
    }

    return sonuc;
  }
}
