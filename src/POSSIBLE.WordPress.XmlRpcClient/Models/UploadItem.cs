using CookComputing.XmlRpc;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class UploadItem
    {
        public string id { get; set; }
        public string file { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public byte[] bits { get; set; }
    }
}