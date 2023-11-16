<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error404.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.Error404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="page_404">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 ">
                    <div class="col-sm-10 col-sm-offset-1  text-center">
                        <div class="four_zero_four_bg">
                            <h1 class="text-center ">404</h1>
                        </div>
                        <div class="contant_box_404">
                            <h3 class="h2">Parece que te perdiste!
                            </h3>
                            <p>
                                La página que buscas no se encuentra disponible!
                            </p>
                            <a href="Login.aspx" class="link_404">Regresar a Login
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
