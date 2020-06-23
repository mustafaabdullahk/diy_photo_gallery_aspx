<%@ Page Language="C#" AutoEventWireup="true" CodeFile="galeri.aspx.cs" Inherits="galeri" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Galeri</title>
    <link href="Css/prettyPhoto.css" rel="stylesheet" type="text/css" />
    <script src="Js/jquery-1.2.6.pack.js" type="text/javascript"></script>
    <script src="Js/jquery.prettyPhoto.js" type="text/javascript"></script>
    <script>
      $(document).ready(function(){
		    $("a[rel^='slayt']").prettyPhoto({
			    animationSpeed: 'normal',
			    padding: 40,
			    opacity: 0.5, 
			    showTitle: false,
			    allowresize: true,
			    counter_separator_label: '-'
		    });
	    });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:600px;">
      <asp:Repeater ID="Repeater1" runat="server">
      <ItemTemplate>
        <div style="background-color:#ccc; padding:2px 5px;"><%# Eval("AlbumAdi") %></div>
        <div style="background-color:#eee; margin:0 0 10px 0; padding:5px;">
          <%# resimleri_al(Eval("Resimler").ToString(), Eval("Id").ToString()) %>
        </div>
      </ItemTemplate>
      </asp:Repeater>
    </div>
    </form>
<script type="text/javascript">var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));</script><script type="text/javascript">var pageTracker = _gat._getTracker("UA-5427731-1");pageTracker._trackPageview();</script>
</body>
</html>
