using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDatos;
using System.Data;
using CapaEntidad;

public partial class Login : System.Web.UI.Page
{
    UsuariosNegocio usuNeg = new UsuariosNegocio();


    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
        //{
        //    txtEmail.Text = Request.Cookies["UserName"].Value;
        //    txtContra.Attributes["value"] = Request.Cookies["Password"].Value;
        //}
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        lblAlerta.Text = "<i class='lnr lnr-warning'></i> Usuario y/o Contraseña Inválidos";
        Usuarios usu = new Usuarios();
        usu.EmailUsuario = txtEmail.Text;
        usu.Contraseña = txtContra.Text;
        IngresoUsuario(usu);
    }

    protected void IngresoUsuario(Usuarios usu)
    {
        DataTable dt = usuNeg.IngresoUsuario(usu);

        if (dt.Rows.Count > 0)
        {
            Session["Datos"] = dt;
            string url = "";

            if (dt.Rows[0]["IdPerfil"].ToString() == "1")
            {
                url = "Barcelona.aspx";
            }
            else if (dt.Rows[0]["IdPerfil"].ToString() == "2")
            {
                url = "RealMadrid.aspx";
            }
            else
            {
                url = "Login.aspx";
            }

            Response.Redirect(url);
        }
    }
}