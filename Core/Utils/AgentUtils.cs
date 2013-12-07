using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Utils
{
    public static class AgentUtils
    {
        public static long GetPaymentSymbol()
        { 
            Random rndNum = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));

            long rnd = rndNum.Next(100000000, 999999999);

            return rnd;
        }
    }
}
