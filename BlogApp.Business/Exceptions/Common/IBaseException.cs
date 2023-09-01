﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exceptions.Common
{
    public interface IBaseException
    {
        public int StatusCode { get; }
        public string ErrorMessage { get; } 
    }
}
