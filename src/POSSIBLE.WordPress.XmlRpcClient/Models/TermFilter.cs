namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    public class TermFilter : FilterBase
    {
        public TermFilter()
        {
            order = "ASC";
            orderby = "Title";
            search = string.Empty;
        }

        public int offset { get; set; }
        public string orderby { get; set; }
        public string order { get; set; }
        public bool hide_empty { get; set; }
        public string search { get; set; } 
    }
}