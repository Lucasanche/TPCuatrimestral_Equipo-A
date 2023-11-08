<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="uk-heading-divider">Clientes</h1>
<table class="uk-table uk-table-striped uk-table-hover">
    <thead>
    <tr>
        <th>#</th>
        <th>DNI</th>
        <th>Nombre</th>
        <th>Apellido</th>
        <th>Email</th>
        <th>Telefono</th>
        <th>Fecha de Alta</th>
        <th>Fecha de Baja</th>
        <th>Opciones</th>
    </tr>
    </thead>
<tbody>
    <tr>
        <td>1</td>
        <td>40404502</td>
        <td>Marcos</td>
        <td>Ramirez</td>
        <td>marcosRamirez2222@gmail.com</td>
        <td>114751415</td>
        <td>05/12/2021</td>
        <td></td>
        <td>
           <button class="uk-button uk-button-secondary" style="background-color: seagreen;border-radius: 14px;width: 60px;height: 25px;
           display: flex;justify-content: center;align-items: center;">
               Vista
           </button>
        </td>
    </tr>
    <tr>
        <td>1</td>
        <td>3154502</td>
        <td>Gabriel</td>
        <td>Lopez Figueroa</td>
        <td>asdjkashdkjasd@gmail.com</td>
        <td>114465115</td>
        <td>01/05/2021</td>
        <td></td>
        <td>
           <button class="uk-button uk-button-secondary" style="background-color: seagreen;border-radius: 14px;width: 60px;height: 25px;
           display: flex;justify-content: center;align-items: center;">
               Vista
           </button>
        </td>
    </tr>
</tbody>
<tfoot>
    <tr>
        <td></td>
    </tr>
</tfoot>
</table>

    <!--
    <div class="uk-container">
        <asp:GridView ID="ClientesGV" runat="server" CssClass="uk-table uk-table-divider"></asp:GridView>
    </div>
    -->


</asp:Content>
