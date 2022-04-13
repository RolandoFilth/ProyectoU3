<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaGenerica.aspx.cs" Inherits="TaqueriaTadeos.Vistas.VistaGenerica" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
     <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />

     <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager runat="server" ID="ScriptManager" EnablePageMethods="true"></asp:ScriptManager>
        
            <!-- Button trigger modal -->

      

       <div>
           <div class="row">
               <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4"></div>

                <div class="col-lg-4 col-md-4 col-sm-2 col-xs-1">
           <h1>Productos</h1>
                    </div>
               <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4"></div>

            </div>
            <br />

           </div>
               

        <div class="row">
             <div class="col-lg-2 col-md-2 col-sm-2 col-xs-1"></div>
             <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
            
            <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" Width="174px" 
            ViewStateMode="Disabled" AutoPostBack="true"></asp:TextBox>
        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100" EnableCaching="false"
            MinimumPrefixLength="2" ServiceMethod="txtNombre_textChanged" TargetControlID="txtNombre"></ajaxToolkit:AutoCompleteExtender>
       
            <br />
            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="100" EnableCaching="false"
            MinimumPrefixLength="2" ServiceMethod="txtNombre_textChanged" TargetControlID="txtNombre"></ajaxToolkit:AutoCompleteExtender>
       </div>
         
            <br />

                    
    </div>
        
           <br />
           
<div class="row">
<div class="col-lg-2 col-md-2 col-sm-2 col-xs-1"></div>
             <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
            <label>Tipo Alimento</label>
                  <asp:DropDownList ID="ddlTAlimento" runat="server" Width="177px">
        </asp:DropDownList>


                 </div>



</div>
           
           <br />
<div class="row">
              <div class="col-lg-2 col-md-2 col-sm-2 col-xs-1"></div>
             <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
          <label>Tipo Producto</label>
                 <asp:DropDownList ID="ddlTProducto" runat="server" Width="177px" >
        </asp:DropDownList>
       
        </div>

          </div>

           <br />
           
<div class="row">
              <div class="col-lg-2 col-md-2 col-sm-1 col-xs-1"></div>
             <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                <label>Tipo Carne</label>
<asp:DropDownList ID="ddlTipoCarne" runat="server" Width="177px" >
        </asp:DropDownList>
        
          
   </div>
         </div>  

           <br />
           <div class="row">
 <div class="col-lg-2 col-md-2 col-sm-1 col-xs-1"></div>
             <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                
 <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
            onclick="btnBuscar_Click" ViewStateMode="Disabled" Width="177px"/>

            
          <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
            onclick="btnAgregar_Click" ViewStateMode="Disabled" Width="177px"/>
        
                 </div>
           </div>
           
           <br />

           <br />
        <asp:GridView ID="GridView1" CellPadding="3" Width="1067px" RowStyle-BorderColor="Black" GridLines="Horizontal" RowStyle-BorderStyle="Solid" BorderWidth="2px" runat="server" BorderColor="Black" BorderStyle="Solid" AutoGenerateColumns="False" DataSourceID="LinqDataSource1"  onrowcommand="dgvPrductos_RowCommand">
            
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns >
               <asp:BoundField DataField="NombreProducto" HeaderText="NombreProducto" ReadOnly="True" SortExpression="NombreProducto" />
           
                <asp:BoundField DataField="Precio" HeaderText="Precio" ReadOnly="True" SortExpression="Precio" />
                <asp:BoundField DataField="TipoAlimento" HeaderText="Tipo Alimento" ReadOnly="True" SortExpression="TipoAlimento" />
                <asp:BoundField DataField="TipoProducto" HeaderText="Tipo Producto" ReadOnly="True" SortExpression="TipoProducto" />
                <asp:BoundField DataField="TipoCarne" HeaderText="TipoCarne" ReadOnly="True" SortExpression="TipoCarne" />
              <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                                    <asp:Button runat="server" ID="imgEditar" CommandName="Editar" CommandArgument='<%#Bind("IdProducto") %>' Text="Editar"/>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                    
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Eliminar" Visible="True">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="imgEliminar" CommandName="Eliminar" CommandArgument='<%#Bind("IdProducto") %>' Text="Eliminar" OnClientClick="javascript:return confirm('¿Está seguro de querer eliminar el registro seleccionado?', 'Mensaje de sistema')"/>
                            </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                            </asp:TemplateField>    
            
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>


        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Taqueria.Linq.Data.Entity.DcGeneralDataContext" EntityTypeName="" Select="new (IdProducto, Precio, TAlimentoId, TProductoId, TCarneID, NombreProducto, TipoAlimento, TipoCarne, TipoProducto)" TableName="Producto" OnSelecting="LinqDataSource1_Selecting">
        </asp:LinqDataSource>


    </form>




</body>
</html>
