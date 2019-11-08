<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="CustomerApi2Client.Insert" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div style="margin-bottom: 5px;"><span style="float: left; width: 50px; text-align: left;">Name:</span><asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
        <div><span style="float: left; width: 50px; text-align: left;">Age :</span><asp:TextBox ID="txtAge" runat="server"></asp:TextBox></div>
        <br />
        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="InsertIntoTable"/>
        <hr/>
        <asp:GridView ID="gvSimpleTable" runat="server" AutoGenerateColumns="false" HeaderStyle-HorizontalAlign="Left">
            <Columns>
                <%--<asp:BoundField ItemStyle-Width="150px" DataField="CustomerID" HeaderText="CustomerID"/>--%>
                <asp:BoundField ItemStyle-Width="150px" DataField="Name" HeaderText="Name"/>
                <asp:BoundField ItemStyle-Width="150px" DataField="Age" HeaderText="Age"/>
            </Columns>
        </asp:GridView>
</asp:Content>
