<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductoManager.aspx.cs" Inherits="TaqueriaTadeos.ProductoManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script type="text/javascript">
     <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <title></title>




     <script type="text/javascript">

        function validaNumeros(evt) {
            //valida que solo se ingresen numeros en la caja de texto
            var code = (evt.wich) ? evt.wich : evt.keyCode;
            if (code == 8) {
                return true;
            } else if (code >= 48 && code <= 57) {
                return true;
            } else {
                return false;
            }
        }

        function validaLetras(e) {
            //valida que solo ingrese letras y algunos caracteres especiales
            var regex = new RegExp("^[a-zA-Z ]+$");
            var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
            if (!regex.test(key)) {
                e.preventDefault();
                return false;

            }
        }

        function validaCurp(curp) {
            //valida letras y numeros pero si caracteres especiales ya que se trata del CURP
                var regex = new RegExp("^[a-zA-Z0-9 ]+$");
                var key = String.fromCharCode(!curp.charCode ? curp.which : curp.charCode);
                if (!regex.test(key)) {
                    curp.preventDefault();
                    return false;
                }
            }
        
    </script>

    <script type="text/javascript">
<!--
           function limitDecimalPlaces(e, count) {
  if (e.target.value.indexOf('.') == -1) { return; }
  if ((e.target.value.length - e.target.value.indexOf('.')) > count) {
    e.target.value = parseFloat(e.target.value).toFixed(count);
  }
}

function isNumberKey(evt)
{
  var charCode = (evt.which) ? evt.which : evt.keyCode;
  if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
    return false;

  return true;
}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
         <asp:ScriptManager runat="server" ID="ScriptManager" EnablePageMethods="true"></asp:ScriptManager>
       <div class="col-lg-4 col-md-4 col-sm-2 col-xs-0"></div>
         <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
        <div> 
             <asp:Label ID="lblAccion" runat="server" Text="Accion" Font-Bold="True" Font-Size="30px" Style="align-content: center"></asp:Label>
    
            <div>
            <h2>Producto</h2>

                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        
                    <asp:Label ID="Label1" runat="server" >Nombre</asp:Label>
                    </div>
                     <div class="col-lg-4 col-md-5 col-sm-12 col-xs-12">

             <asp:TextBox ID="txtNombre" runat="server"
                    Width="249px" ViewStateMode="Disabled"
                    onkeypress="return validaLetras(event);"></asp:TextBox>
                </div>
                      <div class="col-lg-4 col-md-3 col-sm-12 col-xs-12"></div>
                  <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="*Incluir solamente letras y espacios" ValidationExpression="[a-zA-Z ]{2,254}"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="*Nombre Obligatorio"></asp:RequiredFieldValidator>
          </div>
              
                         
                     </div>

              </div>
             <div class="row">
              <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
            <asp:Label ID="Label2" runat="server" >Precio</asp:Label>
            </div>
                   <div class="col-lg-4 col-md-5 col-sm-12 col-xs-12">
             <asp:TextBox ID="txtPrecio" runat="server"
                    Width="249px" ViewStateMode="Disabled"
                    oninput="limitDecimalPlaces(event, 2)"  onkeypress="return isNumberKey(event)" ></asp:TextBox>
              </div>
                    <div class="col-lg-4 col-md-3 col-sm-12 col-xs-12"></div>
               <asp:RegularExpressionValidator ID="revprecio" runat="server" ControlToValidate="txtPrecio" ErrorMessage="*Incluir solamente numeros validos" ValidationExpression="^(\d|-)?(\d|,)*\.?\d*$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrecio" ErrorMessage="*Precio no valido"></asp:RequiredFieldValidator>
          
             </div>

            <div class="row">
              <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
           
                 <asp:Label ID="Label4" runat="server" >Tipo Proucto</asp:Label>
                  </div>
                    
                   <div class="col-lg-4 col-md-5 col-sm-12 col-xs-12">
                 <asp:DropDownList ID="ddlTProducto" runat="server"
                                Height="25px" Width="249px">
                            </asp:DropDownList>
                       </div>
                
                    <div class="col-lg-4 col-md-3 col-sm-12 col-xs-12"></div>
            </div>
                    <br />

             <div class="row">
                 
              <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                 <asp:Label ID="Label5" runat="server" >Tipo Alimento</asp:Label>
                  </div> 
                 
                 <div class="col-lg-4 col-md-5 col-sm-12 col-xs-12">

                 <asp:DropDownList ID="ddlTAlimetno" runat="server"
                                Height="25px" Width="249px">
                              
                            </asp:DropDownList>
                     </div>
                 
                    <div class="col-lg-4 col-md-3 col-sm-12 col-xs-12"></div>
            </div>
                    <br />

            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
               
                 <asp:Label ID="Label3" runat="server" >Tipo Carne</asp:Label>
                    </div>
                    

        
                 <div class="col-lg-4 col-md-5 col-sm-12 col-xs-12">
                 <asp:DropDownList ID="ddlTCarne" runat="server"
                                Height="25px" Width="249px">
                            </asp:DropDownList>
                 </div>
                <div class="col-lg-4 col-md-3 col-sm-12 col-xs-12">
                </div>
            </div>
               
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            <br />
             <br/>
             <div>

                 <asp:Button ID="btnAceptar" runat="server" Text="Aceptar"
                 ViewStateMode="Disabled" CausesValidation="false" onclick="btnAceptar_Click" />
            &nbsp;&nbsp;&nbsp;
   
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"
                 ViewStateMode="Disabled" CausesValidation="false" onclick="btnCancelar_Click"/>
            </div>

        </div>

             </div>

              <div class="col-lg-4 col-md-4 col-sm-2 col-xs-0"></div>


    </form>
</body>
</html>
