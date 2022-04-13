using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using Taqueria.Linq.Data.Entity;

namespace TaqueriaTadeos.Clases
{
    public class ClaseListaProducts
    {

        List<ProductosVenta> productosVenta = new List<ProductosVenta>();

        public List<ProductosVenta> getLista(){

            return productosVenta;
        }

        public void agregar(int _idPersona,int cantidad)
        {


            DataContext dcContext = new DcGeneralDataContext();
            Taqueria.Linq.Data.Entity.Producto productoBusqueda = dcContext.GetTable<Taqueria.Linq.Data.Entity.Producto>().First(
                 c => c.IdProducto == _idPersona);
            try
            {
                ProductosVenta producto = new ProductosVenta();


                producto.idProducto = productoBusqueda.IdProducto;
                producto.PrecioVenta = productoBusqueda.Precio;


                producto.cantidad = cantidad;
                

            
               

           
            }catch (Exception _e)
            {
              
                
            }
        }
    }
}