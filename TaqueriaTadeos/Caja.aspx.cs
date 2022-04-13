using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taqueria.Linq.Data.Entity;
using TaqueriaTadeos.Clases;

namespace TaqueriaTadeos.Vistas
{
 
    public partial class Caja : System.Web.UI.Page
    {
        List<ProductosVenta> productosList = new List<ProductosVenta>();

        ProductosVenta product0= new ProductosVenta();
        int Lugar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

           
            try
            {
                Response.Buffer = true;
                DataContext dcTemp = new DcGeneralDataContext();
                if (!this.IsPostBack)
                {
                    List<TipoAlimento> lista = dcTemp.GetTable<TipoAlimento>().ToList();
                    //CatSexo catTemp = new CatSexo();
                    TipoAlimento tAlimento = new TipoAlimento();

                    tAlimento.IdTAlimento = -1;
                    tAlimento.Nombre = "Todos";
                    lista.Insert(0, tAlimento);
                    this.ddlTAlimento.DataTextField = "Nombre";
                    this.ddlTAlimento.DataValueField = "IdTAlimento";
                    this.ddlTAlimento.DataSource = lista;
                    this.ddlTAlimento.DataBind();
                }
            }
            catch (Exception _e)
            {
                Console.WriteLine("Ha ocurrido un problema al cargar la página");
            }
        }



        protected void dgvAProducto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int idProducto = int.Parse(e.CommandArgument.ToString());
                switch (e.CommandName)
                {
                    case "Agregar":


                        //dgvAProductos.DeleteRow(1);
                        //      this.editar(idPersona);

                       agregar(idProducto);

                        break;
                    case "Eliminar":
                        //      this.eliminar(idPersona);
                        break;
                    case "Direccion":
                        //    this.direccion(idPersona);
                        break;
                }
            }
            catch (Exception _e)
            {
                //this.showMessage("Ha ocurrido un problema al seleccionar");
            }
        }
       

        protected void onTxtNombreTextChange(object sender, EventArgs e)
        {
            try
            {

                //  this.DataSourcePersona.RaiseViewChanged();

            }
            catch (Exception ex)
            {


            }

        }
       


         protected void LinqDataSource2_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            try
            {
                DataContext dcConsulta = new DcGeneralDataContext();
                bool nombreBool = false;
                bool sexoBool = false;
                if (!this.txtNombre.Text.Equals(String.Empty))
                {
                    nombreBool = true;
                }
                if (this.ddlTAlimento.Text != "-1")
                {
                    sexoBool = true;
                }

                Expression<Func<Taqueria.Linq.Data.Entity.Producto, bool>>
                    predicate =
                    (c =>
                    ((sexoBool) ? c.TAlimentoId == int.Parse(this.ddlTAlimento.Text) : true) &&
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


        private void agregar(int _idPersona)
        {

            int cantidad = 0;
            List<ProductosVenta> productos2 = new List<ProductosVenta>(); 
            productos2 = productosList;
            try
            {


                if (txtCantidad.Text.Equals(String.Empty))
                {
                    cantidad = 1;
                }
                else
                {
                    cantidad = int.Parse(txtCantidad.Text);
                }
                DataContext dcContext = new DcGeneralDataContext();
                Taqueria.Linq.Data.Entity.Producto productoBusqueda = dcContext.GetTable<Taqueria.Linq.Data.Entity.Producto>().First(
                     c => c.IdProducto == _idPersona);

                ProductosVenta producto = new ProductosVenta();


                product0.idProducto = productoBusqueda.IdProducto;
                product0.PrecioVenta = productoBusqueda.Precio;


                product0.cantidad = cantidad;
                Lugar ++;
                //this.LinqDataSource1.RaiseViewChanged();
                this.productosList.Insert(Lugar, product0);
                //productos2 = productosList;
               
                
                this.LinqDataSource1.RaiseViewChanged();
            }
            catch (Exception _e)
            {
                SendEmail(_e.Message);
                throw _e;
            }
        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
           
            try
            {
               
             //   prod.idProducto = 4;
               e.Result = this.productosList;

            }
            catch (Exception ex)
            {


            }


            }

       
            public static void SendEmail(string Body)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            mail.From = new MailAddress("emaildesdedondeenviar@gmail.com");

            mail.To.Add("17300220@uttt.edu.mx");
            mail.Subject = "Error en el programa";
            mail.Body = Body;

            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587; //465;  //25; 
            smtp.Credentials = new NetworkCredential("rolando.filth@gmail.com", "KAIJUofVAMPIRE84265");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha podido enviar el email", ex.InnerException);
            }
            finally
            {
                smtp.Dispose();
            }

        }


      

    }
}