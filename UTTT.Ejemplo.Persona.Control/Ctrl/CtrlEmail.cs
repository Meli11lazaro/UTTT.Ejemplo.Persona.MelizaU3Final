using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
namespace UTTT.Ejemplo.Persona.Control.Ctrl
{
   public class CtrlEmail
    {
        public bool recoveryPasswordEmail(String email, String name, String token)
        {
            try
            {
                /*
                  //Obtenemos el servidor smtp del archivo de configuración.
                 var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                 string strHost = smtpSection.Network.Host;
                 int port = smtpSection.Network.Port;
                 string strUserName = smtpSection.Network.UserName;
                 string strFromPass = smtpSection.Network.Password;

                 //Proporcionamos la información de autenticación al servidor de Gmail
                 SmtpClient smtp = new SmtpClient(strHost, port);
                 MailMessage msg = new MailMessage();

                 //Creamos el contenido del correo. 
                 string body = "<h1>Error" + ex.Message + "</h1>";
                 msg.From = new MailAddress(smtpSection.From, "TRABAJO");
                 msg.To.Add(new MailAddress("18300520@uttt.edu.mx"));
                 msg.Subject = "Correo";
                 msg.IsBodyHtml = true;
                 msg.Body = body;

                 //Enviamos el correo
                 smtp.Credentials = new NetworkCredential(strUserName, strFromPass);
                 smtp.EnableSsl = true;
                 smtp.Send(msg);
                 */
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                mailMessage.From = new MailAddress("18300498@uttt.edu.mx");
                mailMessage.To.Add(new MailAddress(email));
                mailMessage.Subject = "Recuperar contraseña";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = this.enviarCorreo(name, token);
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("18300498@uttt.edu.mx", "MLH5825M");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception _e)
            {

                return false;
            }
        }
        private String enviarCorreo(String name, String token)
        {
            String prodUrl = "http://melizalazaro-001-site1.dtempurl.com/Views/RecuperarContraseñaManager.aspx?token=" + token;
            String body = "<h2>Hola " + name + "</h2><br>" +
                "<p>¿Quieres restablecer tu contraseña? Accede a este Link" +
                " </p>" +
                "<a href='" + prodUrl + "'>Restablecer contraseña</a>";
            return body;

        }
    }
}
