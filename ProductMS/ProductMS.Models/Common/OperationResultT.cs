using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Models.Common
{
    public class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }

        public OperationResult() : base()
        {

        }

        public OperationResult(T t) : base()
        {
            Data = t;
        }
    }
}
