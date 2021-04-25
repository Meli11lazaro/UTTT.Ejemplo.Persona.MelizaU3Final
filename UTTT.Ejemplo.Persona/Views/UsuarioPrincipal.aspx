<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioPrincipal.aspx.cs" Inherits="UTTT.Ejemplo.Persona.Views.UsuarioPrincipal" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-giJF6kkoqNQ00vy+HMDP7azOuL0xtbfIcaT9wjKHr8RbDVddVHyTfAAsrekwKmP1" crossorigin="anonymous" />
</head>
<body class="bg-light">
    <div class="container-fluid">
        <form id="form1" runat="server">
              <asp:ScriptManager ID="ScriptManager1"
                runat="server" />
            <div>
                <div style="font-family: Arial; font-size:smaller; font-weight: bold">
                    <h1 class="text-center">Nombre Del Usuario:
                        <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                    </h1>
                </div>
                <br />
                 
                     <asp:UpdatePanel ID="paneltxtName" runat="server">
                             <ContentTemplate>
                                 <asp:Button style="display: none;" ID="btnTrick" runat="server" OnClick="btnTrick_Click"/>
                             </ContentTemplate>
                        </asp:UpdatePanel>
         <div>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Nombre Usuario:&nbsp;&nbsp;&nbsp;

       <div style="margin-left: 80px">
           <asp:TextBox ID="txtNombre" runat="server"
                           Height="40px" Width="253px" ViewStateMode="Disabled" Class="form-control" placeholder="Usuario" OnTextChanged="txtNombre_TextChanged" MaxLength="20" ></asp:TextBox>
        </div>  
    </p>
    </div>

                    <div>
        <div>    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Estado:&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
       <div style="margin-left: 80px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlEstado" runat="server" Height="40px" Width="253px" Class="form-control">
                        </asp:DropDownList>
    </div>
    </div>
                    <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
         <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
            onclick="btnBuscar_Click" ViewStateMode="Disabled" class="btn btn-primary"/>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
            onclick="btnAgregar_Click" ViewStateMode="Disabled" class="btn btn-warning"/>
        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BtnRegresar" runat="server" Text="Inicio" 
                            Class="btn btn-success" OnClick="BtnRegresar_Click"/>
                    <div class="col-md-2">

                        

                    </div>
                
                 <div style="font-weight: bold" class="mt-4">
                        <h3 class="text-center">Detalle
                        </h3>
                    </div>
                  <div style="margin-left: 10px" class="table-responsive">
                     
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        &nbsp;
                                        <asp:GridView ID="dgvUsuarios" runat="server" AutoGenerateColumns="False" DataSourceID="DataSourceUsuario" 
                                            OnRowCommand="dgvUsuarios_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1067px" 
                                            CellPadding="3" GridLines="Horizontal" BackColor="White" 
                                             BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                                             ViewStateMode="Disabled" class="table table-striped">
                                            <Columns>
                                                <asp:BoundField DataField="Persona.strNombre" HeaderText="Nombre Persona" ReadOnly="True" SortExpression="Persona.strNombre" />
                                                <asp:BoundField DataField="strUsuario" 
                                                    HeaderText="Nombre Usuario" ReadOnly="True" SortExpression="strUsuario" />
                                                <asp:BoundField DataField="dteFechaRegistro" HeaderText="Fecha Registro" ReadOnly="True" SortExpression="dteFechaRegistro" />
                                                <asp:BoundField DataField="CatStatusUsuario.strValor" HeaderText="Estado" ReadOnly="True" SortExpression="CatStatusUsuario.strValor" />
                                                <asp:TemplateField HeaderText="Editar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton runat="server" ID="imgEditar" CommandName="Editar" CommandArgument='<%#Bind("id") %>' ImageUrl="~/Images/editrecord_16x16.png" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Eliminar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton runat="server" ID="imgEliminar" CommandName="Eliminar" CommandArgument='<%#Bind("id") %>' ImageUrl="~/Images/delrecord_16x16.png" OnClientClick="javascript:return confirm('¿Está seguro de querer eliminar el registro seleccionado?', 'Mensaje de sistema')" />
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

                                        <asp:LinqDataSource ID="DataSourceUsuario" runat="server" ContextTypeName="UTTT.Ejemplo.Linq.Data.Entity.DcGeneralDataContext" EntityTypeName="" Select="new (strNombrePersona, strUsuario, CatValorUsuario, dteFechaRegistro, CatStatusUsuario, Persona, id)" TableName="Usuario" OnSelecting="DataSourceUsuario_Selecting">
                                        </asp:LinqDataSource>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                  
                                </div>
                            
            </div>
        </form>
           <script type="text/javascript">
           
            document.querySelector('#txtNombre').addEventListener('keyup',  () => {
                const btnTrick = document.querySelector('#btnTrick');
                //  console.log(nombre);
                btnTrick.click();
            });
        </script>
    </div>
</body>
</html>
