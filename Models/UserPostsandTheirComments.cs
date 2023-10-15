namespace Artbase.Models
{
    public class UserPostsandTheirComments
    {
        public IEnumerable<Post> PostsForUser { get; set; }

        public IEnumerable<Comment> UserComments { get; set; }

        public Profile UserProfile { get; set; }

        public UserPostsandTheirComments() { }
        public UserPostsandTheirComments(IEnumerable<Post> posts, IEnumerable<Comment> comments, Profile prof)
        {
            this.PostsForUser = posts;
            this.UserComments = comments;
            this.UserProfile = prof;
        }
    }
}
