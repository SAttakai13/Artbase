namespace Artbase.Models
{
    public class UserProfileandPosts
    {
        public IEnumerable<Post> PostsForUser { get; set; }
        public IEnumerable<Upload> UploadsFromUser { get; set; }
        public Profile UserProfile { get; set; }

        public Post UserPost { get; set; }

        public UserProfileandPosts() { }
        public UserProfileandPosts(IEnumerable<Post> posts, Profile prof)
        {
            this.PostsForUser = posts;
            this.UserProfile = prof;
        }

        public UserProfileandPosts(IEnumerable<Upload> uploads, Profile prof)
        {
            this.UploadsFromUser = uploads;
            this.UserProfile = prof;
        }

        public UserProfileandPosts(IEnumerable<Post> posts, IEnumerable<Upload> uploads, Profile prof)
        {
            this.PostsForUser = posts;
            this.UploadsFromUser = uploads;
            this.UserProfile = prof;
        }
    }
}
