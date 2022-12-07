<%-- BeginRegion Page setup --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Grid_Filter_OneColumnOnly_Default" %>
<%@ Register Assembly="DevExpress.Web.v15.1" Namespace="DevExpress.Web" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v15.1" Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%-- EndRegion --%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Make the header filter active for one column only</title>
</head>
<body>
    <form id="form1" runat="server">
		<dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="AccessDataSource1" KeyFieldName="CategoryID" OnDataBinding="ASPxGridView1_DataBinding" OnLoad="ASPxGridView1_Load">
			<Settings ShowHeaderFilterButton="True" />
			<Columns>
				<dxwgv:GridViewDataTextColumn FieldName="CategoryID" ReadOnly="True" VisibleIndex="0">
					<EditFormSettings Visible="False" />
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="1">
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataTextColumn FieldName="Description" VisibleIndex="2">
				</dxwgv:GridViewDataTextColumn>
			</Columns>
		</dxwgv:ASPxGridView>
		<asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
			SelectCommand="SELECT * FROM [Categories]"></asp:AccessDataSource>

    </form>
</body>
</html>
