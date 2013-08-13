using System;
using System.Collections.Generic;
using POSSIBLE.WordPress.XmlRpcClient;
using POSSIBLE.WordPress.XmlRpcClient.Models;

namespace POSSIBLE.Wordpress.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            const string baseUrl = "http://www.wordpress.com/";
            const string username = "xxx";
            const string password = "xxx";
            
            using (var client = new WordPressXmlRpcClient(baseUrl, username, password))
            {
                 var post = client.GetPost(1992);
                WritePosts(new []{post});
                
                var postFilter = new PostFilter();
                var posts = client.GetPosts(postFilter);
                WritePosts(posts);

                var mediaFilter = new MediaFilter();
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

        private static void WriteTerms(IEnumerable<Term> terms)
        {
            Console.WriteLine("TERMS");

            foreach (var term in terms)
                Console.Write(string.Format("{0} ({1}), ", term.name, term.count));

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
                Console.WriteLine("-------------------------");
            }
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
                WriteCustomFields(post.custom_fields);
                WriteTerms(post.terms);

                //var filter = new MediaFilter();
                //filter.parent_id = post.post_id;
                //var mediaLibrary = client.GetMediaLibrary(BlogId.ToString(), Username, Password, filter);
                //Console.WriteLine("IMAGES");
                //foreach (var mediaItem in mediaLibrary)
                //    Console.WriteLine(mediaItem.link);

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
