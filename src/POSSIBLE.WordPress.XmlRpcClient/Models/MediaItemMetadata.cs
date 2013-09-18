using CookComputing.XmlRpc;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct MediaItemMetadata
    {
        public string width { get; set; }
        public string height { get; set; }
        public string file { get; set; }
        public MediaItemSizes sizes { get; set; }         
    }
}
