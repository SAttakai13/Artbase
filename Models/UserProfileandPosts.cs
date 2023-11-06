namespace Artbase.Models
{
    public class UserProfileandPosts
    {
        public IEnumerable<Post> PostsForUser { get; set; }


        public Profile UserProfile { get; set; }
        public Post UserPost { get; set; }

        public UserProfileandPosts() { }
        public UserProfileandPosts(IEnumerable<Post> posts, Profile prof)
        {
            this.PostsForUser = posts;
            this.UserProfile = prof;
        }
    }
}
