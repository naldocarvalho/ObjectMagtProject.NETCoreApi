using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpenText.ProjectApi.Validations
{
    public class IsAlphanumeric
    {      
        public IsAlphanumeric() { }

        public bool Check(string str)
        {
            bool result = false;
            Regex rg = new Regex("^[a-zA-Z0-9]*$");
            if (rg.IsMatch(str)) result= true;

            return result;
        }
    }
}
