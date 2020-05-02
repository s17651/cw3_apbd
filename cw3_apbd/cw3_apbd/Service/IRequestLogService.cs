using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw3_apbd.Service
{
    public interface IRequestLogService
    {
        public void save(HttpRequest request);
    }
}
