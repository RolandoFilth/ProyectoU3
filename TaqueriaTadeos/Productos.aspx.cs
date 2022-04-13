using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taqueria.Linq.Data.Entity;

namespace TaqueriaTadeos.Vistas
{
    public partial class Productos : System.Web.UI.Page
    {
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

                    this.ddlTAlimentoModal.DataTextField = "Nombre";
                    this.ddlTAlimentoModal.DataValueField = "IdTAlimento";
                    this.ddlTAlimentoModal.DataSource = listaTAlimetnoModal;
                    this.ddlTAlimentoModal.DataBind();

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


                    this.ddlTProductoModal.DataTextField = "Nombre";
                    this.ddlTProductoModal.DataValueField = "IdTProducyo";
                    this.ddlTProductoModal.DataSource = listaTProductoModal;
                    this.ddlTProductoModal.DataBind();


                    List<TipoCarne> listaTCArne = dcTemp.GetTable<TipoCarne>().ToList();
                    this.ddlTipoCarneModal.DataTextField = "Nombre";
                    this.ddlTipoCarneModal.DataValueField = "IdTCarne";
                    this.ddlTipoCarneModal.DataSource = listaTCArne;
                    this.ddlTipoCarneModal.DataBind();

                    List<Sucursal> ListaSucursales = dcTemp.GetTable<Sucursal>().ToList();
                    this.ddlSucursales.DataTextField = "Nombre";
                    this.ddlSucursales.DataValueField = "IdSucursal";
                    this.ddlSucursales.DataSource = ListaSucursales;
                    this.ddlSucursales.DataBind();

                }
            }
            catch (Exception _e)
            {
              //  this.showMessage("Ha ocurrido un problema al cargar la página");
            }
        }


        protected void ddlTAlimento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void DataSourcePersona_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
           
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

        protected void ddlTProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void LinqDataSource2_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            try
            {
                DataContext dcConsulta = new DcGeneralDataContext();
                bool SucursalBool = false;
              

                if (this.ddlSucursales.Text != "-1")
                {
                    SucursalBool = true;
                }


                Expression<Func<Taqueria.Linq.Data.Entity.ProductoSucursal, bool>>
                    predicate2 =
                    (c =>
                    ((SucursalBool) ? c.IdSucursal == int.Parse(this.ddlSucursales.Text) : true) 
                  

                    );

                predicate2.Compile();
                List<Taqueria.Linq.Data.Entity.ProductoSucursal> listaSucursal =
                    dcConsulta.GetTable<Taqueria.Linq.Data.Entity.ProductoSucursal>().Where(predicate2).ToList();
                e.Result = listaSucursal;
            }
            catch (Exception _e)
            {
                throw _e;
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

                Expression<Func<Taqueria.Linq.Data.Entity.Producto, bool>>
                    predicate =
                    (c =>
                    ((TProducto) ? c.TProductoId == int.Parse(this.ddlTProducto.Text) : true)&&
                    ((TAlimentoBool) ? c.TAlimentoId == int.Parse(this.ddlTAlimento.Text) : true) &&
                    ((nombreBool) ? (((nombreBool) ? c.NombreProducto.Contains(this.txtNombre.Text.Trim()) : false)) : true) 
                    
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

        protected void ddlSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LinqDataSource2.RaiseViewChanged();
        }
    }
}