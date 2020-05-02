using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw3_apbd.Tools
{
    public class IndexValidator
    {
        public static Boolean validate(String indexNumber) {
            if (Regex.Match(indexNumber, "^s[0-9]+$").Success)
                return true;
            return false;
        }
    }
}
