<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!--Importar estilos de estilos/home.css que corresponde a esta hoja de estilos-->
    <div class="container">
        <div class="div-principal">
            <div class="form-login">
                <div class="titulo-login">
                    <h1>Call Center</h1>
                </div>
                <div class="card-body pb-4 pt-2">
                    <div class="imagen-span">
                        <div class="container-icono">
                            <span class="icono">
                            <i class="icono-img-usr"></i>
                            </span>
                        </div>
                        <input type="text" class="input-texto" placeholder="Usuario">
                    </div>
                    <div class="imagen-span">
                    <div class="container-icono">
                        <span class="icono">
                        <i class="icono-img-password"></i>
                        </span>
                    </div>
                    <input type="password" class="input-texto" placeholder="Contraseña...">
                    </div>
                </div>
                <div class="container-btn">
                    <a href="#" class="btn">Ingresar</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
