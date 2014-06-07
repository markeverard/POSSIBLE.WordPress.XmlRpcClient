using CookComputing.XmlRpc;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class PostCommentCount
    {
        public string approved { get; set; }
        public int awaiting_moderation { get; set; }
        public int spam { get; set; }
        public int total_comments { get; set; }
    }
}