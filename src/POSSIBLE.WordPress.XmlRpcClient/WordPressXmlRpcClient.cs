using System;
using CookComputing.XmlRpc;
using POSSIBLE.WordPress.XmlRpcClient.Models;
using System.IO;

namespace POSSIBLE.WordPress.XmlRpcClient
{
    /// <summary>
    /// A client class responsible for returning data from a WordPress instance over XML-RPC
    /// </summary>
    public class WordPressXmlRpcClient : IDisposable, IWordPressClient
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

            Proxy = (IWordPressProxy)XmlRpcProxyGen.Create(typeof(IWordPressProxy));

            Proxy.Url = FullUrl;
        }

        /// <summary>
        /// Returns the post information excluding any related media items.
        /// </summary>
        /// <param name="postId">The post id.</param>
        /// <returns>Post</returns>
        public Post GetPost(int postId)
        {
            return Proxy.GetPost(BlogId, Username, Password, postId);
        }

        /// <summary>
        /// Gets a post by unique identifier.
        /// </summary>
        /// <param name="postId">The post id.</param>
        /// <param name="includeMedia">if set to <c>true</c> [media items are populated via a GetMediaLibrary call].</param>
        /// <returns>Post</returns>
        public Post GetPost(int postId, bool includeMedia)
        {
            var post = GetPost(postId);

            if (!includeMedia)
            {
                post.media_items = new MediaItem[] { };
                return post;
            }

            var mediaFilter = new MediaFilter { parent_id = post.post_id };
            post.media_items = GetMediaLibrary(mediaFilter) ?? new MediaItem[] { };

            return post;
        }

        /// <summary>
        /// Returns a list of posts excluding media items as specified by the supplied post filter
        /// </summary>
        /// <param name="filter">The post filter</param>
        /// <returns>Post[]</returns>
        public Post[] GetPosts(PostFilter filter)
        {
            return Proxy.GetPosts(BlogId, Username, Password, filter);
        }

        /// <summary>
        /// Gets a media item by unique identifier.
        /// </summary>
        /// <param name="attachmentId">The attachment id.</param>
        /// <returns>MediaItem</returns>
        public MediaItem GetMediaItem(int attachmentId)
        {
            return Proxy.GetMediaItem(BlogId, Username, Password, attachmentId);
        }

        /// <summary>
        /// Returns a list of media items as specified by the supplied media filter
        /// </summary>
        /// <param name="filter">The media filter.</param>
        /// <returns>MediaItem[]</returns>
        public MediaItem[] GetMediaLibrary(MediaFilter filter)
        {
            return Proxy.GetMediaLibrary(BlogId, Username, Password, filter);
        }

        /// <summary>
        /// Gets the taxonomy item by taxonomy type and unique identifier .
        /// </summary>
        /// <param name="taxonomy">The taxonomy - examples = "category".</param>
        /// <param name="termId">The term id.</param>
        /// <returns>Taxonomy</returns>
        public Taxonomy GetTaxonomy(string taxonomy, int termId)
        {
            return Proxy.GetTaxonomy(BlogId, Username, Password, taxonomy, termId);
        }

        /// <summary>
        /// Returns a list of taxnomies used across the blog
        /// </summary>
        /// <returns>Taxonomy[]</returns>
        public Taxonomy[] GetTaxonomies()
        {
            return Proxy.GetTaxonomies(BlogId, Username, Password);
        }

        /// <summary>
        /// Gets a single term.
        /// </summary>
        /// <param name="taxonomy">The taxonomy.</param>
        /// <param name="termId">The term identifier.</param>
        /// <returns>Term</returns>
        public Term GetTerm(string taxonomy, int termId)
        {
            return Proxy.GetTerm(BlogId, Username, Password, taxonomy, termId);
        }

        /// <summary>
        /// Gets a list of all terms.
        /// </summary>
        /// <param name="taxonomy">The taxonomy.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>Term[]</returns>
        public Term[] GetTerms(string taxonomy, TermFilter filter)
        {
            return Proxy.GetTerms(BlogId, Username, Password, taxonomy, filter);
        }

        /// <summary>
        /// Gets a single user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>User</returns>
        public User GetUser(int userId)
        {
            return Proxy.GetUser(BlogId, Username, Password, userId);
        }

        /// <summary>
        /// Gets a list of users according to the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>User[]</returns>
        public User[] GetUsers(UserFilter filter)
        {
            return Proxy.GetUsers(BlogId, Username, Password, filter);
        }

        /// <summary>
        /// Gets a single comment 
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <returns>Comment</returns>
        public Comment GetComment(int commentId)
        {
            return Proxy.GetComment(BlogId, Username, Password, commentId);
        }

        /// <summary>
        /// Gets a list of comments according to the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>User[]</returns>
        public Comment[] GetComments(CommentFilter filter)
        {
            return Proxy.GetComments(BlogId, Username, Password, filter);
        }

        /// <summary>
        /// Gets a list of comment counts specifying how many comments in each status belong to a post.
        /// </summary>
        /// <param name="postId">The post id.</param>
        /// <returns>PostCommentCount</returns>
        public PostCommentCount GetCommentsCount(int postId)
        {
            return Proxy.GetCommentCount(BlogId, Username, Password, postId);
        }

        /// <summary>
        /// Creates a new post in the blog.
        /// </summary>
        /// <param name="newPost">The post.</param>
        /// <returns>ID</returns>
        public string NewPost(Post newPost)
        {
            CreatePost createPost = CreatePost.GetFromPost(newPost);


            return Proxy.NewPost(BlogId, Username, Password, createPost);
        }

        /// <summary>
        /// Creates a new comment for a blog post or page in the blog. If your blog does not allow 
        /// anonymous comments through XML-RPC, the author details will be ignored and the comment
        /// will come from the username user to create the comment.
        /// 
        /// If you need to set author name in a blog that does not allow anoymous comments through 
        /// XML-RPC, you can use the method call with the optional boolean parameter or call
        /// EditComment manually after creating the comment.
        /// </summary>
        /// <param name="postId">The ID of the post or page to which the comment belongs.</param>
        /// <param name="newComment">The comment.</param>
        /// <returns>ID</returns>
        public int NewComment(int postId, Comment newComment)
        {
            int commentID = Proxy.NewComment(BlogId, Username, Password, postId, newComment);
            return commentID;
        }

        /// <summary>
        /// Creates a new comment for a blog post or page in the blog and optionally automatically edits
        /// it to ensure that the author name is set properly.
        /// </summary>
        /// <param name="postId">The ID of the post or page to which the comment belongs.</param>
        /// <param name="newComment">The comment.</param>
        /// <returns>ID</returns>
        public int NewComment(int postId, Comment newComment, bool autoEdit)
        {
            int commentID = Proxy.NewComment(BlogId, Username, Password, postId, newComment);
            // WP XML-RPC not allowing author to be set on New comments. Force edit comment:
            if (autoEdit) { EditComment(commentID, newComment); }
            return commentID;
        }

        /// <summary>
        /// Edits a comment for a blog post or page in the blog. Note that calling this method is required 
        /// after posting a new comment unless your blog supports anonymous comments through XML-RPC. 
        /// Otherwise, all comments will come from the username that adds the comment.
        /// </summary>
        /// <param name="commentId">The ID of the comment.</param>
        /// <param name="comment">The comment.</param>
        /// <returns>ID</returns>
        public bool EditComment(int commentId, Comment comment)
        {
            return Proxy.EditComment(BlogId, Username, Password, commentId, comment);
        }
        
        /// <summary>
        /// Add a new term to the blog
        /// </summary>
        /// <param name="term">the term, minimal properties to fill are name, taxonomy and slug</param>
        /// <returns>the id of the new term or -1 in case the addition failed</returns>
        public string NewTerm(Term term)
        {
            try
            {
                return Proxy.NewTerm(BlogId, Username, Password, term);
            }
            catch(XmlRpcFaultException)
            {
                return "-1";
            }
        }

        public UploadItem UploadFile(string filenameIncludingExtension, string pathToFileToUpload, string type = "image/jpeg")
        {
            var itemToUpload = new UploadItem();
            itemToUpload.name = filenameIncludingExtension;
            itemToUpload.type = type;
            FileStream fs = new FileStream(pathToFileToUpload, FileMode.Open, FileAccess.Read);
            byte[] filebytes = new byte[fs.Length];
            fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
            itemToUpload.bits = filebytes;
            return Proxy.UploadFile(BlogId, Username, Password, itemToUpload);
        }

        public void Dispose()
        {
            Proxy = null;
        }
    }
}