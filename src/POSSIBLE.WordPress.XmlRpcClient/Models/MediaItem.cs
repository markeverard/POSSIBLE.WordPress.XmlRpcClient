using System;
using CookComputing.XmlRpc;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    /// <summary>
    /// Represents a WordPress media item object
    /// </summary>
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct MediaItem
    {
        public string attachment_id { get; set; }
        public DateTime date_created_gmt { get; set; }
        public int parent { get; set; }
        public string link { get; set; }
        public string title { get; set; }
        public string caption { get; set; }
        public string description { get; set; }
//        public MediaItemMetadata metadata { get; set; }
        public string thumbnail { get; set; }
    }
}