using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductMS.Models.Common
{
    public class OperationResult
    {
        public OperationResult()
        {
            IsSuccess = true;
            Errors = new List<string>();

        }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }

        public string Message { get; set; }

        public static OperationResult<T> From<T>(T t)
        {
            var result = new OperationResult<T>(t);
            return result;
        }
    }
}
