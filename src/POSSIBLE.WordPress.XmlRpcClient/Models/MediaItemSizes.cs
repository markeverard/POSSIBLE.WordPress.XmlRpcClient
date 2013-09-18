using CookComputing.XmlRpc;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct MediaItemSizes
    {
        public MediaItemSize medium { get; set; }
        public MediaItemSize large { get; set; }
        public MediaItemSize thumbnail { get; set; }
        public MediaItemSize post_thumbnail { get; set; }
        public MediaItemSize listing { get; set; }
        public MediaItemSize listing_small { get; set; }
    }
}