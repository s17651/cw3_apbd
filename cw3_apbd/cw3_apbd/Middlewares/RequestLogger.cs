using cw3_apbd.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw3_apbd.Middleware
{
    public class RequestLogger
    {
        private readonly RequestDelegate _next;

        public RequestLogger(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IRequestLogService service) 
        {
            
            if (context.Request != null)
            {
                service.save(context.Request);
            }

            if (_next != null)
                await _next(context);
        }
    }
}
