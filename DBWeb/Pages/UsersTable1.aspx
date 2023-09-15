<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UsersTable1.aspx.cs" Inherits="Pages_UsersTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/UsersTable.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <br />
        <label for="Columns">Sort by Column:</label> &nbsp &nbsp 
         <select id="Columns" runat="server">
            <option value="userId">userId</option>
            <option value="firstName">firstName</option>
            <option value="lastName">lastName</option>
            <option value="userName">userName</option>
            <option value="admin">Admin</option>
            <option value="birthday">Birthday</option>
            <option value="city">City</option>
        </select>           &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
        <input type="radio" id="ASC" name="order" value="ASC" checked/>
        <label for="ASC">ASC</label>         &nbsp &nbsp
        <input type="radio" id="DESC" name="order" value="DESC" />
        <label for="DESC">DESC</label>      <br /> <br />
        <input type="button" value="Sort" name="btnSort" id="btnSort" runat="server" onserverclick="Click_Sort" />
        <br /> <br />
    </div>
    <div runat="server" id="tableDiv">
    </div>
</asp:Content>

