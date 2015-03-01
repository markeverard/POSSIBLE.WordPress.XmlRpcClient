﻿using System;
using System.Collections.Generic;
using POSSIBLE.WordPress.XmlRpcClient;
using POSSIBLE.WordPress.XmlRpcClient.Models;

namespace POSSIBLE.Wordpress.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            const string baseUrl = "http://www.wordpress.com";
            const string username = "xxx";
            const string password = "xxx";
            
            using (var client = new WordPressXmlRpcClient(baseUrl, username, password))
            {
                var postId = 3502;
                
                var post = client.GetPost(postId, false);
                WritePosts(new []{post});
                WriteMediaItems(post.media_items);

                var comments = client.GetComments(new CommentFilter(){ post_id = postId});
                WriteComments(comments);

                var commentCount = client.GetCommentsCount(postId);
                WritePostCommentCount(commentCount);

                var blogs = client.GetUsersBlogs(username, password);
                WriteBlogs(blogs);

                var users = client.GetUsers(new UserFilter());
                WriteUsers(users);

                var user = client.GetUser(2);
                WriteUsers(new[] { user });

                var posts = client.GetPosts(new PostFilter() { number = 2 });
                WritePosts(posts);

                var mediaFilter = new MediaFilter() { number = 1 };
                var images = client.GetMediaLibrary(mediaFilter);
                WriteMediaItems(images);

                var taxonomies = client.GetTaxonomies();
                WriteTaxonomies(taxonomies);

                var termFilter = new TermFilter();
                var terms = client.GetTerms("category", termFilter);
                WriteTerms(terms);
            }

            Console.WriteLine("Press any key to Exit");
            Console.ReadKey(true);
        }

        private static void WritePostCommentCount(PostCommentCount commentCount)
        {
            Console.WriteLine("COMMENTS");
            Console.WriteLine("Total ({0})", commentCount.total_comments);
            Console.WriteLine("Approved ({0})", commentCount.approved);
            Console.WriteLine("Awaiting Moderation ({0})", commentCount.awaiting_moderation);
            Console.WriteLine("Spam ({0})", commentCount.spam);

            Console.WriteLine();           
        }

        private static void WriteComments(IEnumerable<Comment> comments)
        {
            Console.WriteLine("COMMENTS");

            foreach (var comment in comments)
                Console.WriteLine(string.Format("Date '{0}' by '{1}' - {2}, ", comment.date_created_gmt, comment.author, comment.content));

            Console.WriteLine();
        }

        private static void WriteUsers(IEnumerable<User> users)
        {
            Console.WriteLine("USERS");

            foreach (var user in users)
                Console.WriteLine(string.Format("{0} {1} / ('{2}' '{3}'), ", user.first_name, user.last_name, user.email,
                    user.nickname));

            Console.WriteLine();
        }

        private static void WriteBlogs(IEnumerable<UserBlog> blogs)
        {
            Console.WriteLine("BLOGS");

            foreach (var blog in blogs)
                Console.WriteLine(string.Format("{0} {1} / ('{2}' '{3}'), isAdmin '{4}'", blog.blogName, blog.blogid, blog.url,
                    blog.xmlrpc, blog.isAdmin));

            Console.WriteLine();
        }

        private static void WriteTerms(IEnumerable<Term> terms)
        {
            Console.WriteLine("TERMS");

            foreach (var term in terms)
                Console.WriteLine(string.Format("{0} ({1}), ", term.name, term.count));

            Console.WriteLine();
        }

        private static void WriteTaxonomies(IEnumerable<Taxonomy> taxonomies)
        {
            Console.WriteLine("TAXONOMIES");
            Console.WriteLine("-------------------------");
            Console.WriteLine("-------------------------");
          
            foreach (var taxonomy in taxonomies)
            {
                Console.WriteLine(taxonomy.name);
                Console.WriteLine(taxonomy.label);
                Console.WriteLine("-------------------------");
            }
        }
        
        private static void WriteMediaItems(IEnumerable<MediaItem> images)
        {
            Console.WriteLine("IMAGES");
            Console.WriteLine("-------------------------");
            Console.WriteLine("-------------------------");
          
            foreach (var image in images)
            {
                Console.WriteLine(image.link);
                Console.WriteLine(image.caption);
                Console.WriteLine(image.metadata.file);   
                Console.WriteLine(image.metadata.height);   
                Console.WriteLine(image.metadata.width);

                WriteMediaItemSizes(image.metadata.sizes);
                Console.WriteLine("-------------------------");
            }
        }

        private static void WriteMediaItemSizes(MediaItemSizes size)
        {
            WriteMediaItemSize(size.large);    
            WriteMediaItemSize(size.medium);    
            WriteMediaItemSize(size.thumbnail);    
            WriteMediaItemSize(size.post_thumbnail);    
            WriteMediaItemSize(size.listing);    
            WriteMediaItemSize(size.listing_small);    
        }

        private static void WriteMediaItemSize(MediaItemSize size)
        {
            if (string.IsNullOrEmpty(size.file))
                return;

            Console.WriteLine(size.file);
            Console.WriteLine(size.height);
            Console.WriteLine(size.width);
            Console.WriteLine(size.mime_type);
        }


        private static void WritePosts(IEnumerable<Post> posts)
        {
            Console.WriteLine("POSTS");
            Console.WriteLine("-------------------------");
            Console.WriteLine("-------------------------");
          
            foreach (var post in posts)
            {
                Console.WriteLine("POST");
                Console.WriteLine("-------------------------");
                Console.WriteLine(post.post_title);
                Console.WriteLine(post.post_author);
                Console.WriteLine(post.post_date);
                Console.WriteLine(post.post_status);

                var formattedContent = string.Concat("<p>", post.post_content.Replace("\n\n", "</p><p>"), "</p>");
                Console.WriteLine(formattedContent);
                
                WriteCustomFields(post.custom_fields);
                WriteTerms(post.terms);

       
                Console.WriteLine("-------------------------");

            }
        }

        private static void WriteCustomFields(IEnumerable<CustomFields> customFields)
        {
            foreach (var customField in customFields)
                Console.WriteLine(string.Format("{0} : {1} |", customField.key, customField.value));
        }
    }
}
