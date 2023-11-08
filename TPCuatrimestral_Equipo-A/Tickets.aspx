<%@ Page Title="Tickets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tickets.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.Tickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <h1 class="uk-heading-divider">Tickets</h1>
    <table class="uk-table uk-table-striped uk-table-hover">
        <thead>
        <tr>
            <th>#</th>
            <th>Tipo de Reclamo</th>
            <th>Prioridad</th>
            <th>Descripcion</th>
            <th>Usuario Asignado</th>
            <th>Cliente Afectado</th>
            <th>Fecha Inicial</th>
            <th>Fecha Fin</th>
            <th>Opciones</th>
        </tr>
        </thead>
    <tbody>
        <tr>
            <td>1</td>
            <td>Tecnico</td>
            <td>Alta</td>
            <td>El cliente no tiene servicio de internet en la casa</td>
            <td>1002</td>
            <td>Pepe</td>
            <td>05/11/2023</td>
            <td>01/12/2023</td>
            <td>
               <button class="uk-button uk-button-secondary" style="background-color: seagreen;border-radius: 14px;width: 60px;height: 25px;
               display: flex;justify-content: center;align-items: center;">
                   Vista
               </button>
            </td>
        </tr>
        <tr>
            <td>1</td>
            <td>Administrativo</td>
            <td>Media</td>
            <td>El cliente se queja por que le cobraron $10 extra en la factura del mes de marzo 2023</td>
            <td>1005</td>
            <td>Jose</td>
            <td>05/03/2023</td>
            <td>01/12/2023</td>
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
    <asp:GridView ID="TicketsGV" runat="server" CssClass="uk-table uk-table-divider"></asp:GridView>
    -->




</asp:Content>
