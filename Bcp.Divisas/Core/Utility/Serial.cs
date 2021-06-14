using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bcp.Divisas.Core.Utility
{
    public class Serial
    {

        public static string GetId()
        {
            return Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}
