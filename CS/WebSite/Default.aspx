<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to update a hyperlink depending on inserted ASPxGridView row values</title>
    <script type="text/javascript">
        function SetLink(s, e) {
            hl.SetNavigateUrl("Item.aspx?ID=" + s.cpID + "&Item=" + s.cpText);
            hl.SetText(s.cpText);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxHyperLink ID="hl" ClientInstanceName="hl" runat="server"></dx:ASPxHyperLink>
        <dx:ASPxGridView ID="gv" ClientInstanceName="gv" runat="server" AutoGenerateColumns="False"
            KeyFieldName="ID" OnRowInserting="gv_RowInserting">
            <ClientSideEvents EndCallback="SetLink" />
            <Columns>
                <dx:GridViewCommandColumn VisibleIndex="0" ShowNewButton="True"/>
                <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True"
                    VisibleIndex="1">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Item" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
    </form>
</body>
</html>
