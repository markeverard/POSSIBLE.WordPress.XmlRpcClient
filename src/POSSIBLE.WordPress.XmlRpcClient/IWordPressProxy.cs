using CookComputing.XmlRpc;
using POSSIBLE.WordPress.XmlRpcClient.Models;

namespace POSSIBLE.WordPress.XmlRpcClient
{
    /// <summary>
    /// An interface defining the methods available via the WordPress XML-RPC service
    /// </summary>
    public interface IWordPressProxy : IXmlRpcProxy 
    {
        [XmlRpcMethod("wp.getPost")]
        Post GetPost(int blog_id, string username, string password, int post_id);
        
        [XmlRpcMethod("wp.getPosts")]
        Post[] GetPosts(int blog_id, string username, string password, PostFilter filter);

        [XmlRpcMethod("wp.getMediaItem")]
        MediaItem GetMediaItem(int blog_id, string username, string password, int attachment_id);

        [XmlRpcMethod("wp.getMediaLibrary")]
        MediaItem[] GetMediaLibrary(int blog_id, string username, string password, MediaFilter filter);

        [XmlRpcMethod("wp.getTaxonomy")]
        Taxonomy GetTaxonomy(int blog_id, string username, string password, string taxonomy, int term_id );

        [XmlRpcMethod("wp.getTaxonomies")]
        Taxonomy[] GetTaxonomies(int blog_id, string username, string password);

        [XmlRpcMethod("wp.getTerm")]
        Term GetTerm(int blog_id, string username, string password, string taxonomy, int term_id);

        [XmlRpcMethod("wp.getTerms")]
        Term[] GetTerms(int blog_id, string username, string password, string taxonomy, TermFilter filter);

        [XmlRpcMethod("wp.getUser")]
        User GetUser(int blog_id, string username, string password, int user_id);

        [XmlRpcMethod("wp.getUsers")]
        User[] GetUsers(int blog_id, string username, string password, UserFilter filter);

        [XmlRpcMethod("wp.getComment")]
        Comment GetComment(int blog_id, string username, string password, int comment_id);

        [XmlRpcMethod("wp.getComments")]
        Comment[] GetComments(int blog_id, string username, string password, CommentFilter filter);

        [XmlRpcMethod("wp.getCommentCount")]
        PostCommentCount GetCommentCount(int blog_id, string username, string password, int post_id);

        [XmlRpcMethod("wp.newPost")]
        string NewPost(int blog_id, string username, string password, CreatePost post);

        [XmlRpcMethod("wp.newComment")]
        int NewComment(int blog_id, string username, string password, int post_id, Comment comment);

        [XmlRpcMethod("wp.editComment")]
        bool EditComment(int blog_id, string username, string password, int comment_id, Comment comment);


    }
}


