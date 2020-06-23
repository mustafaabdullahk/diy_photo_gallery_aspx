<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Slayt Oluþtur</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> 
        <asp:Button ID="btnkntrl" runat="server" Height="20px" Text="Button" 
            Width="55px" onclick="btnkntrl_Click" />
        <asp:Panel ID="Panel2" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Image ID="Image1" runat="server" />
        </asp:Panel>
      </div>
       
	<asp:Panel ID="Panel1" runat="server">
        <asp:DropDownList ID="adet_sec" runat="server" AutoPostBack="true" 
            Width="100px">
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
        </asp:DropDownList><asp:Button ID="Button1" runat="server" Text="Upload Et" 
            OnClick="Button1_Click" Height="22px" />
        <asp:Panel ID="resimler" runat="server" Height="16px" Width="188px">
            <br />
            <br />
        </asp:Panel>
    </asp:Panel>
	<br/><br/>
    </form>
<script type="text/javascript">var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));</script><script type="text/javascript">var pageTracker = _gat._getTracker("UA-5427731-1");pageTracker._trackPageview();</script>
</body>
</html>