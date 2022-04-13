<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Caja.aspx.cs" Inherits="TaqueriaTadeos.Vistas.Caja" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link href="Vistas/Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link href="Vistas/Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Vistas/Scripts/jquery-3.4.1.min.js"></script>
    <script src="Vistas/Scripts/bootstrap.min.js"></script>
    <link href="Vistas/Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script type="text/javascript">
     <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Vistas/Scripts/bootstrap.min.js"></script>
    <link href="Vistas/Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
       <asp:ScriptManager runat="server" ID="ScriptManager" EnablePageMethods="true"></asp:ScriptManager>
        <div>
<asp:Label ID="lblsucursal" runat="server" Text="sucursal" Font-Bold="True" Font-Size="30px" Style="align-content: center"></asp:Label>
<br />           
<asp:Label ID="lblUsuario" runat="server" Text="usuario" Font-Bold="True" Font-Size="30px" Style="align-content: center"></asp:Label>



        </div>
        <div class="col-lg-3 col-md- col-sm-6 col-xs-6">
   <label >Nombre</label>
    </div>  
       <div class="col-lg-3 col-md- col-sm-6 col-xs-6">
        <asp:TextBox ID="txtNombre" runat="server" Width="174px" 
            ViewStateMode="Disabled" AutoPostBack="true"></asp:TextBox>
        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="100" EnableCaching="false"
            MinimumPrefixLength="2" ServiceMethod="txtNombre_textChanged" TargetControlID="txtNombre"></ajaxToolkit:AutoCompleteExtender>
       </div>
        <br /> 
        <label >cantidad</label>
<div class="col-lg-3 col-md- col-sm-6 col-xs-6">
        <asp:TextBox ID="txtCantidad" runat="server" Width="174px" 
            ViewStateMode="Disabled" AutoPostBack="true"></asp:TextBox>
        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100" EnableCaching="false"
            MinimumPrefixLength="2" ServiceMethod="txtNombre_textChanged" TargetControlID="txtNombre"></ajaxToolkit:AutoCompleteExtender>
       </div>
        <br />
    <div>


         <label>Tipo Producto</label>
    </div>
         <div class="col-lg-3 col-md- col-sm-6 col-xs-6">
        <asp:DropDownList ID="ddlTAlimento" runat="server" Width="177px">
        </asp:DropDownList>
       </div>
        
        
             <asp:GridView ID="dgvAProductos" runat="server"  AllowPaging="True" AutoGenerateColumns="False" DataSourceID="LinqDataSource2" 
                Width="1067px" CellPadding="3" GridLines="Horizontal" 
                BackColor="White" OnRowCommand="dgvAProducto_RowCommand"
                BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                ViewStateMode="Enabled" >
                <AlternatingRowStyle BackColor="#F7F7F7" />
                  <Columns>
                  
                    <asp:BoundField DataField="NombreProducto" HeaderText="NombreProducto" ReadOnly="True" 
                        SortExpression="NombreProducto"/>
                        <asp:BoundField DataField="Precio" HeaderText="Precio" 
                        ReadOnly="True" SortExpression="Precio" />
                      <asp:BoundField DataField="TipoProducto" HeaderText="TProductoId" ReadOnly="True" SortExpression="TipoProducto" />
                      <asp:BoundField DataField="TipoAlimento" HeaderText="Tipo Alimento" ReadOnly="True" SortExpression="TipoAlimento" />
                      <asp:BoundField DataField="TipoCarne" HeaderText="Tipo de Carne" ReadOnly="True" SortExpression="TipoCarne" />
                      <asp:BoundField DataField="IdProducto" HeaderText="IdProducto" ReadOnly="True" SortExpression="IdProducto" />
                
                   <asp:TemplateField HeaderText="Agregar">
                        <ItemTemplate>
                                    <asp:Button runat="server" ID="btnAgregar" CommandName="Agregar" CommandArgument='<%#Bind("IdProducto") %>' Text="Agregar"/>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                    
                    </asp:TemplateField>
                  </Columns>
             </asp:GridView>
             <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="Taqueria.Linq.Data.Entity.DcGeneralDataContext" EntityTypeName="" OrderBy="IdProducto" Select="new (Precio, NombreProducto, TipoCarne, TipoAlimento, TipoProducto, TProductoId, TAlimentoId, TCarneID, IdProducto)" TableName="Producto" OnSelecting="LinqDataSource2_Selecting">
             </asp:LinqDataSource>
             
        <br />
        <br />
        
           <asp:GridView ID="GridView1" runat="server"  AllowPaging="True" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" 
                Width="1067px" CellPadding="3" GridLines="Horizontal" 
                BackColor="White" 
                BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                ViewStateMode="Enabled" ReadOnly="false">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                  <Columns>
                    
                    <asp:BoundField DataField="idProducto" HeaderText="idProducto" ReadOnly="True" 
                        SortExpression="idProducto"/>
                      <asp:BoundField DataField="PrecioVenta" HeaderText="PrecioVenta" 
                        ReadOnly="True" SortExpression="PrecioVenta" />
                      <asp:BoundField DataField="cantidad" HeaderText="cantidad" ReadOnly="True" SortExpression="cantidad" />
                    
                  </Columns>
             </asp:GridView>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Taqueria.Linq.Data.Entity.DcGeneralDataContext" EntityTypeName="" Select="new (idProducto, PrecioVenta, cantidad, Producto)" TableName="ProductosVenta" OnSelecting="LinqDataSource1_Selecting">
        </asp:LinqDataSource>

     
    </form>


</body>
</html>
