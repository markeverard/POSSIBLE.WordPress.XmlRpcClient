using CookComputing.XmlRpc;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct MediaItemSize
    {
        public string file { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string mime_type { get; set; }
    }
}