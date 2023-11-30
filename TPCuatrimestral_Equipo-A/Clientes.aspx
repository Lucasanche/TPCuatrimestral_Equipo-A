<%@ Page EnableEventValidation="true" EnableViewState="true" Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 

     <link href="estilos/Tablas.css" rel="stylesheet" />
    <asp:ScriptManager runat="server"></asp:ScriptManager>


    <h1 class="uk-heading-divider">Clientes</h1>

    <div class="row-accion">
        <a class="boton-agregar" href="#modal-agregarCliente" uk-toggle>Agregar+</a>
        <div class="container-busqueda">
            <input type="text" class="input-busqueda" placeholder="Buscar por DNI...">
            <i class="lupita">
                <svg xmlns="http://www.w3.org/2000/svg" class="input-icon buscar-icono" viewBox="0 0 20 20" fill="currentColor">
                    <path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd"/>
                </svg>
            </i>
        </div>
        <a class="boton-filtros" href="#modal-center" uk-toggle>Otros Filtros</a>
    </div>

    <!--Inicio Modal-->
    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="modal-agregarCliente" class="uk-flex-top" uk-modal>
                <div class="uk-modal-dialog uk-modal-body uk-margin-auto-vertical">
                    <h3 class="uk-heading-divider">Agregar Clientes</h3>

                    <button class="uk-modal-close-default" type="button" uk-close></button>

                    <div class="uk-form-stacked">
                        <div class="uk-margin">
                            <label class="uk-form-label" for="form-stacked-text">Nombre:</label>
                            <div class="uk-form-controls">
                                <asp:TextBox ID="txtNombre1" runat="server" CssClass="uk-input" />
                            </div>
                        </div>

                        <div class="uk-margin">
                            <label class="uk-form-label" for="form-stacked-text">Apellido:</label>
                            <div class="uk-form-controls">
                                <asp:TextBox ID="txtApellido1" runat="server" CssClass="uk-input" />
                            </div>
                        </div>

                        <div class="uk-margin">
                            <label class="uk-form-label" for="form-stacked-text">DNI:</label>
                            <div class="uk-form-controls">
                                <asp:TextBox ID="txtDNI1" runat="server" CssClass="uk-input" />
                            </div>
                        </div>

                         <div class="uk-margin">
                             <label class="uk-form-label" for="form-stacked-text">Email:</label>
                             <div class="uk-form-controls">
                                 <asp:TextBox ID="txtEmail1" runat="server" CssClass="uk-input" />
                             </div>
                         </div>

                        <div class="uk-margin">
                            <label class="uk-form-label" for="form-stacked-text">Telefono:</label>
                            <div class="uk-form-controls">
                                <asp:TextBox ID="txtTelefono1" runat="server" CssClass="uk-input" />
                            </div>
                        </div>
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cliente" OnClick="btnGuardar_Click" CssClass="uk-button uk-button-secondary uk-width-1-1" UseSubmitBehavior="false"/>
                            <asp:Label Text="" runat="server" ID="txtAgregaCliente"/>
                    </div>
                </div>
            </div> 
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGuardar" />
        </Triggers>
       </asp:UpdatePanel>
    
    <!--Fin Modal con formulario-->


    <div id="modal-center" class="uk-flex-top" uk-modal>
    <div class="uk-modal-dialog uk-modal-body uk-margin-auto-vertical">

        <button class="uk-modal-close-default" type="button" uk-close></button>

        <p>La idea es ir teniendo mas campos de filtros</p>

    </div>
</div>

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
