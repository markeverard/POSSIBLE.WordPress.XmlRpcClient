using CookComputing.XmlRpc;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class MediaFilter : FilterBase
    {        
        public int offset { get; set; }
        public int parent_id { get; set; }
        public string mime_type { get; set; }
    }
}