<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Pages_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Register - InsertCommand</h1>
    <table align="center">
        <tr>
            <td>
                User Name:
            </td>
            <td>
                <input type="text" name="userName" id="userName"/>
            </td>
            <td>
                <div id="userNameAlert" class="alert"></div>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <input type="password" name="password" id="password" />
            </td>
            <td>
                <div id="passwordAlert" class="alert"></div>
            </td>
        </tr>
        <tr>
            <td>Confirm Password</td>
            <td>
                <input type="password" name="confirmPassword" id="confirmPassword"/>
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
                <input type="text" name="firstName" id="firstName"/>
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
                <input type="text" name="lastName" id="lastName"/>
            </td>
            <td>
                <div></div>
            </td>
        </tr>
        <tr>
            <td>תאריך לידה</td>
            <td>
                <input type="date" name="date" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                City:
            </td>
            <td>
                <input type="text" name="city" id="city"/>
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
                <input type="submit" name="submit" />
            </td>
            <td>
                <input type="reset" name="reset" />
            </td>
            <td></td>
        </tr>
        </table>
    <div id="msgBox" runat="server" style="color:red"></div>
</asp:Content>

