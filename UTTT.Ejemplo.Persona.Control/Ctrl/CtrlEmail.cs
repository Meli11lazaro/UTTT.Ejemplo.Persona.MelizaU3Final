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
