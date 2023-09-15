<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="RadioButton1.aspx.cs" Inherits="Pages_RadioButton1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server" >
        <input type="radio" id="ASC" name="order" value="ASC" checked runat="server"/>
        <label for="ASC">ASC</label>         &nbsp &nbsp
        <input type="radio" id="DESC" name="order" value="DESC" runat="server"/>
        <label for="DESC">DESC</label>      <br /> <br />
        <input type="button" value="Radio Button" name="btnRadio" id="btnRadio" runat="server" onserverclick="Click_Radio" />
        <br /> <br />
        <div id="div1" runat="server">

        </div>
        <div id="div2" runat="server">

        </div>
        <div id="div3" runat="server">

        </div>
    </form>
</asp:Content>

