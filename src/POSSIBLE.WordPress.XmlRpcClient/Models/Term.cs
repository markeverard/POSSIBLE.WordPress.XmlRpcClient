namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    public struct Term
    {
        public string term_id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string term_group { get; set; }
        public string term_taxonomy_id { get; set; }
        public string taxonomy { get; set; }
        public string description { get; set; }
        public string parent { get; set; }
        public int count { get; set; }
    }
}