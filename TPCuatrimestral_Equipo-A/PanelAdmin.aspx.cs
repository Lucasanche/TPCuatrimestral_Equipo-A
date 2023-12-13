using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace TPCuatrimestral_Equipo_A
{
    public partial class PanelAdmin : System.Web.UI.Page
    {
        private List<TipoTicket> tipos;
        private List<Rol> roles;
        protected void Page_Load(object sender, EventArgs e)
        {
            tipos = TipoTicketBusiness.List();
            //roles = RolBusiness.List();

            ddlEditarTipoTicket.DataSource = tipos;
            ddlEditarTipoTicket.DataTextField = "Nombre";
            ddlEditarTipoTicket.DataBind();


            ddlEliminarTipoTicket.DataSource = tipos;
            ddlEliminarTipoTicket.DataTextField = "Nombre";
            ddlEliminarTipoTicket.DataBind();

            /*
            ddlRol.DataSource = roles;
            ddlRol.DataTextField = "Descripcion";
            ddlRol.DataBind();
            */
        }
        protected void GuardarUsuario_Click(object sender, EventArgs e)
        {
            string legajo;
            string nombre;
            string apellido;
            string email;

            if (txtLegajo.Text == "")
            {
                txtValidarLegajo.Text = "Falta Legajo";
            }
            else if (txtNombre.Text == "")
            {
                txtValidarNombre.Text = "Falta Nombre";
            }
            else if (txtApellido.Text == "")
            {
                txtValidarApellido.Text = "Falta Apellido";
            }
            else if (txtEmail.Text == "")
            {
                txtValidarEmail.Text = "Falta Email";
            }

            if (txtLegajo.Text != "" && txtNombre.Text != "" && txtApellido.Text != "" && txtEmail.Text != "")
            {
                legajo = txtLegajo.Text;
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                email = txtEmail.Text;

                if (UsuarioBusiness.AgregarUsuario(legajo, nombre, apellido, email) == 1)
                {
                    txtAgregaCliente.Text = "Cliente agregado exitosamente";
                }
            }
        }
        protected void GuardarTipoTicket_Click(object sender, EventArgs e)
        {
            string nuevoNombre;
            nuevoNombre = txtNombreIncidencia.Text;

            if (TipoTicketBusiness.AgregarTipoTicket(nuevoNombre) == 1)
            {
                txtValidarGuardado.Text = "Tipo de Ticket Guardado exitosamente.";
            }

        }
        protected void EditarUsuario_Click(object sender, EventArgs e)
        {
            string legajo;
            string nombre;
            string apellido;
            string email;
            legajo = txtLegajoUsuarioEditar.Text;
            nombre = txtNombreEditarUsuario.Text;
            apellido = txtApellidoEditarUsuario.Text;
            email = txtEmailEditarUsuario.Text;

            if (UsuarioBusiness.ModificarUsuario(legajo, nombre, apellido, email) == 1)
            {
                txtValidarUserEditar.Text = "Usuario Editado exitosamente";
            }

        }
        protected void EditarTipoTicket_Click(object sender, EventArgs e)
        {


        }
        protected void EliminarUsuario_Click(object sender, EventArgs e)
        {

            Usuario usuario = new Usuario();
            string legajo;
            legajo = txtLegajoEliminarUsuario.Text;

            usuario = UsuarioBusiness.UsuarioPorLegajo(legajo);

            if (UsuarioBusiness.EliminarUsuario(legajo) == 1)
            {
                txtValidarUsuarioEliminar.Text = "Usuario Eliminado Exotosamente.";
            }

        }
        protected void EliminarTipoTicket_Click(object sender, EventArgs e)
        {
            string ticketEliminar;
            ticketEliminar = ddlEliminarTipoTicket.Text;

            if (TipoTicketBusiness.EliminarTipoTicket(ticketEliminar) == 1)
            {
                txtValidarEliminado.Text = "Tipo de Ticket Eliminado exitosamente.";
            }
        }

        protected void BuscarUsuarioEditar_Click(object sender, EventArgs e)
        {

            if (txtLegajoUsuarioEditar.Text == null)
            {
                txtValidarUserEditar.Text = "Complete con el Legajo del usuario";
            }
            else
            {
                Usuario usuario = new Usuario();
                string legajo;
                legajo = txtLegajoUsuarioEditar.Text;

                usuario = UsuarioBusiness.UsuarioPorLegajo(legajo);

                txtNombreEditarUsuario.Text = usuario.Nombre;
                txtApellidoEditarUsuario.Text = usuario.Apellido;
                txtEmailEditarUsuario.Text = usuario.Email;

            }

        }
        protected void BuscarUsuarioEliminar_Click(object sender, EventArgs e)
        {
            if (txtLegajoEliminarUsuario.Text == null)
            {
                txtValidarUsuarioEliminar.Text = "Complete con el Legajo del usuario";
            }
            else
            {
                Usuario usuario = new Usuario();
                string legajo;
                legajo = txtLegajoEliminarUsuario.Text;

                usuario = UsuarioBusiness.UsuarioPorLegajo(legajo);
            }

        }

    }
}