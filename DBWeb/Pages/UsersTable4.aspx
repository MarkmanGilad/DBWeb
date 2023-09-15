<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UsersTable4.aspx.cs" Inherits="Pages_UsersTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/UsersTable.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h1>Using Helper</h1>
        <br />
        Enter Text to search name:
        <input type="text" name="filter" id="filter" />
        <br /> <br /> 
        <input type="button" value="Filter" name="btnFilter" id="btnFilter" runat="server" onserverclick="Click_Filter" />
        <br /> <br />

    </div>
    <div runat="server" id="tableDiv">

    </div>
    
</asp:Content>

