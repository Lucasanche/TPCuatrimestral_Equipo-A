<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelAdmin.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.PanelAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="estilos/panelAdmin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="menu-navegacion">
        <a href="#seccion-alta">ALTA</a>
        <a href="#seccion-editar">EDITAR</a>
        <a href="#seccion-eliminar">ELIMINAR</a>
    </div>


    <div class="uk-section uk-section-muted" id="seccion-alta">
        <div class="col-2"></div>
        <div class="container">


            <!--

    [LEGAJO]     VARCHAR (10) NOT NULL, no se modifica, preguntar como se compone si es PK pero sin numero
    [NOMBRE]     VARCHAR (40) NOT NULL, modificable
    [APELLIDO]   VARCHAR (40) NOT NULL, modificable
    [EMAIL]      VARCHAR (70) NOT NULL, modificable
    [PASSWORD]   VARCHAR (40) NOT NULL, modificable??
    [FECHA_ALTA] DATE         DEFAULT (getdate()) NOT NULL, no se modifica
    [FECHA_BAJA] DATE         NULL, no se modifica
    [ROL]        TINYINT      NOT NULL,  modificable
    [ESTADO]     BIT          DEFAULT ((1)) NOT NULL, no se modifica??

-->


            <form novalidate>
                <h3 class="uk-heading-divider">Agregar Usuario</h3>

                <div class="uk-form-stacked">

                    <div class="uk-margin">
                        <label class="uk-form-label" for="form-stacked-text">Legajo:</label>
                        <div class="uk-form-controls">
                            <asp:TextBox ID="txtLegajo" runat="server" CssClass="uk-input" />
                            <asp:Label Text="" ID="txtValidarLegajo" runat="server" CssClass="warning" />
                        </div>
                    </div>

                    <div class="uk-margin">
                        <label class="uk-form-label" for="form-stacked-text">Nombre:</label>
                        <div class="uk-form-controls">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="uk-input" />
                            <asp:Label Text="" ID="txtValidarNombre" runat="server" CssClass="warning" />
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
                        <label class="uk-form-label" for="form-stacked-text">Email:</label>
                        <div class="uk-form-controls">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="uk-input" />
                            <asp:Label Text="" ID="txtValidarEmail" runat="server" CssClass="warning" />
                        </div>
                    </div>

                    <div class="uk-margin">
                        <label class="uk-form-label" for="form-stacked-text">Rol:</label>
                        <div class="uk-form-controls">
                            <asp:DropDownList runat="server" ID="ddlRol" CssClass="btn btn-secondary dropdown-toggle" Style="text-align: left;" form-check-input required></asp:DropDownList>
                        </div>
                    </div>


                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Usuario" OnClick="GuardarUsuario_Click" CssClass="uk-button uk-button-secondary uk-width-1-1" UseSubmitBehavior="false" />
                    <asp:Button ID="btnRecargar" runat="server" Text="Cargar otro usuario" OnClick="btnRecargar_Click" CssClass="uk-button uk-button-secondary uk-width-1-1" UseSubmitBehavior="false" visible="false"/>
                    <asp:Label Text="" runat="server" ID="txtAgregaCliente" CssClass="warning" />
                </div>
            </form>
        </div>

        <br />

        <div class="col-2"></div>
        <div class="container">
            <form novalidate>
                <h3 class="uk-heading-divider">Agregar Tipo Ticket</h3>

                <div class="uk-form-stacked">
                    <div class="uk-margin">
                        <label class="uk-form-label" for="form-stacked-text">Nombre:</label>
                        <div class="uk-form-controls">
                            <asp:TextBox ID="txtIncidencia" runat="server" CssClass="uk-input" placeholder="Nombre de la nueva incidencia"/>
                            <asp:Label Text="" ID="txtValidarNombreIncidencia" runat="server" CssClass="warning" />
                        </div>
                    </div>

                    <asp:Button ID="btnGuardarTipoTicket" runat="server" Text="Guardar Tipo Ticket" OnClick="GuardarTipoTicket_Click" CssClass="uk-button uk-button-secondary uk-width-1-1" UseSubmitBehavior="false"/>
                  
                    <asp:Label Text="" ID="txtValidarGuardado" runat="server" CssClass="warning" />
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
                    <asp:LinkButton ID="BuscarUsuario" runat="server" OnClick="BuscarUsuarioEditar_Click">
                        <i class="lupita">
                            <svg xmlns="http://www.w3.org/2000/svg" class="input-icon" viewBox="0 0 20 20" fill="currentColor" width="20" height="20">
                            <path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd" />
                            </svg>
                        </i>
                    </asp:LinkButton>
                    <asp:Label Text="" ID="txtValidarUserEditar" CssClass="warning" runat="server" />
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
                            <asp:TextBox ID="txtNombreEditarUsuario" runat="server" CssClass="uk-input" />
                            <asp:Label Text="" ID="txtValidarNombreEdit" runat="server" CssClass="warning" />
                        </div>
                    </div>

                    <div class="uk-margin">
                        <label class="uk-form-label" for="form-stacked-text">Apellido:</label>
                        <div class="uk-form-controls">
                            <asp:TextBox ID="txtApellidoEditarUsuario" runat="server" CssClass="uk-input" />
                            <asp:Label Text="" ID="txtValidarApellidoEdit" runat="server" CssClass="warning" />
                        </div>
                    </div>

                    <div class="uk-margin">
                        <label class="uk-form-label" for="form-stacked-text">Email:</label>
                        <div class="uk-form-controls">
                            <asp:TextBox ID="txtEmailEditarUsuario" runat="server" CssClass="uk-input" />
                            <asp:Label Text="" ID="txtValidarEmailEdit" runat="server" CssClass="warning" />
                        </div>
                    </div>


