using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success)
        { //readonly'ler constractor'da set edilebilir.
            Message = message;  
        }
        //overload 
        public Result(bool success)
        { //readonly'ler constractor'da set edilebilir.
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; } 
    }
}
