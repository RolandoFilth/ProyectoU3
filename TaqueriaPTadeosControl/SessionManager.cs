using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaqueriaPTadeosControl
{
   public class SessionManager
    {


        private int idProducto;
        private bool accionAgregar = false;
        private bool accionEditar = false;
        private int idManager = 0;

        public int IdManager
        {
            get { return idManager; }
            set { idManager = value; }
        }

        public bool AccionEditar
        {
            get { return accionEditar; }
            set { accionEditar = value; }
        }

        public bool AccionAgregar
        {
            get { return accionAgregar; }
            set { accionAgregar = value; }
        }


        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        private String strNombrePersona;

        public String NombreProducto
        {
            get { return NombreProducto; }
            set { NombreProducto = value; }
        }
        private String pantalla;

        public String Pantalla
        {
            get { return pantalla; }
            set { pantalla = value; }
        }

        private Hashtable parametros;

        public Hashtable Parametros
        {
            get
            {
                if (parametros == null)
                {
                    parametros = new Hashtable();
                }
                return parametros;
            }
            set { parametros = value; }
        }
    }
}
