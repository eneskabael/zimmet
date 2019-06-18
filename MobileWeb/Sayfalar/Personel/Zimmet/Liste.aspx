<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Liste.aspx.cs" Inherits="MobileWeb.Sayfalar.Personel.Zimmet.Liste" %>

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
                    <div class="content accordion-style-2">
                        <div id="yeniZimmet" runat="server">
                            <h2 class="ultrabold font-700" onclick="window.open('/Sayfalar/Personel/Zimmet/Yeni.aspx')">Yeni Zimmet</h2>
                            <br />
                        </div>

                        <h2 class="ultrabold font-700">Zimmet Listesi</h2>


                        <%foreach (var zimmet in oZimmet)
                            {%>
                        <a data-accordion="accordion-content-<%=zimmet.file_id %>" href="#" class="accordion-toggle-first">
                            <i class="accordion-icon-left far fa-file color-black"></i>
                            <%=zimmet.marka%>
                            <i class="accordion-icon-right fa fa-plus"></i>
                            <em class="accordion-icon-right" style="margin-right: 15px; width: 50px !important;"><%=zimmet.adet%> ADET</em>
                        </a>

                        <div id="accordion-content-<%=zimmet.file_id %>" class="accordion-content bottom-10">
                            <p style="margin-bottom: 0px !important;">Model: <%=zimmet.model %></p>
                            <p style="margin-bottom: 0px !important;">Açıklama: <%=zimmet.aciklama %></p>
                            <p style="margin-bottom: 0px !important;">Teslim Eden: <%=zimmet.teslim_eden_adi %></p>
                            <p style="margin-bottom: 0px !important;">Teslim Alan: <%=zimmet.teslim_alan_adi %></p>
                            <p style="margin-bottom: 0px !important;">Tarih:  <%=zimmet.tarih %></p>
                            <br />
                        </div>
                        <%}%>
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
