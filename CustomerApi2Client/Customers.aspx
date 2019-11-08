<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="CustomerApi2Client.Customers" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            Name:
<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="Search"/>
<hr/>
<asp:GridView ID="gvSimpleTable" runat="server" AutoGenerateColumns="false">
    <Columns>
        <%--<asp:BoundField ItemStyle-Width="150px" DataField="CustomerID" HeaderText="CustomerID"/>--%>
        <asp:BoundField ItemStyle-Width="150px" DataField="Name" HeaderText="Name"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="Age" HeaderText="Age"/>
    </Columns>
</asp:GridView>
        </div>
</asp:Content>
