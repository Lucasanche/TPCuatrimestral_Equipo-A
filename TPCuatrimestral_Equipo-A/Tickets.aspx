<%@ Page Title="Tickets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tickets.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.Tickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="estilos/Tablas.css" rel="stylesheet" />
    <h1 class="uk-heading-divider">Tickets</h1>
    <div class="row-accion">
        <a class="boton-agregar" uk-toggle>Agregar+</a>
        <div class="container-busqueda">
            <input type="text" class="input-busqueda" placeholder="Buscar por ID...">
            <i class="lupita">
                <svg xmlns="http://www.w3.org/2000/svg" class="input-icon" viewBox="0 0 20 20" fill="currentColor">
                    <path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd" />
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

    <%-- <table class="uk-table uk-table-striped uk-table-hover">
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
            <td>2</td>
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

    --%>

    <asp:GridView ID="TicketsGV" CssClass="uk-table uk-table-striped uk-table-hover" runat="server" OnRowCommand="TicketsGV_RowCommand" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="#" />
        <asp:BoundField DataField="Tipo.Nombre" HeaderText="Tipo" />
        <asp:BoundField DataField="Prioridad.Nombre" HeaderText="Prioridad" />
        <asp:BoundField DataField="DescripcionInicial" HeaderText="Descripcion Inicial" />
        <asp:BoundField DataField="DescripcionCierre" HeaderText="Descripcion Cierre" />
        <asp:BoundField DataField="LegajoUsuario" HeaderText="Legajo Usuario" />
        <asp:BoundField DataField="ClienteAfectado.DNI" HeaderText="Cliente Afectado" />
        <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha De Creacion" />
        <asp:BoundField DataField="Estado.Nombre" HeaderText="Estado" />
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
