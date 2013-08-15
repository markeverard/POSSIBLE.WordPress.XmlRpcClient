namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    /// <summary>
    /// An object representing any custom WordPress fields added to a post
    /// </summary>
    public struct CustomFields
    {
        public string id { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }
}