<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="estilos/home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="div-principal">
            <div class="form-login">
                <div class="titulo-login">
                    <h1 style="font-size: 45px;font-weight: 600;color: #7c83d785;">Call Center</h1>
                </div>
                <div class="card-body pb-4 pt-2">
                    <div class="imagen-span">
                        <div class="container-icono">
                            <span class="icono">
                                <i class="icono-img-usr"></i>
                            </span>
                        </div>
                        <asp:TextBox runat="server" type="text" CssClass="input-texto" placeholder="Email..." ID="TextEmailUsuario"/>
                    </div>
                    <div class="imagen-span">
                        <div class="container-icono">
                            <span class="icono">
                                <i class="icono-img-password"></i>
                            </span>
                        </div>
                        <asp:TextBox runat="server" type="password" CssClass="input-texto" placeholder="Contraseña..." ID="TextPassword"/>
                    </div>
                </div>
                <div class="container-btn">
                    <asp:Button Text="Ingresar" CssClass="btn" runat="server" ID="btnIngresar" OnClick="btnIngresar_Click"/>
                </div>
                <div>
                    <asp:Label ID="Error" runat="server" Text="El usuario no existe" Visible="false"></asp:Label>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
