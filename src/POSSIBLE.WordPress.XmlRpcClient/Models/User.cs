using System;
using CookComputing.XmlRpc;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
        /// <summary>
    /// Represents a WordPress use item
    /// </summary>
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct User
    {
        public string user_id { get; set; }
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string bio { get; set; }
        public string email { get; set; }
        public string nickname { get; set; }
        public string nicename { get; set; }
        public string url { get; set; }
        public string display_name { get; set; }
        public DateTime registered { get; set; }
        public string[] roles { get; set; }
    }
}