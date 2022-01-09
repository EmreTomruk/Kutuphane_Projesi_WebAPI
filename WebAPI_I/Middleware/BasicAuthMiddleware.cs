using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_I.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BasicAuthMiddleware
    {
        private string user = "Cevdo";
        private string pwd = "123";

        private readonly RequestDelegate _next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var header = httpContext.Request.Headers["Authorization"];
            var hash = header.ToString().Split(" ")[1];
            var userAndPwd = Encoding.UTF8.GetString(Convert.FromBase64String  (hash));
            var dizi = userAndPwd.Split(":");
            var kullanici = dizi[0];
            var sifre = dizi[1];

            if (user == kullanici && pwd == sifre)
                return _next;/*(httpContext)*/

            return Task.FromResult(0);
            //WriteToFile(userAndPwd);
        }

        private void WriteToFile(string str)
        {
            StreamWriter sw = new StreamWriter("log.txt", true);
            sw.WriteLine(str);
            sw.Close();
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BasicAuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthMiddleware>();
        }
    }
}
