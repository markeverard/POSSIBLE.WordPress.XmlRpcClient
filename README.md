POSSIBLE.WordPress.XmlRpcClient
===============================

An implementation of a WordPress XML-RPC client. The package depends on the XML-RPC.NET package and currently is implemented for read-actions based against the WordPress 3.9 XML-RPC specification.

Usage
-----
The WordPress XML-RPC feed by default lives in the root of your WordPress application (/xmlrpc.php). All you need to provide to download content is a WordPress username / password with admin rights, and the domain that your WordPress instance lives on.

An example of the syntax used is below:
![POSSIBLE.WordPress.XmlRpcClient code usage example](http://www.markeverard.com/wp-content/uploads/2014/06/wordpress-client-code-example.png "POSSIBLE.WordPress.XmlRpcClient code usage example")

The following methods are supported (as of version 0.5) and were tested against WordPress 3.9.1

* wp.getPost
* wp.getPosts
* wp.getMediaItem
* wp.getMediaLibrary
* wp.getTaxonomy
* wp.getTaxonomies
* wp.getTerm
* wp.getTerms
* wp.getUser
* wp.getUsers
* wp.getComment
* wp.getComments
* wp.getCommentCount

