<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TaqueriaTadeos.Vistas.Productos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <title></title>
    
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


        <script type="text/javascript">
        $(document).ready(function () {

                 $('#Button2').click(function () {
                   $('#exampleModalLong').modal('show');
                 });
             
             
             });

        </script>
</head>
<body>
 
    <form id="form1" runat="server">

         <div>
            <!-- Button trigger modal -->
  <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal1">
  Launch demo modal
</button>

<!-- Modal -->
<div class="modal fade" id="exampleModal1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
       <!-- Cuerpo -->
           <h2>Productos</h2>

            <label>Nombre</label>
                    <asp:TextBox ID="NombreModal" runat="server" Width="174px" 
            ViewStateMode="Disabled" AutoPostBack="true"></asp:TextBox>

          <br />
           <label>Tipo Alimento</label>
          <asp:DropDownList ID="ddlTAlimentoModal" runat="server" Width="177px" OnSelectedIndexChanged="ddlTProducto_SelectedIndexChanged">
        </asp:DropDownList>
  <br />
         
       
       <label>Tipo Producto</label>
        <asp:DropDownList ID="ddlTProductoModal" runat="server" Width="177px">
        </asp:DropDownList>
          <br />
          <label>Tipo Carne</label>
        <asp:DropDownList ID="ddlTipoCarneModal" runat="server" Width="177px">
        </asp:DropDownList>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>
        </div>






             <label>Sucursal</label>
  
        
        <asp:DropDownList ID="ddlSucursales" runat="server" Width="177px" OnSelectedIndexChanged="ddlSucursales_SelectedIndexChanged">
        </asp:DropDownList>




         <div>
            <asp:ScriptManager runat="server" ID="ScriptManager" EnablePageMethods="true"></asp:ScriptManager>
        <div>
            <label>Productosos</label>

            <br />

            <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" Width="174px" 
            ViewStateMode="Disabled" AutoPostBack="true"></asp:TextBox>
        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100" EnableCaching="false"
            MinimumPrefixLength="2" ServiceMethod="txtNombre_textChanged" TargetControlID="txtNombre"></ajaxToolkit:AutoCompleteExtender>
       
            <br />
            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="100" EnableCaching="false"
            MinimumPrefixLength="2" ServiceMethod="txtNombre_textChanged" TargetControlID="txtNombre"></ajaxToolkit:AutoCompleteExtender>
       
            <br />

                    
    </div>
          <div class="row">

<div class="col-lg-3 col-md- col-sm-6 col-xs-6">
          <label>Tipo Alimento</label>
    </div>
         <div class="col-lg-3 col-md- col-sm-6 col-xs-6">
        <asp:DropDownList ID="ddlTAlimento" runat="server" Width="177px">
        </asp:DropDownList>
       </div>
        </div>
        <br />
        
        <div class="col-lg-3 col-md- col-sm-6 col-xs-6">
          <label>Tipo Producto</label>
    </div>
         <div class="col-lg-3 col-md- col-sm-6 col-xs-6">
        <asp:DropDownList ID="ddlTProducto" runat="server" Width="177px" OnSelectedIndexChanged="ddlTProducto_SelectedIndexChanged">
        </asp:DropDownList>
             <br />
             <br />
       </div>
    
         <div class="row">
            <br />
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
            onclick="btnBuscar_Click" ViewStateMode="Disabled" Width="177px"/>
        &nbsp;&nbsp;&nbsp;
       
    </div>
              <div class="row">
            <br />
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
            onclick="btnAgregar_Click" ViewStateMode="Disabled" Width="177px"/>
        &nbsp;&nbsp;&nbsp;
       
    </div>
   


            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1"
                
                  OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="NombreProducto" HeaderText="NombreProducto" ReadOnly="True" SortExpression="NombreProducto" />
                    <asp:BoundField DataField="TipoAlimento" HeaderText="Tipo de alimento" ReadOnly="True" SortExpression="TipoAlimento" />
                    <asp:BoundField DataField="TipoProducto" HeaderText="Tipo Producto" ReadOnly="True" SortExpression="TipoProducto" />
                    <asp:BoundField DataField="TipoCarne" HeaderText="Tipo Carne" ReadOnly="True" SortExpression="TipoCarne" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" ReadOnly="True" SortExpression="Precio" />
                    
                      <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                                    <asp:Button runat="server" ID="btnEditar" CommandName="Editar" CommandArgument='<%#Bind("IdProducto") %>' Text="Editar"/>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                    
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                                    <asp:Button runat="server" ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%#Bind("IdProducto") %>' Text="Eliminar"/>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                    
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>



            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Taqueria.Linq.Data.Entity.DcGeneralDataContext" EntityTypeName="" Select="new (IdProducto, TAlimentoId, TProductoId, TCarneID, NombreProducto, TipoAlimento, TipoCarne, TipoProducto, Precio)" TableName="Producto" OnSelecting="LinqDataSource1_Selecting">
            </asp:LinqDataSource>



        </div>
        
   



    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource2">
        <Columns>
             <asp:BoundField DataField="Producto" HeaderText="IdProducto" ReadOnly="True" SortExpression="NombreProducto" />
            <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" ReadOnly="True" SortExpression="Sucursal" />
        </Columns>
         </asp:GridView>

         <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="Taqueria.Linq.Data.Entity.DcGeneralDataContext" EntityTypeName="" Select="new (IdProducto, Producto,IdSucursal, Sucursal)" TableName="ProductoSucursal" OnSelecting="LinqDataSource2_Selecting">
         </asp:LinqDataSource>
        
   



        </form>
    
  

    </body>
</html>
