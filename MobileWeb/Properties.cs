using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWeb
{
    public class Properties
    {
        public class UserInfo //Giriş yapan kullanıcının bilgilerinin tutulduğu obje
        {
            public string displayname { get; set; }
            public int? akis_sube_id { get; set; }
            public int? akis_kullanici_id { get; set; }
            public bool mobil_uygulama_admin { get; set; }
        }

        public class Zimmet //Zimmetlerin bilgilerinin tutulduğu obje
        {
            public System.Int32 file_id { get; set; }
            public System.Int32 teslim_alan_id { get; set; }
            public System.Int32 teslim_alan_sube_id { get; set; }
            public System.String teslim_alan_adi { get; set; }
            public System.String teslim_alan_gorevi { get; set; }
            public System.String teslim_alan_departmani { get; set; }
            public System.Int32 teslim_eden_id { get; set; }
            public System.Int32 teslim_eden_sube_id { get; set; }
            public System.String teslim_eden_adi { get; set; }
            public System.String marka { get; set; }
            public System.String model { get; set; }
            public System.String cins { get; set; }
            public System.String aciklama { get; set; }
            public System.Int32 adet { get; set; }
            public System.DateTime? tarih { get; set; }
        }
    }
}