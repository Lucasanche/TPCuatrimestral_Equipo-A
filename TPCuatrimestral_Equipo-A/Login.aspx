<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.WebForm1" %>

<asp:Content ID="HomeHead" ContentPlaceHolderID="head" runat="server">
    <link href="estilos/home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="HomeMain" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="div-principal">
            <div class="card-body">
                <div class="titulo-login">
                    <h3 style="font-size: 45px; font-weight: 600; color: #7c83d785;">Iniciar sesión</h3>
                </div>
                <div class="card-body">
                    <form>
                        <div class="input-group form-group imagen-span">
                            <div class="container-icono">
                                <span class="icono">
                                    <i class="fas fa-user"></i>
                                </span>
                            </div>
                            <asp:TextBox runat="server" type="email"  CssClass="form-control is-invalid" 
                                placeholder="Email" ID="TextEmailUsuario" required="required"/>
                        </div>
                        <div class="input-group form-group">
                            <div class="container-icono">
                                <span class="icono">
                                    <i class="fas fa-key"></i>
                                </span>
                            </div>
                            <asp:TextBox runat="server" type="password" CssClass="form-control" placeholder="Contraseña..." ID="TextPassword" />
                        </div>
                        <%--                        <div class="row align-items-center remember">
                            <input type="checkbox">Remember Me
                        </div>--%>
                        <div class="form-group container-btn">
                            <asp:Button type="submit" Text="Ingresar" CssClass="btn float-right login_btn" runat="server" ID="btnIngresar" OnClick="btnIngresar_Click" />

                        </div>
                        <div>
                            <asp:Label ID="textError" runat="server" Text="El usuario no existe" Visible="false"></asp:Label>
                        </div>
                    </form>
                </div>
                <div class="card-footer">
                    <div class="d-flex justify-content-center ">
                        <a href="#">¿Olvidaste tu contraseña?</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
