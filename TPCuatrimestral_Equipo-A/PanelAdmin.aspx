<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelAdmin.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.PanelAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
    .warning {
        color:red;
    }
    .menu-navegacion {
        display: flex;
        position: sticky;
        top: 0;
        background-color: #f1f1f1;
        padding: 10px;
        z-index: 100;
        justify-content: center;
    }

    .menu-navegacion a {
        padding: 8px 16px;
        text-decoration: none;
        color: black;
        margin: 0 10px;
    }

    .menu-navegacion a:hover {
        background-color: #ddd;
        color: black;
    }
</style>


<div class="menu-navegacion">
    <a href="#seccion-alta">ALTA</a>
    <a href="#seccion-editar">EDITAR</a>
    <a href="#seccion-eliminar">ELIMINAR</a>
</div>


<div class="uk-section uk-section-muted" id="seccion-alta">
    <div class="col-2"></div>
    <div class="container">
        <form novalidate>
            <h3 class="uk-heading-divider">Agregar Usuario</h3>

            <button class="uk-modal-close-default" type="button" uk-close></button>

            <div class="uk-form-stacked">
                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Nombre:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="uk-input" />
                        <asp:Label Text="" ID="txtValidarNombre" runat="server" CssClass="warning"/>
                    </div>
                </div>

                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Apellido:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="uk-input" />
                        <asp:Label Text="" ID="txtValidarApellido" runat="server" CssClass="warning" />
                    </div>
                </div>

                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">DNI:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="txtDNI" runat="server" CssClass="uk-input" />
                        <asp:Label Text="" ID="txtValidarDNI" runat="server" CssClass="warning" />
                    </div>
                </div>

                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Email:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="uk-input" />
                        <asp:Label Text="" ID="txtValidarEmail" runat="server" CssClass="warning" />
                    </div>
                </div>

                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Telefono:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="uk-input" />
                        <asp:Label Text="" ID="txtValidarTelefono" runat="server" CssClass="warning" />
                    </div>
                </div>
                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Fecha de nacimiento:</label>
                    <div class="uk-form-controls">
                        <asp:Calendar ID="CalendarioFechaNacimiento" runat="server"></asp:Calendar>
                        <asp:Label Text="" ID="txtValidarFechaNacimiento" runat="server" CssClass="warning" />
                    </div>
                </div>
            
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cliente" OnClick="btn_GuardarClick" CssClass="uk-button uk-button-secondary uk-width-1-1" UseSubmitBehavior="false" />
                <asp:Label Text="" runat="server" ID="txtAgregaCliente" CssClass="warning"/>
            </div>
        </form>
    </div>

    <br />

    <div class="col-2"></div>
    <div class="container">
        <form novalidate>
            <h3 class="uk-heading-divider">Agregar Tipo Ticket</h3>

            <button class="uk-modal-close-default" type="button" uk-close></button>

            <div class="uk-form-stacked">
                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Nombre:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="txtNombreIncidencia" runat="server" CssClass="uk-input" />
                        <asp:Label Text="" ID="txtValidarNombreIncidencia" runat="server" CssClass="warning"/>
                    </div>
                </div>

                <asp:Button ID="Button1" runat="server" Text="Guardar Cliente" OnClick="btn_GuardarClick" CssClass="uk-button uk-button-secondary uk-width-1-1" UseSubmitBehavior="false" />
                <asp:Label Text="" runat="server" ID="Label1" CssClass="warning"/>

            </div>
        </form>
    </div>
</div>


