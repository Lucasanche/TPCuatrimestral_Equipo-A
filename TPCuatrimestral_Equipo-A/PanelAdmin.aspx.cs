using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Microsoft.CodeAnalysis.FlowAnalysis;
using System.Web.Caching;
using System.Drawing;

namespace TPCuatrimestral_Equipo_A
{
    public partial class PanelAdmin : System.Web.UI.Page
    {
        private List<TipoTicket> tipos;
        private List<Rol> roles;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                tipos = TipoTicketBusiness.List();
                roles = RolBusiness.List();

                ddlEditarTipoTicket.DataSource = tipos;
                ddlEditarTipoTicket.DataTextField = "Nombre";
                ddlEditarTipoTicket.DataBind();
                ddlEditarTipoTicket.SelectedIndex = 1;


                ddlEliminarTipoTicket.DataSource = tipos;
                ddlEliminarTipoTicket.DataTextField = "Nombre";
                ddlEliminarTipoTicket.DataBind();
                ddlEliminarTipoTicket.SelectedIndex = 1;

                ddlRol.DataSource = roles;
                ddlRol.DataTextField = "Descripcion";
                ddlRol.DataBind();

                DropDownList1.DataSource = roles;
                DropDownList1.DataTextField = "Descripcion";
                DropDownList1.DataBind();
       
        }
        protected void GuardarUsuario_Click(object sender, EventArgs e)
        {
            string legajo;
            string nombre;
            string apellido;
            string email;
            int rol;

            if (string.IsNullOrEmpty(txtLegajo.Text))
            {
                txtValidarLegajo.Text = "Falta Legajo";
            }
            else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                txtValidarNombre.Text = "Falta Nombre";
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                txtValidarApellido.Text = "Falta Apellido";
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtValidarEmail.Text = "Falta Email";
            }

