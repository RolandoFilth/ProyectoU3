using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taqueria.Linq.Data.Entity;
using TaqueriaPTadeosControl;

namespace TaqueriaTadeos.Vistas
{
    public partial class VistaGenerica : System.Web.UI.Page
    {
        private SessionManager session = new SessionManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Buffer = true;
            try
            {
                Response.Buffer = true;
                DataContext dcTemp = new DcGeneralDataContext();
                if (!this.IsPostBack)
                {
                    List<TipoAlimento> listaTAlimetno = dcTemp.GetTable<TipoAlimento>().ToList();
                    List<TipoAlimento> listaTAlimetnoModal = dcTemp.GetTable<TipoAlimento>().ToList();
                    TipoAlimento TAlimento = new TipoAlimento();
                    TAlimento.IdTAlimento = -1;
                    TAlimento.Nombre = "Todos";
                    listaTAlimetno.Insert(0, TAlimento);
                    this.ddlTAlimento.DataTextField = "Nombre";
                    this.ddlTAlimento.DataValueField = "IdTAlimento";
                    this.ddlTAlimento.DataSource = listaTAlimetno;
                    this.ddlTAlimento.DataBind();

                   

                    List<TipoProducto> listaTProducto = dcTemp.GetTable<TipoProducto>().ToList();
                    List<TipoProducto> listaTProductoModal = dcTemp.GetTable<TipoProducto>().ToList();
                    TipoProducto TProducto = new TipoProducto();
                    TProducto.IdTProducyo = -1;
                    TProducto.Nombre = "Todos";
                    listaTProducto.Insert(0, TProducto);
                    this.ddlTProducto.DataTextField = "Nombre";
                    this.ddlTProducto.DataValueField = "IdTProducyo";
                    this.ddlTProducto.DataSource = listaTProducto;
                    this.ddlTProducto.DataBind();


                   

                    List<TipoCarne> listaTCArne = dcTemp.GetTable<TipoCarne>().ToList();
                    TipoCarne Tcarne = new TipoCarne();

                    Tcarne.IdTCarne = -1;
                    Tcarne.Nombre = "Todos";
                    listaTCArne.Insert(0,Tcarne);
                    this.ddlTipoCarne.DataTextField = "Nombre";
                    this.ddlTipoCarne.DataValueField = "IdTCarne";
                    this.ddlTipoCarne.DataSource = listaTCArne;
                    this.ddlTipoCarne.DataBind();

                  
                }
            }
            catch (Exception _e)
            {
                //  this.showMessage("Ha ocurrido un problema al cargar la página");
            }



        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.LinqDataSource1.RaiseViewChanged();
            }
            catch (Exception _e)
            {
                //this.showMessage("Ha ocurrido un problema al buscar");
            }
        }
        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            try
            {
                DataContext dcConsulta = new DcGeneralDataContext();
                bool nombreBool = false;
                bool TAlimentoBool = false;
                bool TProducto = false;
                bool TCarne = false;
                if (!this.txtNombre.Text.Equals(String.Empty))
                {
                    nombreBool = true;
                }
                if (this.ddlTAlimento.Text != "-1")
                {
                    TAlimentoBool = true;
                }
                if (this.ddlTProducto.Text != "-1")
                {
                    TProducto = true;


                }

                if (this.ddlTipoCarne.Text != "-1")
                {
                    TCarne = true;


                }

                Expression<Func<Taqueria.Linq.Data.Entity.Producto, bool>>
                    predicate =
                    (c =>
                    ((TAlimentoBool) ? c.TAlimentoId == int.Parse(this.ddlTAlimento.Text) : true) &&
                    ((nombreBool) ? (((nombreBool) ? c.NombreProducto.Contains(this.txtNombre.Text.Trim()) : false)) : true) &&
                    ((TProducto) ? c.TAlimentoId == int.Parse(this.ddlTProducto.Text) : true) &&
                    ((TCarne) ? c.TCarneID == int.Parse(this.ddlTipoCarne.Text) : true)
                    );

                predicate.Compile();
                List<Taqueria.Linq.Data.Entity.Producto> listaPersona =
                    dcConsulta.GetTable<Taqueria.Linq.Data.Entity.Producto>().Where(predicate).ToList();
                e.Result = listaPersona;
            }
            catch (Exception _e)
            {
                throw _e;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.session.Pantalla = "~/ProductoManager.aspx";
                Hashtable parametrosRagion = new Hashtable();
                parametrosRagion.Add("IdProducto", "0");
                this.session.Parametros = parametrosRagion;
                this.Session["SessionManager"] = this.session;
                this.Response.Redirect(this.session.Pantalla, false);
            }
            catch (Exception _e)
            {
               // this.showMessage("Ha ocurrido un problema al agregar");
            }
        }

        protected void dgvPrductos_RowCommand(object sender, GridViewCommandEventArgs e)
         {
            try
            {
                int idProducto = int.Parse(e.CommandArgument.ToString());
                switch (e.CommandName)
                {
                    case "Editar":
                        this.editar(idProducto);
                        break;
                    case "Eliminar":
                        this.eliminar(idProducto);
                        break;
                    
                }
            }
            catch (Exception _e)
            {
               // this.showMessage("Ha ocurrido un problema al seleccionar");
            }
        }

        private void editar(int _idProducto)
        {
            try
            {
                Hashtable parametrosRagion = new Hashtable();
                parametrosRagion.Add("idProducto", _idProducto.ToString());
                this.session.Parametros = parametrosRagion;
                this.Session["SessionManager"] = this.session;
                this.session.Pantalla = String.Empty;
                this.session.Pantalla = "~/ProductoManager.aspx";
                this.Response.Redirect(this.session.Pantalla, false);

            }
            catch (Exception _e)
            {
                throw _e;
            }
        }
        private void eliminar(int _idProducto)
        {
            try
            {
                DataContext dcDelete = new DcGeneralDataContext();
                Producto producto = dcDelete.GetTable<Producto>().First(
                    c => c.IdProducto == _idProducto);
                dcDelete.GetTable<Producto>().DeleteOnSubmit(producto);
                dcDelete.SubmitChanges();
 //               this.showMessage("El registro se agrego correctamente.");
                this.LinqDataSource1.RaiseViewChanged();
            }
            catch (Exception _e)
            {
                throw _e;
            }
        }
    }
}