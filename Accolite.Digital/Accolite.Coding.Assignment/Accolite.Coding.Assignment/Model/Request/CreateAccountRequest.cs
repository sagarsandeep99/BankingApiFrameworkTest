using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Coding.Assignment.Model.Request
{
    public class CreateAccountRequest
    {
        public string AccountName { get; set; }
        public long Amount { get; set; }
        public string Address { get; set; }
    }
}
