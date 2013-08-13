using CookComputing.XmlRpc;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class PostFilter : FilterBase
    {
        public string post_type { get; set; }
        public string post_status { get; set; }
        public string offset { get; set; }
        public string orderby { get; set; }
        public string order { get; set; }
    }
}