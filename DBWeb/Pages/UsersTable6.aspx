﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UsersTable6.aspx.cs" Inherits="Pages_UsersTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/UsersTable.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Using adapter, UpdateCommand, DeleteCommand, InsertCommand</h1>
    <div>
        <br />
        Enter Text to search name:
        <input type="text" name="filter" id="filter" />
        <br /> <br /> 
        <input type="button" value="Filter" name="btnFilter1" id="btnFilter1" runat="server" onserverclick="Click_Filter1" />
        &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
        <input type="button" value="Delete" name="btnDelete" id="Button1" runat="server" onserverclick="Delete" />
        &nbsp &nbsp &nbsp &nbsp
        <input type="button" value="Edit" name="btnEdit" id="btnEdit" runat="server"  onserverclick="Edit"/> 
        &nbsp &nbsp &nbsp &nbsp
        <input type="button" value="Add" name="btnAdd" id="btnAdd" runat="server"  onserverclick="Add"/> 
       
        <br /> <br />
        
    </div>
    <div runat="server" id="tableDiv">

    </div>
    
    <div runat="server" id="message">
        
    </div>
    <div runat="server" id="message1">

    </div>
    
</asp:Content>

