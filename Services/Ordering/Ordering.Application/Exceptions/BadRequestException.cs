﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        protected BadRequestException(string message)
           : base("Bad Request", message)
        {
        }
    }
}
