using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidad;
using System.Data;

public partial class RealMadrid : System.Web.UI.Page
{
    JugadoresNegocio jugNeg = new JugadoresNegocio();
    Jugador jugEnt = new Jugador();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            if (Session["Datos"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["Datos"];

                ListarDatos();
                ListarDatosBusqueda();
                nomUsuario.Text = dt.Rows[0]["NomUsuario"].ToString();
            }
        }

        ListarDatos();
        ListarDatosBusqueda();
    }

    protected void ListarDatos()
    {
        try
        {
            gvRealMadrid.DataSource = jugNeg.ListarJugadores_RM();
            gvRealMadrid.DataBind();
        }
        catch (Exception ex)
        {

            throw new ArgumentException(ex.Message);
        }
    }

    protected void ListarDatosBusqueda()
    {
        try
        {
            gvRealMadrid.DataSource = jugNeg.BusquedaJugador_RM(txtBusqueda.Text);
            gvRealMadrid.DataBind();
        }
        catch (Exception ex)
        {

            throw new ArgumentException(ex.Message);
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        ListarDatosBusqueda();
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Session["Datos"] = null;
        Response.Redirect("~/Principal.aspx");
    }
}