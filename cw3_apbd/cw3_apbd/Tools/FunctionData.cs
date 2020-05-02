using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw3_apbd.Tools
{
    public class FunctionData
    {
        public Boolean status { set; get; }
        public string message { set; get; }
        public Object resultObject { set; get; }


        public FunctionData(Boolean status)
        {
            this.status = status;
        }
    }
}
