<%@ Page Language="C#" MasterPageFile="~/Site.Master" autoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="CustomerApi2Client.Update" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

         <div>            Name:
<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="DisplayGrid"/></div>
         <hr />
        <div style="margin-bottom: 5px;"><span style="float: left; width: 100px; text-align: left;">CustomerID:</span><asp:TextBox ID="txtCustomerID" runat="server"></asp:TextBox></div>
         <div style="margin-bottom: 5px;"><span style="float: left; width: 100px; text-align: left;">Name:</span><asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
        <div><span style="float: left; width: 100px; text-align: left;">Age :</span><asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="UpdateTable"/>
        </div>
         
         <br />

        <hr/>
        <asp:GridView ID="gvSimpleTable" runat="server" AutoGenerateColumns="false" HeaderStyle-HorizontalAlign="Left">
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" DataField="CustomerID" HeaderText="CustomerID" ReadOnly="true"/>
                <asp:BoundField ItemStyle-Width="150px" DataField="Name" HeaderText="Name"/>
                <asp:BoundField ItemStyle-Width="150px" DataField="Age" HeaderText="Age"/>
            </Columns>
        </asp:GridView>
</asp:Content>