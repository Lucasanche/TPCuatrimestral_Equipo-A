<%@ Page EnableEventValidation="true" Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 

     <link href="estilos/Tablas.css" rel="stylesheet" />


    <h1 class="uk-heading-divider">Clientes</h1>

    <div class="row-accion">
        <a class="boton-agregar" href="#modal-center-Add" uk-toggle>Agregar+</a>
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

    <!--Inicio Modal-->
    <div id="modal-center-Add" class="uk-flex-top" uk-modal>
        <div class="uk-modal-dialog uk-modal-body uk-margin-auto-vertical">
            <h3 class="uk-heading-divider">Agregar Clientes</h3>

            <button class="uk-modal-close-default" type="button" uk-close></button>

            <div class="uk-form-stacked">
                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Nombre:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="uk-input" />
                    </div>
                </div>

                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Apellido:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="uk-input" />
                    </div>
                </div>

                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">DNI:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="txtDNI" runat="server" CssClass="uk-input" />
                    </div>
                </div>

                 <div class="uk-margin">
                     <label class="uk-form-label" for="form-stacked-text">Email:</label>
                     <div class="uk-form-controls">
                         <asp:TextBox ID="txtEmail" runat="server" CssClass="uk-input" />
                     </div>
                 </div>

                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Telefono:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="uk-input" />
                    </div>
                </div>
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Usuario" OnClick="btnGuardar_Click" CssClass="uk-button uk-button-secondary uk-width-1-1" AutoPostBack="false" UseSubmitBehavior="False"/>
                    <asp:Label Text="" runat="server" ID="txtConfirma"/>
            </div>
        </div>
    </div>
    <!--Fin Modal con formulario-->


    <div id="modal-center" class="uk-flex-top" uk-modal>
    <div class="uk-modal-dialog uk-modal-body uk-margin-auto-vertical">

        <button class="uk-modal-close-default" type="button" uk-close></button>

        <p>La idea es ir teniendo mas campos de filtros</p>

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
             <img class="imagen-primaria" src="imagenes/ojo.svg" style="width: 2.7vh; height: 2.5vh;" alt="">
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
            asd
        </td>
    </tr>
</tbody>
<tfoot>
    <tr>
        <td></td>
    </tr>
</tfoot>
</table>

    <asp:GridView ID="ClientesGV" CssClass="uk-table uk-table-striped uk-table-hover" runat="server" AutoGenerateColumns="False" OnRowCommand="ClientesGV_RowCommand">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="#" />
            <asp:BoundField DataField="DNI" HeaderText="DNI" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Telefono1" HeaderText="Telefono" />
            <asp:BoundField DataField="FechaAlta" HeaderText="Fecha de Alta" />
            <asp:BoundField DataField="FechaBaja" HeaderText="Fecha de Baja" />
            <asp:TemplateField HeaderText="Opciones">
                <ItemTemplate>
                    <asp:Button runat="server" CommandName="VerDetalles" CommandArgument='<%# Eval("ID") %>' Text="Ver Detalles" CssClass="uk-button uk-button-secondary" PostBackUrl='<%# $"Contacto.aspx?ID={Eval("ID")}" %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>



</asp:Content>
