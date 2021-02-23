using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MGP.CI.SEGURIDAD.Negocio
{
    public class UtilidadBL
    {
        public static string GetCodigoAleatorio()
        {
            Random r = new Random();
            var chars = "ABCDEFGHIJKLMNPRST123456789";
            return new string(chars.Select(c => chars[r.Next(chars.Length)]).Take(6).ToArray());
        }

        public static string EncriptarSHA512(string cad)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(cad);
            byte[] result;

            SHA512Managed shaM = new System.Security.Cryptography.SHA512Managed();
            result = shaM.ComputeHash(data);
            return  BitConverter.ToString(result).Replace("-", string.Empty);
        }

        public static bool EnviarMail(string CorreoDestino, string Asunto, string Mensaje, MailPriority Prioridad, ref string errSms)
        {
            string Servidor = "mail.marina.mil.pe";
            string UsuarioRemite = "helpdesk@marina.mil.pe";
            string Clave = "";

            bool result = false;
            MailMessage mailMessage = new MailMessage();
            string[] array = null;
            mailMessage.From = new MailAddress(UsuarioRemite);
            array = CorreoDestino.Split(';');
            string[] array2 = array;
            foreach (string text in array2)
            {
                if (text != "")
                {
                    mailMessage.To.Add(text);
                }
            }
            mailMessage.Subject = Asunto;
            mailMessage.Body = Mensaje;
            mailMessage.IsBodyHtml = false;
            mailMessage.Priority = Prioridad;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = Servidor;
            smtpClient.Credentials = new NetworkCredential(UsuarioRemite, Clave);
            try
            {
                smtpClient.Send(mailMessage);
                result = true;
            }
            catch (Exception ex)
            {
                //errSms = ex.Message;
                errSms = "Ocurrió un error al enviar SMS, por favor intente nuevamente.";
            }
            return result;
        }
    }
}
