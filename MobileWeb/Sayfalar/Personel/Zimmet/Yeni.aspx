<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Yeni.aspx.cs" Inherits="MobileWeb.Sayfalar.Personel.Zimmet.Yeni" %>

<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <title>Zimmetler</title>
    <link href="https://fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i|Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../../../Content/styles/style.css" />
    <link rel="stylesheet" type="text/css" href="../../../Content/styles/framework.css" />
    <link rel="stylesheet" type="text/css" href="../../../Content/fonts/css/fontawesome-all.min.css" />
</head>
<body class="theme-light" data-highlight="blue2">
    <form id="form1" runat="server">
        <div id="Main">
            <div id="page-preloader">
                <div class="loader-main">
                    <div class="preload-spinner border-highlight"></div>
                </div>
            </div>
            <div id="page">
                <div class="page-content header-clear-medium">
                    <div id="divYetki" runat="server" visible="false">
                        <div class="content">
                            <h2 class="bolder">Yetkiniz bulunmuyor.</h2>
                            <div class="divider"></div>
                        </div>
                    </div>
                    <div id="divYeni" runat="server" visible="false">
                        <div class="content">
                            <h2 class="bolder">Yeni Zimmet Ekle</h2>
                            <div class="divider"></div>
                        </div>
                        <div class="input-style input-style-2 input-required">
                            <span>Teslim Alan ID</span>
                            <em>(required)</em>
                            <asp:TextBox ID="tb_teslim_alan_id" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-style input-style-2 input-required">
                            <span>Teslim Alan Sube ID</span>
                            <em>(required)</em>
                            <asp:TextBox ID="tb_teslim_alan_sube_id" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-style input-style-2 input-required">
                            <span>Teslim Alan Adı</span>
                            <em>(required)</em>
                            <asp:TextBox ID="tb_teslim_alan_adi" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-style input-style-2 input-required">
                            <span>Teslim Alan Görevi</span>
                            <em>(required)</em>
                            <asp:TextBox ID="tb_teslim_alan_gorevi" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-style input-style-2 input-required">
                            <span>Teslim Alan Departmanı</span>
                            <em>(required)</em>
                            <asp:TextBox ID="tb_teslim_alan_departmani" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-style input-style-2 input-required">
                            <span>Marka</span>
                            <em>(required)</em>
                            <asp:TextBox ID="tb_marka" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-style input-style-2 input-required">
                            <span>Model</span>
                            <em>(required)</em>
                            <asp:TextBox ID="tb_model" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-style input-style-2 input-required">
                            <span>Cins</span>
                            <em>(required)</em>
                            <asp:TextBox ID="tb_cins" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-style input-style-2 input-required">
                            <span>Açıklama</span>
                            <em>(required)</em>
                            <asp:TextBox ID="tb_aciklama" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-style input-style-2 input-required">
                            <span>Adet</span>
                            <em>(required)</em>
                            <asp:TextBox ID="tb_adet" runat="server"></asp:TextBox>
                        </div>
                        <div class="content">
                            <a href="#" class="button button-s button-full button-round-large shadow-medium bg-highlight" id="lnkKaydet" runat="server" onserverclick="btnKaydet_ServerClick">Kaydet</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript" src="../../../Content/scripts/jquery.js"></script>
    <script type="text/javascript" src="../../../Content/scripts/plugins.js"></script>
    <script type="text/javascript" src="../../../Content/scripts/custom.js"></script>
</body>
</html>
