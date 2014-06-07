using CookComputing.XmlRpc;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class CommentFilter : FilterBase
    {
        //If empty retrieves all comments
        public int post_id { get; set; }
        public string status { get; set; }
        public int offset { get; set; }
    }
}