<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <link href="estilos/Tablas.css" rel="stylesheet" />


    <h1 class="uk-heading-divider">Clientes</h1>

    <div class="row-accion">
        <button class="boton-agregar">Agregar +</button>
        <div class="container-busqueda">
            <input type="text" class="input-busqueda" placeholder="Buscar por DNI...">
            <i class="lupita">
                <svg xmlns="http://www.w3.org/2000/svg" class="input-icon" viewBox="0 0 20 20" fill="currentColor">
                    <path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd"/>
                </svg>
            </i>
        </div>
        <a class="boton-filtros" href="#modal-center" uk-toggle>Otros Filtros</a>
    </div>

    <div id="modal-center" class="uk-flex-top" uk-modal>
    <div class="uk-modal-dialog uk-modal-body uk-margin-auto-vertical">

        <button class="uk-modal-close-default" type="button" uk-close></button>

        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>

    </div>
</div>



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
           <button class="ver-clientes">
             <img class="imagen-primaria" src="imagenes/ojo.svg" style="width: 2.7vh; height: 1.5vh;" alt="">
             <img class="imagen-secundaria" src="imagenes/abrir-documento.svg" alt="">
             <span class="texto-button" style="
             position: relative;
             left: 30%;">Ver</span>
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
