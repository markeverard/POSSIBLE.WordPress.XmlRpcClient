using System;
using CookComputing.XmlRpc;
using POSSIBLE.WordPress.XmlRpcClient.Models;

namespace POSSIBLE.WordPress.XmlRpcClient
{
    public class WordPressXmlRpcClient : IDisposable
    {
        protected string BaseUrl;
        protected string Username;
        protected string Password;
        protected int BlogId;

        public IWordPressProxy Proxy { get; internal set; }

        public string FullUrl 
        { 
            get
            {
                return string.Concat(BaseUrl, 
                               BaseUrl.EndsWith("/") ? "xmlrpc.php" : "/xmlrpc.php");
            }
        }

        public WordPressXmlRpcClient(string baseUrl, string username, string password, int blogId = 1)
        {
            BaseUrl = baseUrl;
            Username = username;
            Password = password;
            BlogId = blogId;

            Proxy =  (IWordPressProxy)XmlRpcProxyGen.Create(typeof(IWordPressProxy));
            Proxy.Url = FullUrl;
        }

        public Post GetPost(int postId)
        {
            return Proxy.GetPost(BlogId, Username, Password, postId);
        }

        public Post GetPost(int postId, bool includeMedia)
        {
            var post = GetPost(postId);

            var mediaFilter = new MediaFilter {parent_id = post.post_id};
            var media = GetMediaLibrary(mediaFilter);


            return post;
        }

        public Post[] GetPosts(PostFilter filter)
        {
            return Proxy.GetPosts(BlogId, Username, Password, filter);
        }

        public MediaItem GetMediaItem(int attachmentId)
        {
            return Proxy.GetMediaItem(BlogId, Username, Password, attachmentId);
        }

        public MediaItem[] GetMediaLibrary(MediaFilter filter)
        {
            return Proxy.GetMediaLibrary(BlogId, Username, Password, filter);
        }

        public Taxonomy GetTaxonomy(string taxonomy, int termId)
        {
            return Proxy.GetTaxonomy(BlogId, Username, Password, taxonomy, termId);
        }

        public Taxonomy[] GetTaxonomies()
        {
            return Proxy.GetTaxonomies(BlogId, Username, Password);
        }

        public Term GetTerm(string taxonomy, int termId)
        {
            return Proxy.GetTerm(BlogId, Username, Password, taxonomy, termId);
        }

        public Term[] GetTerms(string taxonomy, TermFilter filter)
        {
            return Proxy.GetTerms(BlogId, Username, Password, taxonomy, filter);
        }

        public void Dispose()
        {
            Proxy = null;
        }
    }
}