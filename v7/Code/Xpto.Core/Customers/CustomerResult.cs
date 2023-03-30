namespace Xpto.Core.Customers
{
    public class CustomerResult<T>
    {
        public T Result { get; set; }
        public IList<string> Messages { get; set; }
    }
}