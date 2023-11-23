using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Coding.Assignment.Utils
{
    public class Constant
    {
        public static class EndPoints
        {
            public const string CreateAccount = "/create";
            public const string DeleteAccount = "/delete/{AccountNo}";
            public const string DepositeAmount = "/deposit";
            public const string WithdrawAmount = "/withdraw";
        }

    }
}
