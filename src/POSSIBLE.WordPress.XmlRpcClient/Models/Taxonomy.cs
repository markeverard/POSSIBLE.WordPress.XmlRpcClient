namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    public struct Taxonomy
    {
        public string name { get; set; }
        public string label { get; set; }
        public bool hierarchical { get; set; }
        //public bool public 
        public bool show_ui { get; set; }
        public bool _builtin { get; set; }
        //public struct labels1 { get; set; }
        //public struct cap2 { get; set; }
        //public array object_type
    }
}