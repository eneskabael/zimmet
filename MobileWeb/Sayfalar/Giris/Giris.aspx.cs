using AkisNet.Helper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static MobileWeb.Properties;

namespace MobileWeb.Sayfalar.Giris
{
    public partial class Giris : System.Web.UI.Page
    {
        Web oWeb = new Web();     //web türünde bir obje oluşturur      obje içerisinde web için yazılmuş hazır metodlar bulunur.
        public Sql oSql = new Sql(); //sql türünde bir obje oluştıuruır         obje içerisinde sql çalıştırmak için hazır metodlar bulunur.

        protected void Page_Load(object sender, EventArgs e)
        {
            string kullanici_id = oWeb.GetQueryStringValue(Request.QueryString, "kullanici_id", "");  //url kullanıcı id'yi alıyor
            string sifre = oWeb.GetQueryStringValue(Request.QueryString, "sifre", "");  //şifreyi alıyor

            if (kullanici_id.Length > 0 && sifre.Length > 0)    //kullanıcı adı ve şifrenin boş olup olmamasına bakıyor
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select * from tb_kullanicilar where aktif=1 and kullanici_id=@kullanici_id and psw=@psw;"); //Yeni mysql command
                    cmd.CommandType = CommandType.Text; //Commend type belirliyor.
                    cmd.Parameters.AddWithValue("@kullanici_id", kullanici_id); //Parametre değerleri veriyor.
                    cmd.Parameters.AddWithValue("@psw", sifre);// Üstekkinin aynısı
                    DataTable liste = ExecuteReaderMySql(Constants.SQL_DBAKIS, cmd);// Mysql commandi veritabanında çalıştırıp liste datatableye atıyor sonuçları
                    if (liste.checkNotNullOrEmpty()) //liste boş mu ona bakılıyor
                    {
                        DataRow row = liste.Rows[0]; //listenin ilk eleemanını alıyor
                        UserInfo oUserInfo = new UserInfo(); //userinfo oluşturur
                        oUserInfo.akis_kullanici_id = oSql.GetRowValue(row, "kullanici_id", 0);//userinfo bilgilerini dolduruyor
                        oUserInfo.akis_sube_id = oSql.GetRowValue(row, "sube_id", 0);//üsttekinin aynısı
                        oUserInfo.displayname = oSql.GetRowValue(row, "ad_soyad", "");//bura da öyle 
                        oUserInfo.mobil_uygulama_admin = (oSql.GetRowValue(row, "mobil_uygulama_admin", 0) == 1) ? true : false;
                        Session["UserInfo"] = oUserInfo; //oluşturduğu userinfoyu sessiona atıyor
                        Response.Redirect("/Sayfalar/Personel/Zimmet/Liste.aspx"); //listeye  yönlendiriyor zimmet listesi
                    }
                }
                catch 
                {
                     
                }
            }
        }

        public DataTable ExecuteReaderMySql(string conn, MySqlCommand cmd)
        {
            DataSet ds = new DataSet();
            try
            {
                using (MySqlConnection con = new MySqlConnection(conn))
                {
                    cmd.Connection = con;
                    using (cmd)
                    {
                        con.Open();
                        cmd.CommandTimeout = int.MaxValue;
                        var adapter = new MySqlDataAdapter(cmd);
                        string _par = "";
                        foreach (MySqlParameter p in cmd.Parameters)
                        {
                            _par += p.ParameterName;
                            _par += p.Value == null ? "null" : "'" + p.Value.ToString() + "'"; ;
                        }
                        adapter.Fill(ds);
                        con.Close();
                    }
                }
                if (ds.Tables[0] != null)
                {
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
    }
}

/* Bu sayfada otomatik kullanıcı girişi yapılmaktadır. Mobil uygulamanın içerisine entegre edileceği için kullanıcı adı ve şifre url'den alınıyor 
 * daha sonra veri tabanında url'den gelen kullanıcı adı ,şifre ile eşleşen hesap olup olmadığı kontrol ediliyor. Eğer eşleşen hesap varsa zimmet listesi sayfasına yönlendiriyor. 
    */