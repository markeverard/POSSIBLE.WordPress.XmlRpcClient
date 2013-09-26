namespace POSSIBLE.WordPress.XmlRpcClient.Models
{
    public class UserFilter : FilterBase
    {
        public UserFilter()
        {
            order = "ASC";
            orderby = "username";
            who = string.Empty;
            role = UserRole.Administrator.ToString().ToLower();
        }

        public string role { get; set; }
        public string who { get; set; }
        public int offset { get; set; }
        public string orderby { get; set; }
        public string order { get; set; }
    }
}