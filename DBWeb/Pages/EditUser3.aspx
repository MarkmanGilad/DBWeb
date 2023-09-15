<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditUser3.aspx.cs" Inherits="Pages_EditUser3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h1 style="text-align:center">Edit User - UpdateCommand</h1>
    <table align="center">
        <tr>
            <td>
                User Name:
            </td>
            <td>
                <input type="text" name="userName" id="userName" runat="server"/>
            </td>
            <td>
                <div id="userNameAlert" class="alert"></div>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <input type="text" name="password" id="password" runat="server"/>
            </td>
            <td>
                <div id="passwordAlert" class="alert"></div>
            </td>
        </tr>
        <tr>
            <td>Confirm Password</td>
            <td>
                <input type="text" name="confirmPassword" id="confirmPassword"/>
            </td>
            <td>
                <div id="passwordConfirmAlert" class="alert"></div>
            </td>
        </tr>
        <tr>
            <td>
                first Name:
            </td>
            <td>
                <input type="text" name="firstName" id="firstName" runat="server"/>
            </td>
            <td>
                <div></div>
            </td>
        </tr>
        <tr>
            <td>
                Last Name:
            </td>
            <td>
                <input type="text" name="lastName" id="lastName" runat="server"/>
            </td>
            <td>
                <div></div>
            </td>
        </tr>
        <tr>
            <td>תאריך לידה</td>
            <td>
                <input type="date" name="date" id="date" runat="server" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                City:
            </td>
            <td>
                <input type="text" name="city" id="city" runat="server"/>
            </td>
            <td>
                <div></div>
            </td>
        </tr>
        <tr>
            <td>
                Admin:
            </td>
            <td>
                <input type="checkbox" name="Admin" id="Admin" runat="server"/>
            </td>
            <td>
                <div></div>
            </td>
        </tr>
        <tr>
            <td>E-Mail</td>
            <td>
                <input type="text" name="email" id="email" />
            </td>
            <td >
                <div id="emailAlert" class="alert"></div>
            </td>
            </tr>
        <tr>
            <td>Gender</td>
            <td>
                <input type="radio" name="gender" value="male" checked> Male
                <input type="radio" name="gender" value="female"> Female
            </td>
            <td></td>
        </tr>

        <tr>
            <td>
                <input type="button" name="Update" id="Update" runat="server" value ="Update" onserverclick ="UpdateUser" />
            </td>
            <td>
                <input type="reset" name="reset" />
            </td>
            <td></td>
        </tr>
        </table>

    <div runat="server" id="message"></div>
</asp:Content>

