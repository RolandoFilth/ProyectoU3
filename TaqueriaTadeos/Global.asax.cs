using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TaqueriaTadeos
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError().Message;
            SendEmail(ex);
        }
        public static void SendEmail(string Body)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            mail.From = new MailAddress("emaildesdedondeenviar@gmail.com");

            mail.To.Add("17300220@uttt.edu.mx");
            mail.Subject = "Error en el programa";
            mail.Body = Body;

            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587; //465;  //25; 
            smtp.Credentials = new NetworkCredential("rolando.filth@gmail.com", "KAIJUofVAMPIRE84265");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha podido enviar el email", ex.InnerException);
            }
            finally
            {
                smtp.Dispose();
            }

        }
    }
}
