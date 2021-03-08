using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message, bool succes) : base(data, message, succes)
        {

        }
        public SuccessDataResult(T data) : base(data,true)
        {

        }
        public SuccessDataResult(string message) : base(default,true)
        {

        }
        public SuccessDataResult() : base(default, true)
        {

        }


    }
}