<%--                     <div class="uk-margin">
                         <label class="uk-form-label" for="form-stacked-text">Rol:</label>
                         <div class="uk-form-controls">
                             <asp:DropDownList runat="server" ID="DropDownList1" CssClass="btn btn-secondary dropdown-toggle" Style="text-align: left;" form-check-input required></asp:DropDownList>
                         </div>
                     </div>--%>

                    <asp:Button ID="Button2" runat="server" Text="Editar Usuario" OnClick="EditarUsuario_Click" CssClass="uk-button uk-button-secondary uk-width-1-1" UseSubmitBehavior="false" />
                </div>
            </form>
        </div>


        <div class="col-2"></div>
        <div class="container">
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

                    <asp:Button Text="Editar Tipo de Ticket" runat="server" OnClick="EditarTipoTicket_Click" CssClass="uk-button uk-button-primary uk-width-1-1" />
                </form>
            </div>
        </div>
    </div>

    <div class="uk-section uk-section-primary uk-light" id="seccion-eliminar">
        <h3 class="uk-heading-divider">Eliminar Usuario</h3>

        <div class="col-2"></div>
        <div class="container">
            <div class="col-10">
                <asp:TextBox runat="server" ID="txtLegajoEliminarUsuario" placeholder="Buscar Usuario por Legajo..." CssClass="uk-input" />
                <asp:LinkButton ID="BuscarUsuario2" runat="server" OnClick="BuscarUsuarioEliminar_Click">
                        <i class="lupita">
                            <svg xmlns="http://www.w3.org/2000/svg" class="input-icon" viewBox="0 0 20 20" fill="currentColor" width="20" height="20">
                            <path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd" />
                            </svg>
                        </i>
                </asp:LinkButton>
                <asp:Label Text="" ID="txtValidarUsuarioEliminar" CssClass="warning" runat="server" />
                <div class="container" style="display: flex; justify-content: center;">
                    <div class="uk-margin">
                        <div class="col-8">
                            <asp:Button Text="Eliminar Usuario Seleccionado" runat="server" OnClick="EliminarUsuario_Click" CssClass="uk-button uk-button-danger uk-button-large" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <h3 class="uk-heading-divider">Eliminar Tipo Ticket</h3>

        <div class="col-2"></div>
        <div class="container">
            <label class="uk-form-label" for="form-stacked-text">Seleccione Tipo:</label>
            <div class="uk-margin">
                <asp:DropDownList ID="ddlEliminarTipoTicket" runat="server" CssClass="btn btn-secondary dropdown-toggle" Style="text-align: left;" form-check-input required></asp:DropDownList>
            </div>
        </div>

        <div class="col-2"></div>
        <div class="container" style="display: flex; justify-content: center;">
            <div class="uk-margin">
                <asp:Button Text="Eliminar Tipo de Ticket Seleccionado" runat="server" OnClick="EliminarTipoTicket_Click" CssClass="uk-button uk-button-danger uk-button-large" />
            </div>
        </div>
        <asp:Label Text="" ID="txtValidarEliminado" runat="server" CssClass="warning" />

    </div>



</asp:Content>


