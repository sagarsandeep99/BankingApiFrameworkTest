using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Coding.Assignment.Model.Response
{
    public class CreateAccountResponse : ResponseBase
    {
        public AccountDataWithName AccountData { get; set; }
    }
}
