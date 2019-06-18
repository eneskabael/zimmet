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
    public partial class Yeni : System.Web.UI.Page
    {
        public Sql oSql = new Sql();
        UserInfo oUserInfo = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            oUserInfo = Session["UserInfo"] as UserInfo;

            if (oUserInfo != null && oUserInfo.mobil_uygulama_admin == false)
            {
                divYetki.Visible = true;
            }
            else if(oUserInfo != null && oUserInfo.mobil_uygulama_admin == true)
            {
                divYeni.Visible = true;
            }
            else
            {
                divYetki.Visible = true;
            }
        }

        protected void btnKaydet_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string sql = @"INSERT INTO tb_zimmetler (teslim_alan_id, teslim_alan_sube_id, teslim_alan_adi, teslim_alan_gorevi, teslim_alan_departmani, teslim_eden_id, teslim_eden_sube_id, teslim_eden_adi, marka, model, cins, aciklama, adet, tarih)
                            VALUES (@teslim_alan_id, @teslim_alan_sube_id, @teslim_alan_adi, @teslim_alan_gorevi, @teslim_alan_departmani, @teslim_eden_id, @teslim_eden_sube_id, @teslim_eden_adi, @marka, @model, @cins, @aciklama, @adet, @tarih);";
                
                MySqlCommand cmd = new MySqlCommand(sql);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@teslim_alan_id", tb_teslim_alan_id.Text);
                cmd.Parameters.AddWithValue("@teslim_alan_sube_id", tb_teslim_alan_sube_id.Text.EnsureNotNull(0));
                cmd.Parameters.AddWithValue("@teslim_alan_adi", tb_teslim_alan_adi.Text);
                cmd.Parameters.AddWithValue("@teslim_alan_gorevi", tb_teslim_alan_gorevi.Text);
                cmd.Parameters.AddWithValue("@teslim_alan_departmani", tb_teslim_alan_departmani.Text);
                cmd.Parameters.AddWithValue("@teslim_eden_id", oUserInfo.akis_kullanici_id.EnsureNotNull(0));
                cmd.Parameters.AddWithValue("@teslim_eden_sube_id", oUserInfo.akis_sube_id.EnsureNotNull(0));
                cmd.Parameters.AddWithValue("@teslim_eden_adi", oUserInfo.displayname);
                cmd.Parameters.AddWithValue("@marka", tb_marka.Text);
                cmd.Parameters.AddWithValue("@model", tb_model.Text);
                cmd.Parameters.AddWithValue("@cins", tb_cins.Text);
                cmd.Parameters.AddWithValue("@aciklama", tb_aciklama.Text);
                cmd.Parameters.AddWithValue("@adet", tb_adet.Text.EnsureNotNull(0));
                cmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToAkisDateShortTireli());
                int sonuc = ExecuteNonQueryMySql(Constants.SQL_DBAKIS, cmd);
                if (sonuc > 0)
                {
                    Response.Redirect("/Sayfalar/Personel/Zimmet/Liste.aspx", true);
                }
                else
                {
                    //hata oluştu
                }
            }
            catch (Exception ex)
            {
                //hata oluştu
            }
        }

        public int ExecuteNonQueryMySql(string conn, MySqlCommand cmd)
        {
            int oReturn = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(conn))
                {
                    cmd.Connection = con;
                    using (cmd)
                    {
                        con.Open();
                        cmd.CommandTimeout = int.MaxValue;
                        string _par = "";
                        foreach (MySqlParameter p in cmd.Parameters)
                        {
                            _par += p.ParameterName;
                            _par += p.Value == null ? "null" : "'" + p.Value.ToString() + "'"; ;
                        }
                        oReturn = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return oReturn;
        }
    }
}