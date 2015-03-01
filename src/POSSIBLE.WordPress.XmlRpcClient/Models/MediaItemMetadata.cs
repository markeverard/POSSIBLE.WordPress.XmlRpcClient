using CookComputing.XmlRpc;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct MediaItemMetadata
    {
        public int width { get; set; }
        public int height { get; set; }
        public string file { get; set; }
    }
}
