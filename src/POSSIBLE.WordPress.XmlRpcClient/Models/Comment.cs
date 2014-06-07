using System;
using CookComputing.XmlRpc;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Comment
    {
        public string comment_id { get; set; }
        public string parent { get; set; }
        public string user_id { get; set; }
        public DateTime date_created_gmt { get; set; }
        public string status { get; set; }
        public string content { get; set; }
        public string link { get; set; }
        public string post_id { get; set; }
        public string post_title { get; set; }
        public string author { get; set; }
        public string author_url { get; set; }
        public string author_email { get; set; }
        public string author_ip { get; set; }
        public string type { get; set; }
    }
}