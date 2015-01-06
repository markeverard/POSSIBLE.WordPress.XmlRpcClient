using System;
using CookComputing.XmlRpc;
using System.Collections.Generic;
using System.Linq;
namespace POSSIBLE.WordPress.XmlRpcClient.Models
{

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct CreatePost
    {
        public string post_id { get; set; }
        public string post_title { get; set; }
        public string post_status { get; set; }
        public string post_name { get; set; }
        public DateTime post_date { get; set; }
        public string post_content { get; set; }
        public string post_author { get; set; }
        public string link { get; set; }
        public XmlRpcStruct terms_names { get; set; }

        public CustomFields[] custom_fields { get; set; }
        public Enclosure enclosure { get; set; }

        public MediaItem[] media_items { get; set; }

        public string post_type { get; set; }
        public string post_format { get; set; }
        public string post_password { get; set; }
        public string post_excerpt { get; set; }
        public string post_parent { get; set; }
        public string post_mime_type { get; set; }


        internal static CreatePost GetFromPost(Post newPost)
        {
            CreatePost post = new CreatePost
            {
                custom_fields=newPost.custom_fields,
                enclosure=newPost.enclosure,
                link=newPost.link,
                media_items=newPost.media_items,
                post_author=newPost.post_author,
                post_content=newPost.post_content,
                post_date=newPost.post_date,
                post_excerpt=newPost.post_excerpt,
                post_format=newPost.post_format,
                post_id=newPost.post_id,
                post_mime_type=newPost.post_mime_type,
                post_name=newPost.post_name,
                post_parent=newPost.post_parent,
                post_password=newPost.post_password,
                post_status=newPost.post_status,
                post_title=newPost.post_title,
                post_type=newPost.post_type,
                
            };
            post.terms_names = new XmlRpcStruct();
            var terms = new XmlRpcStruct();
            var termTaxes = newPost.terms.GroupBy(t => t.taxonomy);
            foreach (var grp in termTaxes)
            {
                var termNames = grp.Select(g => g.name).ToArray();
                terms.Add(grp.Key, termNames);
            }
            post.terms_names = terms;
            return post;    

        }
    }
    /// <summary>
    /// Represents a WordPress post item
    /// </summary>
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Post
    {
        public string post_id { get; set; }
        public string post_title { get; set; }
        public string post_status { get; set; }
        public string post_name { get; set; }
        public DateTime post_date { get; set; }
        public string post_content { get; set; }
        public string post_author { get; set; }
        public string link { get; set; }
        public Term[] terms { get; set; }
        public CustomFields[] custom_fields { get; set; }
        public Enclosure enclosure { get; set; }

        public MediaItem[] media_items { get; set; }

        public string post_type { get; set; }
        public string post_format { get; set; }
        public string post_password { get; set; }
        public string post_excerpt { get; set; }
        public string post_parent { get; set; }
        public string post_mime_type { get; set; }

        //public IEnumerable<Tag> Tags { get; set; }
    }
}