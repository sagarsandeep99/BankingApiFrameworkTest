using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Accolite.Coding.Assignment.Model.Response.CreateAccountResponse;

namespace Accolite.Coding.Assignment.Model.Response
{
    public class GenericResponse : ResponseBase
    {
        public AccountData AccountData { get; set; }
    }
}
