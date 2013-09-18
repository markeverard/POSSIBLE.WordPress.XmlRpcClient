using System;
using CookComputing.XmlRpc;
using POSSIBLE.WordPress.XmlRpcClient.Models;

namespace POSSIBLE.WordPress.XmlRpcClient
{
    /// <summary>
    /// A client class responsible for returning data from a WordPress instance over XML-RPC
    /// </summary>
    public class WordPressXmlRpcClient : IDisposable
    {
        protected string BaseUrl;
        protected string Username;
        protected string Password;
        protected int BlogId;

        /// <summary>
        /// Returns the CookComputing.XmlRpc proxy allowing access to more detailed request settings
        /// </summary>
        public IWordPressProxy Proxy { get; internal set; }

        /// <summary>
        /// Gets the full URL of the endpoint - convention assumes it is always hosted at /xmlrpc.php.
        /// </summary>
        public string FullUrl 
        { 
            get
            {
                return string.Concat(BaseUrl, 
                               BaseUrl.EndsWith("/") ? "xmlrpc.php" : "/xmlrpc.php");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordPressXmlRpcClient"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL - convention assumes that the xml-rpc service is located at /xmlrpc.php</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="blogId">The blog id - default is 1</param>
        public WordPressXmlRpcClient(string baseUrl, string username, string password, int blogId = 1)
        {
            BaseUrl = baseUrl;
            Username = username;
            Password = password;
            BlogId = blogId;

            Proxy =  (IWordPressProxy)XmlRpcProxyGen.Create(typeof(IWordPressProxy));
            Proxy.Url = FullUrl;
        }

        /// <summary>
        /// Returns the post information excluding any related media items.
        /// </summary>
        /// <param name="postId">The post id.</param>
        /// <returns></returns>
        public Post GetPost(int postId)
        {
            return Proxy.GetPost(BlogId, Username, Password, postId);
        }

        /// <summary>
        /// Gets a post by unique identifier.
        /// </summary>
        /// <param name="postId">The post id.</param>
        /// <param name="includeMedia">if set to <c>true</c> [media items are populated via a GetMediaLibrary call].</param>
        /// <returns></returns>
        public Post GetPost(int postId, bool includeMedia)
        {
            var post = GetPost(postId);

            if (!includeMedia)
                return post;

            var mediaFilter = new MediaFilter {parent_id = post.post_id};
            post.media_items = GetMediaLibrary(mediaFilter);
            return post;
        }

        /// <summary>
        /// Returns a list of posts excluding media items as specified by the supplied post filter
        /// </summary>
        /// <param name="filter">The post filter</param>
        /// <returns></returns>
        public Post[] GetPosts(PostFilter filter)
        {
            return Proxy.GetPosts(BlogId, Username, Password, filter);
        }

        /// <summary>
        /// Gets a media item by unique identifier.
        /// </summary>
        /// <param name="attachmentId">The attachment id.</param>
        /// <returns></returns>
        public MediaItem GetMediaItem(int attachmentId)
        {
            return Proxy.GetMediaItem(BlogId, Username, Password, attachmentId);
        }

        /// <summary>
        /// Returns a list of media items as specified by the supplied media filter
        /// </summary>
        /// <param name="filter">The media filter.</param>
        /// <returns></returns>
        public MediaItem[] GetMediaLibrary(MediaFilter filter)
        {
            return Proxy.GetMediaLibrary(BlogId, Username, Password, filter);
        }

        /// <summary>
        /// Gets the taxonomy item by taxonomy type and unique identifier .
        /// </summary>
        /// <param name="taxonomy">The taxonomy - examples = "category".</param>
        /// <param name="termId">The term id.</param>
        /// <returns></returns>
        public Taxonomy GetTaxonomy(string taxonomy, int termId)
        {
            return Proxy.GetTaxonomy(BlogId, Username, Password, taxonomy, termId);
        }

        /// <summary>
        /// Returns a list of taxnomies used across the blog
        /// </summary>
        /// <returns></returns>
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