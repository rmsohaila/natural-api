using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starter.Console.Middlewares
{
    public class IntruptJson
    {
        private readonly RequestDelegate _next;

        public IntruptJson(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string bodyAsText = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();
            
            //var injectedRequestStream = new MemoryStream();
            
            //var bytesToWrite = Encoding.UTF8.GetBytes(bodyAsText);

            //injectedRequestStream.Write(bytesToWrite, 0, bytesToWrite.Length);

            //injectedRequestStream.Seek(0, SeekOrigin.Begin);
            
            //httpContext.Request.Body = injectedRequestStream;

            await _next(httpContext);
        }

    }

    public static class IntruptJsonExtensions
    {
        public static IApplicationBuilder UseIntruptJson(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IntruptJson>();
        }
    }
}
