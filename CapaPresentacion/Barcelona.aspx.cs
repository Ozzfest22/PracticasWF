using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidad;
using System.Data;
using System.Text;

public partial class Barcelona : System.Web.UI.Page
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
                LlenarCombo();
                nomUsuario.Text = dt.Rows[0]["NomUsuario"].ToString();
            }
        }
    }

    protected void ListarDatos()
    {
        try
        {
            gvBarcelona.DataSource = jugNeg.ListarJugadores_BC();
            gvBarcelona.DataBind();
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
            gvBarcelona.DataSource = jugNeg.BusquedaJugador_BC(txtBusqueda.Text);
            gvBarcelona.DataBind();
        }
        catch (Exception ex)
        {

            throw new ArgumentException(ex.Message);
        }

    }

    protected void LlenarCombo()
    {
        ddlEquipos.AppendDataBoundItems = true;
        ddlEquipos.DataSource = jugNeg.LlenarCombo("perfil");
        ddlEquipos.DataTextField = "NomEquipo";
        ddlEquipos.DataValueField = "IdEquipo";
        ddlEquipos.DataBind();
        ddlEquipos.Items.Insert(0, new ListItem("Seleccione ...", "0"));

        ddlEquipos_U.AppendDataBoundItems = true;
        ddlEquipos_U.DataSource = jugNeg.LlenarCombo("perfil");
        ddlEquipos_U.DataTextField = "NomEquipo";
        ddlEquipos_U.DataValueField = "IdEquipo";
        ddlEquipos_U.DataBind();

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



    protected void btnAgregarModal_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#addModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "AddShow", sb.ToString(), false);
    }

    protected void btnAgregarInfo_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsValid)
            { 
            jugEnt.DniJugador = txtDni.Text;
            jugEnt.NomJugador = txtNombre.Text;
            jugEnt.ApePatJugador = txtApePat.Text;
            jugEnt.ApeMatJugador = txtApeMat.Text;
            jugEnt.EdadJugador = Convert.ToInt32(txtEdad.Text);
            jugEnt.IdEquipo = ddlEquipos.SelectedIndex;

          
            
                if (jugNeg.InsertarJugador(jugEnt) == true)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("alert('Registro agregado correctamente');");
                    sb.Append("$('#addModal').modal('hide');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "HideAddShow", sb.ToString(), false);
                    ListarDatos();
                }
            }
         
        }
        catch (Exception ex)
        {

            throw new ArgumentException(ex.Message);
        }
    }

    protected void gvBarcelona_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBarcelona.PageIndex = e.NewPageIndex;
        gvBarcelona.DataBind();
        ListarDatos();
        ListarDatosBusqueda();
    }


    protected void gvBarcelona_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        int cod;

        if (e.CommandName.Equals("editRecord"))
        {
            cod = Convert.ToInt32(gvBarcelona.Rows[index].Cells[0].Text);
            Session["IdJugador"] = cod;

            jugEnt = jugNeg.ConsultarJugador(cod);

            txtDni_U.Text = jugEnt.DniJugador;
            txtNombre_U.Text = jugEnt.NomJugador;
            txtApePat_U.Text = jugEnt.ApePatJugador;
            txtApeMat_U.Text = jugEnt.ApeMatJugador;
            txtEdad_U.Text = jugEnt.EdadJugador.ToString();
            ddlEquipos_U.SelectedValue = jugEnt.IdEquipo.ToString();


            StringBuilder sb = new StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#editModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "EditModalScript", sb.ToString(), false);
        }
    }

    protected void btnEditarInfo_Click(object sender, EventArgs e)
    {
        try
        {
            jugEnt.IdJugador = Convert.ToInt32(Session["IdJugador"]);
            jugEnt.DniJugador = txtDni_U.Text;
            jugEnt.NomJugador = txtNombre_U.Text;
            jugEnt.ApePatJugador = txtApePat_U.Text;
            jugEnt.ApeMatJugador = txtApeMat_U.Text;
            jugEnt.EdadJugador = Convert.ToInt32(txtEdad_U.Text);
            jugEnt.IdEquipo = Convert.ToInt32(ddlEquipos_U.SelectedValue);

            if (jugNeg.ActualizarJugador(jugEnt) == true)
            {
                ListarDatos();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('Records Updated Successfully');");
                sb.Append("$('#editModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

            }
        }
        catch (Exception ex)
        {

            throw new ArgumentException(ex.Message);
        }
    }
}