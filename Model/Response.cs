using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Model
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string  Token { get; set; }
    }
}
