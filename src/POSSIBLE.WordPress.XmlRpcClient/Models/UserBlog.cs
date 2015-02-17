using System;
using CookComputing.XmlRpc;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    /// <summary>
    /// Represents a WordPress user's blogs
    /// </summary>    
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct UserBlog
    {
        public string blogid { get; set; }
        public string blogName { get; set; }
        public string url { get; set; }
        public string xmlrpc { get; set; }
        public bool isAdmin { get; set; }        
    }
}