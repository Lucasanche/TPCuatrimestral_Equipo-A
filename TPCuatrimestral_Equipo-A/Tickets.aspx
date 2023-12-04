<%@ Page Title="Tickets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tickets.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.Tickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="estilos/Tablas.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% if (true)
        { %>
    <%
        int a = 0;
    %>
    <% } %>
    <h1 class="uk-heading-divider">Tickets</h1>

    <div class="row-accion">

        <a class="boton-agregar" href="CrearTicket.aspx" uk-toggle>Agregar Ticket</a>

        <%--        <div class="container-busqueda">
            <input type="text" class="input-busqueda" placeholder="Buscar por DNI...">
            <i class="lupita">
                <svg xmlns="http://www.w3.org/2000/svg" class="input-icon" viewBox="0 0 20 20" fill="currentColor">
                    <path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd" />
                </svg>
            </i>
        </div>--%>
    </div>

    <div id="modal-center" class="uk-flex-top" uk-modal>
        <div class="uk-modal-dialog uk-modal-body uk-margin-auto-vertical">

            <button class="uk-modal-close-default" type="button" uk-close></button>

            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>

        </div>
    </div>

    <asp:GridView ID="TicketsGV" CssClass="uk-table uk-table-striped uk-table-hover" runat="server" OnRowCommand="TicketsGV_RowCommand" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="#" />
            <asp:BoundField DataField="Tipo.Nombre" HeaderText="Tipo" />
            <asp:BoundField DataField="Prioridad.Nombre" HeaderText="Prioridad" />
            <asp:BoundField DataField="DescripcionInicial" HeaderText="Descripcion Inicial" />
            <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario Responsable" />
            <asp:BoundField DataField="ClienteAfectado.DNI" HeaderText="DNI Cliente Afectado" />
            <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha De Creacion" />
            <asp:BoundField DataField="Estado.Nombre" HeaderText="Estado" />
            <asp:BoundField DataField="DescripcionCierre" HeaderText="Descripcion Cierre" />
            <asp:BoundField DataField="FechaCierre" HeaderText="Fecha de cierre" />
            <asp:TemplateField HeaderText="Opciones">
                <ItemTemplate>
                    <div class="container-detalles">
                        <asp:LinkButton runat="server" CommandName="VerDetalles" CommandArgument='<%# Eval("ID") %>' CssClass="ver-clientes">
                        <img class="imagen-primaria" src="imagenes/ojo.svg" style="width: 2.7vh; height: 1.8vh;" alt="" />
                        <img class="imagen-secundaria" src="imagenes/abrir-documento.svg" alt="" />
                        <span class="texto-button" style="margin-right: -25px;">Ver</span>
                        </asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>



</asp:Content>