<div class="uk-section uk-section-secondary uk-light" id="seccion-editar">
    <h3 class="uk-heading-divider">Editar Usuario</h3>

    <div class="col-2"></div>
    <div class="container">
        <div class="uk-margin"> 
            <div class="col-12">
                <asp:TextBox runat="server" ID="txtLegajoUsuarioEditar" placeholder="Buscar Usuario por Legajo..." CssClass="uk-input" />
                <asp:LinkButton ID="BuscarUsuario" runat="server" OnClick="btnBuscarUsuario_Click">
                        <i class="lupita">
                            <svg xmlns="http://www.w3.org/2000/svg" class="input-icon" viewBox="0 0 20 20" fill="currentColor" width="20" height="20">
                            <path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd" />
                            </svg>
                        </i>
                </asp:LinkButton>
            </div>
        </div>
    </div>

    <div class="col-2"></div>
    <div class="container">
        <form novalidate>

            <div class="uk-form-stacked">
                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Nombre:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="uk-input" />
                        <asp:Label Text="" ID="txtValidarNombreEdit" runat="server" CssClass="warning"/>
                    </div>
                </div>

                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Apellido:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="uk-input" />
                        <asp:Label Text="" ID="txtValidarApellidoEdit" runat="server" CssClass="warning" />
                    </div>
                </div>

                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">DNI:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="uk-input" />
                        <asp:Label Text="" ID="txtValidarDNIEdit" runat="server" CssClass="warning" />
                    </div>
                </div>

                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Email:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="uk-input" />
                        <asp:Label Text="" ID="txtValidarEmailEdit" runat="server" CssClass="warning" />
                    </div>
                </div>

                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Telefono:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="uk-input" />
                        <asp:Label Text="" ID="txtValidarTelefonoEdit" runat="server" CssClass="warning" />
                    </div>
                </div>
                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Fecha de nacimiento:</label>
                    <div class="uk-form-controls">
                        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                        <asp:Label Text="" ID="txtValidarFechaNacimientoEdit" runat="server" CssClass="warning" />
                    </div>
                </div>
    
                <asp:Button ID="Button2" runat="server" Text="Guardar Cliente" OnClick="btn_GuardarClick" CssClass="uk-button uk-button-secondary uk-width-1-1" UseSubmitBehavior="false" />
                <asp:Label Text="" runat="server" ID="txtEditaCliente" CssClass="warning"/>
            </div>
        </form>
    </div>


    <div class="uk-margin">
        <h3 class="uk-heading-divider">Editar Tipo Ticket</h3>
        <form novalidate>
            <label class="uk-form-label">Seleccione Tipo a Editar:</label>
            <div class="dropdown">
                <asp:DropDownList ID="ddlEditarTipoTicket" runat="server" CssClass="btn btn-secondary dropdown-toggle" Style="text-align: left;" form-check-input required></asp:DropDownList>
            </div>

            <div class="uk-margin">
                <label class="uk-form-label" for="form-stacked-text">Nuevo Nombre de Tipo de Ticket:</label>
                <div class="uk-form-controls">
                    <asp:TextBox runat="server" CssClass="uk-input" ID="txtNombreTipoTicketEditar" />
                </div>
            </div>

            <asp:Button Text="Editar Tipo de Ticket" runat="server" CssClass="uk-button uk-button-primary uk-width-1-1" />
        </form>
    </div>
</div>

<div class="uk-section uk-section-primary uk-light" id="seccion-eliminar">
    <h3 class="uk-heading-divider">Eliminar Usuario</h3>
    <div class="uk-margin"> 
    <div class="col-5">
        <asp:TextBox runat="server" ID="txtLegajoEliminarUsuario" placeholder="Buscar Usuario por Legajo..." CssClass="uk-input" />
        <asp:LinkButton ID="BuscarUsuario2" runat="server" OnClick="btnBuscarUsuario_Click">
                <i class="lupita">
                    <svg xmlns="http://www.w3.org/2000/svg" class="input-icon" viewBox="0 0 20 20" fill="currentColor" width="20" height="20">
                    <path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd" />
                    </svg>
                </i>
        </asp:LinkButton>
    </div>
    <div class="uk-margin"> 
        <asp:Button Text="Eliminar Usuario Seleccionado" runat="server" CssClass="uk-button uk-button-danger uk-button-large" />
    </div>

</div>
    <h3 class="uk-heading-divider">Eliminar Tipo Ticket</h3>
    <label class="uk-form-label" for="form-stacked-text">Seleccione Tipo:</label>
    <div class="uk-margin">
        <asp:DropDownList ID="ddlEliminarTipoTicket" runat="server" CssClass="btn btn-secondary dropdown-toggle" Style="text-align: left;" form-check-input required></asp:DropDownList>
    </div>

    <div class="uk-margin"> 
    <asp:Button Text="Eliminar Tipo de Ticket Seleccionado" runat="server" CssClass="uk-button uk-button-danger uk-button-large" />
    </div>

</div>



</asp:Content>


