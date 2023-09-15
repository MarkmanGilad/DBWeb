<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login1.aspx.cs" Inherits="Pages_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../JS/Validate.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Using ExecuteScalar</h1>
    <br /> <br />
        <div>
            user name:
            <input type="text" id="userName" name="userName"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Password:
            <input type="password" id="password" name="password" />
            <br /> <br />
            <input type="submit" id="submit" name="submit" onclick="return Validate();" />
        </div>
        <br />
        <div runat="server" id="message">
            
        </div>
        <div runat="server" id="message1">

        </div>
</asp:Content>

