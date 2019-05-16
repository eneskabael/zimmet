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

namespace MobileWeb.Sayfalar.Personel.Zimmet
{

    public partial class Liste : System.Web.UI.Page
    {
        public Sql oSql = new Sql();
        UserInfo oUserInfo = null;
        public List<Properties.Zimmet> oZimmet //Zimmet Listesi, zimmet objelerinin tutulduğu liste
        {
            get
            {
                if (Session["oZimmet"] == null)
                {
                    Session["oZimmet"] = new List<Properties.Zimmet>();
                    return (List<Properties.Zimmet>)Session["oZimmet"];
                }
                else
                {
                    return (List<Properties.Zimmet>)Session["oZimmet"];
                }
            }
            set
            {
                Session["oZimmet"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            oUserInfo = Session["UserInfo"] as UserInfo;
            ListeGetir();
        }

        public void ListeGetir()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tb_zimmetler where teslim_alan_id=@teslim_alan_id and teslim_alan_sube_id=@teslim_alan_sube_id;");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@teslim_alan_id", oUserInfo.akis_kullanici_id);
                cmd.Parameters.AddWithValue("@teslim_alan_sube_id", oUserInfo.akis_sube_id);
                DataTable liste = ExecuteReaderMySql(Constants.SQL_DBAKIS, cmd); //Database'den zimmet listesinin çekildiği kod bloğu
                if (liste.checkNotNullOrEmpty())
                {
                    using (liste)
                    {
                        oZimmet = (from cc in liste.AsEnumerable()
                             select new Properties.Zimmet()
                             {
                                 file_id = oSql.GetRowValue(cc, "file_id", 0),
                                 teslim_alan_id = oSql.GetRowValue(cc, "teslim_alan_id", 0),
                                 teslim_alan_sube_id = oSql.GetRowValue(cc, "teslim_alan_sube_id", 0),
                                 teslim_alan_adi = oSql.GetRowValue(cc, "teslim_alan_adi", ""),
                                 teslim_alan_gorevi = oSql.GetRowValue(cc, "teslim_alan_gorevi", ""),
                                 teslim_alan_departmani = oSql.GetRowValue(cc, "teslim_alan_departmani", ""),
                                 teslim_eden_id = oSql.GetRowValue(cc, "teslim_eden_id", 0),
                                 teslim_eden_sube_id = oSql.GetRowValue(cc, "teslim_eden_sube_id", 0),
                                 teslim_eden_adi = oSql.GetRowValue(cc, "teslim_eden_adi", ""),
                                 marka = oSql.GetRowValue(cc, "marka", ""),
                                 model = oSql.GetRowValue(cc, "model", ""),
                                 cins = oSql.GetRowValue(cc, "cins", ""),
                                 aciklama = oSql.GetRowValue(cc, "aciklama", ""),
                                 adet = oSql.GetRowValue(cc, "adet", 0),
                                 tarih = oSql.GetRowValue<DateTime?>(cc, "tarih", (DateTime?)null),
                             }).ToList<Properties.Zimmet>();
                    }
                } //Databaseden sonuç gelir ise zimmet listesini gelen sonuca göre doldurur
                else
                {
                    oZimmet = new List<Properties.Zimmet>();
                }
            }
            catch
            {
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

