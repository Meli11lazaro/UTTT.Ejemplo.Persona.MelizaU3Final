<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaInicio.aspx.cs" Inherits="UTTT.Ejemplo.Persona.Views.PaginaInicio" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title></title>
    <link href="../css/Site.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"/>
    <link href="css/bootstrap-datetimepicker.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css"/>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <script src="~/Scripts/modernizr-2.8.3.js"></script>

    <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
        <div class="navbar-header">
     <a class="navbar-brand" href="#"><h5>BIENVENIDO</h5></a>
            </div>
     <div class="collapse navbar-collapse" id="navbarNav" >
       <ul class="navbar-nav">
         <li class="nav-item">
           <a class="nav-link" href="../PersonaPrincipal.aspx"><h4>Persona Principal   <i class="bi bi-person"></i></h4><span class="sr-only">(current)</span></a>
         </li>
         <li class="nav-item">
           <a class="nav-link" href="UsuarioPrincipal.aspx"><h4>Usuarios   <i class="bi bi-people"></i></h4><span class="sr-only">(current)</span></a>
         </li>
           <li class="nav-item">
           <a class="nav-link" href="Login.aspx"><h4>Salir    <i class="bi bi-door-open"></i></h4> <span class="sr-only">(current)</span></a>
         </li>
       </ul>
     </div>
   </nav>

</head>
<body class="bg-light">
    <form id="form1" runat="server">
   <div class="container">
       <div class="row mt-1">
           
       </div>
        <div class="row justify-content-md-center  mt-3">
            <div class="col-md-5">
                <div class="efecto">
                <div class="card">
                    <img src="../Images/useer.png" class="card-img-top" alt="persona" height="250" />
                    <div class="sep">
                        <div class="wrapper">
                         <p class="slogan" style="text-align: justify;"><span> Bienvenido selecciona el campo a visitar en la parte superior de la pagina</span>.</p>
                        </div>
                   </div>
                </div>
            </div>
            </div>
        </div>
        <div class="row mt-3">
            <div class="mt-5">
           
            </div>
        </div>
    </div>
    <footer>
        <p>&copy; Meli5g.uttt1128@gmail.com - 18300498@uttt.edu.mx - Formulario de persona manager</p>
    </footer>
    <div class="row mt-3">
        <div class="mt-5">
       
        </div>
    </div>
    </form>
   

</body>
</html>
