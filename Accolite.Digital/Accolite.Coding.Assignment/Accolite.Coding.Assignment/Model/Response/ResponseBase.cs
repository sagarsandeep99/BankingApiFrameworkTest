﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accolite.Coding.Assignment.Model.Response
{
    public abstract class ResponseBase
    {
        public string Message { get; set; }
        public string[] Error { get; set; }
    }
}
