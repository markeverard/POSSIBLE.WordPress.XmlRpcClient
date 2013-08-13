using CookComputing.XmlRpc;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct MediaItemSize
    {
        public string file { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string mime_type { get; set; }
    }
}