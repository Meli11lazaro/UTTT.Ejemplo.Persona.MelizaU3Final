<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarContraseñaManager.aspx.cs" Inherits="UTTT.Ejemplo.Persona.Views.RecuperarContraseñaManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src='//production-assets.codepen.io/assets/editor/live/console_runner-079c09a0e3b9ff743e39ee2d5637b9216b3545af0de366d4b9aad9dc87e26bfd.js'>
    </script><script src='//production-assets.codepen.io/assets/editor/live/events_runner-73716630c22bbc8cff4bd0f07b135f00a0bdc5d14629260c3ec49e5606f98fdd.js'></script>
    <script src='//production-assets.codepen.io/assets/editor/live/css_live_reload_init-2c0dc5167d60a5af3ee189d570b1835129687ea2a61bee3513dee3a50c115a77.js'></script>
    <link rel="shortcut icon" type="image/x-icon" href="//production-assets.codepen.io/assets/favicon/favicon-8ea04875e70c4b0bb41da869e81236e54394d63638a1ef12fa558a4a835f1164.ico" />
    <link rel="mask-icon" type="" href="//production-assets.codepen.io/assets/favicon/logo-pin-f2d2b6d2c61838f7e76325261b7195c27224080bc099486ddd6dccb469b8e8e6.svg" color="#111" />
    <link rel="canonical" href="https://codepen.io/dpinnick/pen/LjdLmo?limit=all&page=21&q=service" />
    <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css'/>
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <link href="../css/LoginStile.css" rel="stylesheet" />
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script src='//production-assets.codepen.io/assets/common/stopExecutionOnTimeout-b2a7b3fe212eaa732349046d8416e00a9dec26eb7fd347590fbced3ab38af52e.js'>
    </script><script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js'></script>

    <script src="../Scripts/LoginSCRIPT.js"></script>
<style class="cp-pen-styles">@import url(https://fonts.googleapis.com/css?family=Raleway:400,100,200,300);
</style>

</head>
<body>
    <!-- LOGIN MODULE -->
            <div class="login">
                <div class="wrap">
                    <!-- TOGGLE -->
                    <div id="toggle-wrap">
                        <div id="toggle-terms">
                            <div id="cross">
                                <span></span>
                                <span></span>
                            </div>
                        </div>
                    </div>
                   
                    <!-- SLIDER -->
                    <div class="content">
                        <!-- LOGO -->
                        <div class="logo">
                            <a href="#"><img src="https://res.cloudinary.com/dpcloudinary/image/upload/v1506186248/logo.png" alt=""/></a>
                        </div>
                        <!-- SLIDESHOW -->
                        <div id="slideshow">
                            <div class="one">
                                <h2><span>YA APROBE</span></h2>
                                <p>Ojala que si</p>
                            </div>
                            <div class="three">
                                <h2><span>Digame que si</span></h2>
                                <p>Hola profe ya paseme porfavor :(</p>
                            </div>
                        </div>
                    </div>
                    <!-- LOGIN FORM -->
                    <div class="user">
                        <div class="form-wrap">
                            <!-- TABS -->
                            <div class="justify-content-md-center">
                                <h3 class="login-tab log-in active"><a class="log-in active" href="#login-tab-content"><span>Renovacion de contraceña</span></a></h3>
                            </div>
                            <!-- TABS CONTENT -->
                            <div class="tabs-content">
                                <!-- TABS CONTENT LOGIN -->
                                <div id="login-tab-content" class="active">
                                    <form class="login-form" id="form1" runat="server">
                                        
                            <asp:TextBox ID="txtUsuario" runat="server" class="input" placeholder="Nombre de Usuario"> </asp:TextBox> 
                            <asp:TextBox ID="txtContraseña" runat="server" class="input" placeholder="Contraseña"> </asp:TextBox>
                            <asp:TextBox ID="txtRContraseña" runat="server" class="input" placeholder="Repetir Contraseña"> </asp:TextBox>

                        <asp:Button class="button" ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" OnClientClick="return validaciones(); " /> 
                     <br />
                     <asp:Button class="button" ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar"/>
                                    </form>
                                </div>
                               
                            </div>
                        </div>
                    </div>
                     <div class="mb-2">
                       <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                 </div>
                </div>
            </div>
</body>
</html>
