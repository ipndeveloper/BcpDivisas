using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bcp.Divisas.Core.BaseModels
{
    public class InfoResult<T>  where T :  class
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public T Entity { get; set; }
    }
}
