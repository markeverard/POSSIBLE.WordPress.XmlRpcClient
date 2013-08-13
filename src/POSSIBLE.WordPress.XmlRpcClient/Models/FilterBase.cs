namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    public abstract class FilterBase
    {
        protected FilterBase()
        {
            number = int.MaxValue;
        }

        public int number { get; set; }
    }
}