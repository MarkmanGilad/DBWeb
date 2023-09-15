<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteUpdate.aspx.cs" Inherits="Pages_DeleteUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/UsersTable.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Edit multiple Admin Using ExecuteNonQuery</h1>
    <div>
        <table>
            <tr>
                <td>Enter Text to search name:</td>
                <td><input type="text" name="filter" id="filter" runat="server"/></td>
                <td><input type="button" value="Filter" name="btnFilter1" id="btnFilter1" runat="server" onserverclick="Click_Filter" /></td>
                 <td></td>
            </tr>
            <tr>
                <td>Enter id to delete</td>
                <td><input type="text" name="delete" id="delete" runat="server" /></td>
                <td><input type="button" value="Delete" name="btnDelete" id="Button1" runat="server" onserverclick="Delete" /></td>
            </tr>
            <tr>
                <td> Enter id to edit</td>
                <td> <input type="text" name="edit" id="edit" runat="server" /></td>
                <td> <input type="button" value="Edit" name="btnEdit" id="btnEdit" runat="server" onserverclick="Edit" /></td>

            </tr>
            <tr>
                <td>Enter id to change Admin</td>
                <td><input type="text" name="change" id="change" runat="server" /></td>
                <td><input type="button" value="Change Admin" name="btnUser" id="btnUser" runat="server" onserverclick="ChangeAdmin" /></td>
            </tr>
             <tr>
                <td>Click to add user</td>
                <td><input type="button" value="Add user" name="btnAdd" id="btnAdd" runat="server" onserverclick="Add" /></td>
                <td></td>

            </tr>
        </table>
        
        <br />
        <br />

    </div>
    <div runat="server" id="tableDiv">
    </div>

    <div runat="server" id="msg">
    </div>
    <div runat="server" id="message1">
    </div>
</asp:Content>

