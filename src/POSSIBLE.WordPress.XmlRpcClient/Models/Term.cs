using CookComputing.XmlRpc;
namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Term
    {
            [XmlRpcMember("term_id")]
            public string term_id { get; set; }

            [XmlRpcMember("name")]
            public string name { get; set; }

            [XmlRpcMember("slug")]
            public string slug { get; set; }

            [XmlRpcMember("term_group")]
            public string term_group { get; set; }

            [XmlRpcMember("term_taxonomy_id")]
            public string term_taxonomy_id { get; set; }

            [XmlRpcMember("taxonomy")]
            public string taxonomy { get; set; }

            [XmlRpcMember("description")]
            public string description { get; set; }

            [XmlRpcMember("parent")]
            public string parent { get; set; }

            [XmlRpcMember("count")]
            public int count { get; set; }
    }
}