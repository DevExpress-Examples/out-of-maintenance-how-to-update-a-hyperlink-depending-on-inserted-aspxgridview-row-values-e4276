<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="Item" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to update a hyperlink depending on inserted ASPxGridView row values</title>
</head>
<body>
    <form id="form1" runat="server">
        <%= String.Format("New row ID value is \"{0}\". New row Item value is \"{1}\"",
            System.Web.HttpContext.Current.Request.QueryString["ID"],
            System.Web.HttpContext.Current.Request.QueryString["Item"]) %>
    </form>
</body>
</html>
