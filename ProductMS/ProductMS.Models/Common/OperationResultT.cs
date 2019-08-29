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
