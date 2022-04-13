using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taqueria.Linq.Data.Entity;
using TaqueriaPTadeosControl;

namespace TaqueriaTadeos
{
    public partial class ProductoManager : System.Web.UI.Page
    {
        private SessionManager session = new SessionManager();
        private int idProducto = 0;
        private Taqueria.Linq.Data.Entity.Producto baseEntity;
        private DataContext dcGlobal = new DcGeneralDataContext();
        private int tipoAccion = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               

                this.Response.Buffer = true;
                this.session = (SessionManager)this.Session["SessionManager"];
                 this.idProducto = this.session.Parametros["idProducto"] != null ?
                    int.Parse(this.session.Parametros["idProducto"].ToString()) : 0;
                if (this.idProducto == 0)
                {
                    this.baseEntity = new Taqueria.Linq.Data.Entity.Producto();
                    this.tipoAccion = 1;
                }
                else
                {
                    this.baseEntity = dcGlobal.GetTable<Taqueria.Linq.Data.Entity.Producto>().First(c => c.IdProducto == this.idProducto);
                    this.tipoAccion = 2;
                }
                DataContext dcTemp = new DcGeneralDataContext();
                if (!this.IsPostBack)
                {

                    if (this.session.Parametros["baseEntity"] == null)
                    {
                        this.session.Parametros.Add("baseEntity", this.baseEntity);
                    }

                    List<TipoAlimento> listaTAlimetno = dcTemp.GetTable<TipoAlimento>().ToList();
                   // List<TipoAlimento> listaTAlimetnoModal = dcTemp.GetTable<TipoAlimento>().ToList();




                    List<TipoProducto> listaTProducto = dcTemp.GetTable<TipoProducto>().ToList();
                  //  List<TipoProducto> listaTProductoModal = dcTemp.GetTable<TipoProducto>().ToList();





                    List<TipoCarne> listaTCArne = dcTemp.GetTable<TipoCarne>().ToList();
                    //  TipoCarne TcarneItem = new TipoCarne();
                    TipoProducto TProducto = new TipoProducto();
                    TProducto.IdTProducyo = -1;
                    TProducto.Nombre = "Seleccionar";
                    listaTProducto.Insert(0, TProducto);
                    this.ddlTProducto.DataTextField = "Nombre";
                    this.ddlTProducto.DataValueField = "IdTProducyo";
                    this.ddlTProducto.DataSource = listaTProducto;
                    this.ddlTProducto.DataBind();


                    TipoCarne TCarneItem = new TipoCarne();
                    TCarneItem.IdTCarne = -1;
                    TCarneItem.Nombre = "Seleccionar";
                    listaTCArne.Insert(0, TCarneItem);
                    this.ddlTCarne.DataTextField = "Nombre";
                    this.ddlTCarne.DataValueField = "IdTCarne";
                    this.ddlTCarne.DataSource = listaTCArne;
                    this.ddlTCarne.DataBind();

                    TipoAlimento TAlimento = new TipoAlimento();
                    TAlimento.IdTAlimento = -1;
                    TAlimento.Nombre = "Seleccionar";
                    listaTAlimetno.Insert(0, TAlimento);
                    this.ddlTAlimetno.DataTextField = "Nombre";
                    this.ddlTAlimetno.DataValueField = "IdTAlimento";
                    this.ddlTAlimetno.DataSource = listaTAlimetno;
                    this.ddlTAlimetno.DataBind();

                    if (this.idProducto == 0)
                    {

                        this.lblAccion.Text = "Agregar";

                        TipoProducto TProducto_ = new TipoProducto();
                        //TProducto_.IdTProducyo = -1;
                       // TProducto_.Nombre = "Seleccionar";
                        //listaTProducto.Insert(0, TProducto_);
                        this.ddlTProducto.DataTextField = "Nombre";
                        this.ddlTProducto.DataValueField = "IdTProducyo";
                        this.ddlTProducto.DataSource = listaTProducto;
                        this.ddlTProducto.DataBind();


                        TipoCarne TCarneItem_ = new TipoCarne();
                        TCarneItem.IdTCarne = -1;
                        TCarneItem.Nombre = "Seleccionar";
                        this.ddlTCarne.DataTextField = "Nombre";
                        this.ddlTCarne.DataValueField = "IdTCarne";
                        this.ddlTCarne.DataSource = listaTCArne;
                        this.ddlTCarne.DataBind();

                        TipoAlimento TAlimento_ = new TipoAlimento();
                       // TAlimento_.IdTAlimento = -1;
                        //TAlimento_.Nombre = "Seleccionar";
                        //listaTAlimetno.Insert(0, TAlimento_);
                        this.ddlTAlimetno.DataTextField = "Nombre";
                        this.ddlTAlimetno.DataValueField = "IdTAlimento";
                        this.ddlTAlimetno.DataSource = listaTAlimetno;
                        this.ddlTAlimetno.DataBind();
                    }
                    else
                    {
                        this.lblAccion.Text = "Editar";
                        this.txtNombre.Text = this.baseEntity.NombreProducto;
                        this.txtPrecio.Text = this.baseEntity.Precio.ToString();

                        this.ddlTAlimetno.DataSource = listaTAlimetno;
                        this.ddlTAlimetno.DataBind();
                        this.setItem(ref this.ddlTAlimetno, baseEntity.TipoAlimento.Nombre);
                        this.setItem(ref this.ddlTProducto, baseEntity.TipoProducto.Nombre);
                        this.setItem(ref this.ddlTCarne, baseEntity.TipoCarne.Nombre);
                    }


                    this.ddlTAlimetno.SelectedIndexChanged += new EventHandler(ddlTAlimento_SelectedIndexChanged);
                    this.ddlTAlimetno.AutoPostBack = true;

                    this.ddlTProducto.SelectedIndexChanged += new EventHandler(ddlTProducto_SelectedIndexChanged);
                    this.ddlTProducto.AutoPostBack = true;
                    this.ddlTCarne.SelectedIndexChanged += new EventHandler(ddlTCarne_SelectedIndexChanged);
                    this.ddlTAlimetno.AutoPostBack = true;

                }
            }
            catch (Exception _e)
            {
                this.Response.Redirect("~/VistaGenerica.aspx", false);
            }
        }



        //////////////////////////////////////////////
       ////pageLoad^
       ////////////////////////////////////////////////////////
        public void setItem(ref DropDownList _control, String _value)
        {
            foreach (ListItem item in _control.Items)
            {
                if (item.Value == _value)
                {
                    item.Selected = true;
                    break;
                }
            }
            _control.Items.FindByText(_value).Selected = true;
        }


        protected void ddlTAlimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTAlimento = int.Parse(this.ddlTAlimetno.Text);
                Expression<Func<TipoAlimento, bool>> predicateTAlimento = c => c.IdTAlimento == idTAlimento;
                predicateTAlimento.Compile();
                List<TipoAlimento> lista = dcGlobal.GetTable<TipoAlimento>().Where(predicateTAlimento).ToList();
                TipoAlimento catTemp = new TipoAlimento();
                this.ddlTAlimetno.DataTextField = "Nombre";
                this.ddlTAlimetno.DataValueField = "IdTAlimento ";
                this.ddlTAlimetno.DataSource = lista;
                this.ddlTAlimetno.DataBind();
            }
            catch (Exception)
            {
                // this.showMessage("Ha ocurrido un error inesperado");
            }
        }

        protected void ddlTProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTProducto = int.Parse(this.ddlTProducto.Text);
                Expression<Func<TipoProducto, bool>> predicateTProducto = c => c.IdTProducyo == idTProducto;
                predicateTProducto.Compile();
                List<TipoProducto> lista = dcGlobal.GetTable<TipoProducto>().Where(predicateTProducto).ToList();
                TipoProducto catTemp = new TipoProducto();
                this.ddlTProducto.DataTextField = "Nombre";
                this.ddlTProducto.DataValueField = "IdTProductyo";
                this.ddlTProducto.DataSource = lista;
                this.ddlTProducto.DataBind();
            }
            catch (Exception)
            {
                // this.showMessage("Ha ocurrido un error inesperado");
            }
        }

        protected void ddlTCarne_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTCarne = int.Parse(this.ddlTCarne.Text);
                Expression<Func<TipoCarne, bool>> predicateTCarne = c => c.IdTCarne == idTCarne;
                predicateTCarne.Compile();
                List<TipoCarne> lista = dcGlobal.GetTable<TipoCarne>().Where(predicateTCarne).ToList();
                TipoProducto catTemp = new TipoProducto();
                this.ddlTProducto.DataTextField = "Nombre";
                this.ddlTProducto.DataValueField = "IdTCarne";
                this.ddlTProducto.DataSource = lista;
                this.ddlTProducto.DataBind();
            }
            catch (Exception)
            {
                // this.showMessage("Ha ocurrido un error inesperado");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

               // bool bacio = false;
                if ((txtNombre.Text.Equals(String.Empty))&&(txtPrecio.Text.Equals(String.Empty))&& (int.Parse(ddlTProducto.SelectedValue)==-1)
                    &&(int.Parse(ddlTAlimetno.SelectedValue) == -1)&&(int.Parse(ddlTCarne.SelectedValue) == -1)) {

                    this.Response.Redirect("~/VistaGenerica.aspx", false);

                }

              //
                this.revNombre.Validate();
                this.revprecio.Validate();

                this.rfvNombre.Validate();
                this.RequiredFieldValidator1.Validate();



                DataContext dcGuardar = new DcGeneralDataContext();
                Producto producto = new Producto();
                if (this.idProducto == 0)
                {


                    producto.NombreProducto = this.txtNombre.Text.Trim();
                    producto.Precio =decimal.Parse( this.txtPrecio.Text.Trim());
                  
                    producto.TAlimentoId = int.Parse(this.ddlTAlimetno.Text);
                    producto.TProductoId = int.Parse(this.ddlTProducto.Text);
                    producto.TCarneID = int.Parse(this.ddlTCarne.Text);


                    String mensaje = String.Empty;
                    if (this.Bacio(producto))
                    {

                        this.regresar();
                    }
                    //  !this.revCURP.IsValid
                    if (!formatosValidos(ref mensaje))
                    {

                        this.lblMensaje.Text = mensaje;
                        this.lblMensaje.Visible = true;
                        return;
                    }




                    if (!this.validacion(producto, ref mensaje))
                    {
                        ////Validacion de datos correctos desde código
                        this.lblMensaje.Text = mensaje;
                        this.lblMensaje.Visible = true;
                        return;
                    }



                    dcGuardar.GetTable<Producto>().InsertOnSubmit(producto);
                    dcGuardar.SubmitChanges();
                    //this.showMessage("El registro se agrego correctamente.");
                    this.Response.Redirect("~/VistaGenerica.aspx", false);

                }
                if (this.idProducto > 0)
                {

                    producto = dcGuardar.GetTable<Producto>().First(c => c.IdProducto == idProducto);
                    producto.NombreProducto = this.txtNombre.Text.Trim();
                    producto.Precio = decimal.Parse(this.txtPrecio.Text.Trim());

                    producto.TAlimentoId = int.Parse(this.ddlTAlimetno.Text);
                    producto.TProductoId = int.Parse(this.ddlTProducto.Text);
                    producto.TCarneID = int.Parse(this.ddlTCarne.Text);
                    ////////////////////////////
                    //editar///////////////////
                    ///////////////////////////
                    String mensaje = String.Empty;
                    if (this.Bacio(producto))
                    {

                        this.regresar();
                    }
                    //  !this.revCURP.IsValid
                    if (!formatosValidos(ref mensaje))
                    {

                        this.lblMensaje.Text = mensaje;
                        this.lblMensaje.Visible = true;
                        return;
                    }




                    if (!this.validacion(producto, ref mensaje))
                    {
                        ////Validacion de datos correctos desde código
                        this.lblMensaje.Text = mensaje;
                        this.lblMensaje.Visible = true;
                        return;
                    }









                    dcGuardar.SubmitChanges();
                  //  this.showMessage("El registro se edito correctamente.");
                    this.Response.Redirect("~/VistaGenerica.aspx", false);
                }
            }
            catch (Exception _e)
            {
               // this.showMessageException(_e.Message);


            }



        }


        public bool Bacio(Producto _producto)
        {

            try
            {

                if (_producto.IdProducto != -1)
                {
                    return false;

                }

                if (!(_producto.NombreProducto.Equals (string.Empty)))
                {
                    return false;

                }

                if (!(_producto.Precio != -1))
                {

                    return false;

                }

                if (!(_producto.TAlimentoId != -1))
                {
                    return false;
                }

                if (!(_producto.TCarneID != -1))
                {

                    return false;
                }

                if (!(_producto.TProductoId != -1))
                {
                    return false;
                }

               
                return true;


            }
            catch (Exception e)
            {


            }
            return false;
        }

        public void regresar()
        {
            this.Response.Redirect("~/VistaGenerica.aspx", false);

        }

        public bool formatosValidos(ref String _mensaje)
        {



            if (!this.revNombre.IsValid)
            {
                _mensaje = "Formato de Nombre invalido";
                return false;
            }

            if (!this.rfvNombre.IsValid)
            {
                _mensaje = "Formato de Nombre invalido";
                return false;
            }

            if (!this.revprecio.IsValid)
            {
                _mensaje = "Formato de precio invalido";
                return false;

            }

            if (!this.RequiredFieldValidator1.IsValid)
            {
                _mensaje = "Formato de Precio invalido";
                return false;
            }

            return true;
        }

        public bool validacion(Producto _producto, ref String _mensaje)
        {
            if (_producto.TProductoId == -1)
            {
                _mensaje = "Seleccione Tipo un Tipo de Producto";
                return false;
            }


            if (_producto.TCarneID == -1 && _producto.TProductoId==1)
            {
                _mensaje = "Seleccione Tipo un Tipo de Carne";
                return false;
            }


            if (_producto.TAlimentoId == -1 && _producto.TProductoId == 1)
            {
                _mensaje = "Seleccione Tipo un Tipo de alimento";
                return false;
            }



            if (_producto.TCarneID != -1 && _producto.TProductoId == 5)
            {
                _mensaje = "No puede seleccionar carne si el tipo de producto es vevida";
                return false;
            }


            if (_producto.TAlimentoId != -1 && _producto.TProductoId == 5)
            {
                _mensaje = "No puede seleccionar Tipo de alimetno si el tipo de producto es vevida";
                return false;
            }


            decimal i = 0;

            

            if ((decimal.TryParse(_producto.Precio+"", out i) == false))
            {
                _mensaje = "El precio no es un número";
                return false;
            }

            if (_producto.Precio < 5 || _producto.Precio > 99)
            {
                _mensaje = "La Clave Unica esta fuera de rango";
                return false;
            }
            if (_producto.NombreProducto.Equals(String.Empty))
            {
                _mensaje = "El campo Nombre está vacio";
                return false;
            }
            if (_producto.NombreProducto.Length > 45)
            {
                _mensaje = "Los caracteres permitidos para nombre rebasan lo establecido de 45";
                return false;
            }

            if (_producto.NombreProducto.Length < 6)
            {
                _mensaje = "el nombre deve tener mas de 6 caracteres";
                return false;
            }

            
            return true;



        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("~/VistaGenerica.aspx", false);

            }
            catch (Exception _e)
            {
            //    this.showMessage("Ha ocurrido un error inesperado");
            }
        }

    }
}