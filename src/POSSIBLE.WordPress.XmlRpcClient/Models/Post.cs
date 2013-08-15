using System;
using CookComputing.XmlRpc;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    /// <summary>
    /// Represents a WordPress post item
    /// </summary>
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Post
    {
        public string post_id { get; set; }
        public string post_title { get; set; }
        public string post_status { get; set; }
        public DateTime post_date { get; set; }
        public string post_content { get; set; }
        public string post_author { get; set; }
        public Term[] terms { get; set; }
        public CustomFields[] custom_fields { get; set; }
        public Enclosure enclosure { get; set; }

        public MediaItem[] media_items { get; set; }

        //public IEnumerable<Tag> Tags { get; set; }
    }
}