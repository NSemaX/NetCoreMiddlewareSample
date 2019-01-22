using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMiddlewareSample.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IHostingEnvironment hostingEnvironment)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                Log(httpContext, e, hostingEnvironment);
                throw;
            }
        }

        private void Log(HttpContext context, Exception exception, IHostingEnvironment hostingEnvironment)
        {
            var savePath = hostingEnvironment.WebRootPath;
            var now = DateTime.UtcNow;
            var fileName = $"{now.ToString("yyyy_MM_dd")}.log";
            var filePath = Path.Combine(savePath, "logs", fileName);

            // ensure that directory exists
            new FileInfo(filePath).Directory.Create();

            using (var writer = File.CreateText(filePath))
            {
                writer.WriteLine($"{now.ToString("HH:mm:ss")} {context.Request.Path}");
                writer.WriteLine(exception.Message);
            }
        }
    }
}
