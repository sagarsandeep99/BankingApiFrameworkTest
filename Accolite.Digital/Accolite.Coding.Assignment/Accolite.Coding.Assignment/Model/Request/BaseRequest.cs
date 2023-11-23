using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Coding.Assignment.Model.Request
{
    public class BaseRequest 
    {
        public string AccountNumber { get; set; }
        public long Amount { get; set; }
    }
}
