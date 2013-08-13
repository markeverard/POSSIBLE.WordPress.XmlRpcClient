using CookComputing.XmlRpc;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class MediaFilter : FilterBase
    {
        public string offset { get; set; }
        public string parent_id{ get; set; }
        public string mime_type { get; set; }
    }
}