            if (txtLegajo.Text != "" && txtNombre.Text != "" && txtApellido.Text != "" && txtEmail.Text != "")
            {
                legajo = txtLegajo.Text;
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                email = txtEmail.Text;

                if(ddlRol.Text == "Telefonista")
                {
                    rol = 1;
                }
                else if (ddlRol.Text == "Supervisor")
                {
                    rol = 2;
                }
                else if (ddlRol.Text == "Administrador")
                {
                    rol = 3;
                }
                else {rol = 1;}


                if (UsuarioBusiness.AgregarUsuario(legajo, nombre, apellido, email, rol) == 1)
                {
                    txtLegajo.Enabled = false;
                    txtNombre.Enabled = false;
                    txtApellido.Enabled = false;
                    txtEmail.Enabled = false;
                    ddlEditarTipoTicket.Enabled = false;
                    txtAgregaCliente.ForeColor = System.Drawing.Color.Green;
                    txtAgregaCliente.Text = "Cliente agregado exitosamente";
                    btnGuardar.Visible= false;
                    btnRecargar.Visible = true;
                }
                else
                {
                    txtAgregaCliente.ForeColor = System.Drawing.Color.Red;
                    txtAgregaCliente.Text = "Ocurrió un error, intentelo nuevamente";
                }
            }
        }
        protected void GuardarTipoTicket_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string nuevoNombre;

                if (string.IsNullOrEmpty(txtNombreIncidencia.Text))
                {
                    txtValidarNombreIncidencia.ForeColor = System.Drawing.Color.Red;
                    txtValidarNombreIncidencia.Text = "Falta Nombre de Tipo Ticket";
                }
                if (txtNombreIncidencia.Text != "")
                {
                    nuevoNombre = txtNombreIncidencia.Text;

                    if (TipoTicketBusiness.AgregarTipoTicket(nuevoNombre) == 1)
                    {
                        txtValidarGuardado.ForeColor = System.Drawing.Color.Green;
                        txtValidarGuardado.Text = "Tipo de Ticket Guardado exitosamente.";
                    }
                    else
                    {
                        txtValidarGuardado.ForeColor = System.Drawing.Color.Red;
                        txtValidarGuardado.Text = "Ocurrió un error, intentelo nuevamente";
                    }
                }
            }
        }
        protected void BuscarUsuarioEditar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtLegajoUsuarioEditar.Text))
            {
                txtValidarUserEditar.Text = "Complete con el Legajo del usuario";
                return;
            }
            else
            {
                Usuario usuario = new Usuario();
                string legajo;
                legajo = txtLegajoUsuarioEditar.Text;

                usuario = UsuarioBusiness.UsuarioPorLegajo(legajo);
                if(usuario.Nombre == null || usuario.Apellido == null || usuario.Rol.Descripcion == null || usuario.Email == null)
                {
                    txtValidarUserEditar.ForeColor = System.Drawing.Color.Red;
                    txtValidarUserEditar.Text = "Usuario NO ENCONTRADO";
                    return;
                }
                

                txtNombreEditarUsuario.Text = usuario.Nombre;
                txtApellidoEditarUsuario.Text = usuario.Apellido;
                DropDownList1.Text = usuario.Rol.Descripcion;
                txtEmailEditarUsuario.Text = usuario.Email;
            }

        }
        protected void EditarUsuario_Click(object sender, EventArgs e)
        {
            
            string legajo;
            string nombre;
            string apellido;
            string email;
            int rol;

            if (string.IsNullOrEmpty(txtLegajoUsuarioEditar.Text))
            {
                txtValidarUserEditar.Text = "Falta Legajo";
            }
            else if (string.IsNullOrEmpty(txtNombreEditarUsuario.Text))
            {
                txtValidarNombreEdit.Text = "Falta Nombre";
            }
            else if (string.IsNullOrEmpty(txtApellidoEditarUsuario.Text))
            {
                txtValidarApellidoEdit.Text = "Falta Apellido";
            }
            else if (string.IsNullOrEmpty(txtEmailEditarUsuario.Text))
            {
                txtValidarEmailEdit.Text = "Falta Email";
            }

            


            if (txtLegajoUsuarioEditar.Text != "" && txtNombreEditarUsuario.Text != "" && txtApellidoEditarUsuario.Text != "" && txtEmailEditarUsuario.Text != "")
            {

                legajo = txtLegajoUsuarioEditar.Text;
                nombre = txtNombreEditarUsuario.Text;
                apellido = txtApellidoEditarUsuario.Text;
                email = txtEmailEditarUsuario.Text;

                if (ddlRol.Text == "Telefonista")
                {
                    rol = 1;
                }
                else if (ddlRol.Text == "Supervisor")
                {
                    rol = 2;
                }
                else if (ddlRol.Text == "Administrador")
                {
                    rol = 3;
                }
                else { rol = 1; }


                if (UsuarioBusiness.ModificarUsuario(legajo, nombre, apellido, email, rol) == 1)
                {
                    txtValidarUserEditar2.ForeColor = System.Drawing.Color.Green;
                    txtValidarUserEditar2.Text = "Usuario Editado exitosamente";
                }
                else
                {
                    txtValidarUserEditar2.ForeColor = System.Drawing.Color.Red;
                    txtValidarUserEditar2.Text = "Usuario no se pudo editar, intente nuevamente";
                }
            }

        }
        protected void EditarTipoTicket_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string tipoTicket;
                string nuevoTipoTicket;
                nuevoTipoTicket = txtNombreTipoTicketEditar.Text;
                tipoTicket = ddlEditarTipoTicket.Text;

                if (TipoTicketBusiness.ModificarTipoTicket(tipoTicket, nuevoTipoTicket) == 1)
                {
                    validaEditarTipoTicketAccion.ForeColor = System.Drawing.Color.Green;
                    validaEditarTipoTicketAccion.Text = "Tiket editado correctamente";
                }
                else
                {
                    validaEditarTipoTicketAccion.ForeColor = System.Drawing.Color.Red;
                    validaEditarTipoTicketAccion.Text = "No se pudo editar el ticket, intente nuevamente";
                }
            }
        }

        protected void EliminarUsuario_Click(object sender, EventArgs e)
        {

            Usuario usuario = new Usuario();
            string legajo;
            legajo = txtLegajoEliminarUsuario.Text;

            usuario = UsuarioBusiness.UsuarioPorLegajo(legajo);

            if (UsuarioBusiness.EliminarUsuario(legajo) == 1)
            {
                txtValidarUsuarioEliminar.ForeColor = System.Drawing.Color.Green;
                txtValidarUsuarioEliminar.Text = "Usuario Eliminado Exotosamente.";
            }
            else
            {
                txtValidarUsuarioEliminar.ForeColor = System.Drawing.Color.Red;
                txtValidarUsuarioEliminar.Text = "Usuario NO se pudo eliminar, intente nuevamente.";

            }

        }
        protected void EliminarTipoTicket_Click(object sender, EventArgs e)
        {
            string ticketEliminar;
            ticketEliminar = ddlEliminarTipoTicket.Text;

            if (TipoTicketBusiness.EliminarTipoTicket(ticketEliminar) == 1)
            {
                txtValidarEliminado.ForeColor = System.Drawing.Color.Green;
                txtValidarEliminado.Text = "Tipo de Ticket Eliminado exitosamente.";
            }
            else
            {
                txtValidarEliminado.ForeColor = System.Drawing.Color.Red;
                txtValidarEliminado.Text = "Tipo de Ticket NO se pudo eliminar, intente nuevamente.";

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

        protected void btnRecargar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelAdmin.aspx");
        }
    }
}