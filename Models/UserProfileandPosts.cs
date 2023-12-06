namespace Artbase.Models
{
    public class UserProfileandPosts
    {
        public IEnumerable<Post>? PostsForUser { get; set; }
        public IEnumerable<Upload>? UploadsFromUser { get; set; }
        public IEnumerable<Upload>? UserSavedUploads { get; set; }
        public IEnumerable<Comment>? CommentsUnderPost { get; set; }
        public IEnumerable<UserSaves>? SavesForUser { get; set; }
        public Profile? UserProfile { get; set; }
        public Post? UserPost { get; set; }
        public Comment? UserComment { get; set; }

        public UserProfileandPosts() { }

        //public UserProfileandPosts(IEnumerable<Post> posts, Profile prof)
        //{
        //    this.PostsForUser = posts;
        //    this.UserProfile = prof;
        //}

        //public UserProfileandPosts(IEnumerable<Upload> uploads, Profile prof)
        //{
        //    this.UploadsFromUser = uploads;
        //    this.UserProfile = prof;
        //}

        //public UserProfileandPosts(IEnumerable<Post> posts, IEnumerable<Comment> comments, Profile prof)
        //{
        //    this.PostsForUser = posts;
        //    this.CommentsUnderPost = comments;
        //    this.UserProfile = prof;
        //}


        public UserProfileandPosts(IEnumerable<Post> posts, IEnumerable<Upload> uploads)
        {
            this.PostsForUser = posts;
            this.UploadsFromUser = uploads;
        }

        public UserProfileandPosts(IEnumerable<Post> posts, IEnumerable<Upload> uploads, IEnumerable<UserSaves>? userfavs)
        {
            this.PostsForUser = posts;
            this.UploadsFromUser = uploads;
            this.SavesForUser = userfavs;
        }

        //public UserProfileandPosts(IEnumerable<Post> posts, IEnumerable<Upload> uploads, IEnumerable<Comment> comments)
        //{
        //    this.PostsForUser = posts;
        //    this.UploadsFromUser = uploads;
        //    this.CommentsUnderPost = comments;
        //}

        //public UserProfileandPosts(IEnumerable<Post> posts, IEnumerable<Upload> uploads, Profile prof)
        //{
        //    this.PostsForUser = posts;
        //    this.UploadsFromUser = uploads;
        //    this.UserProfile = prof;
        //}

        public UserProfileandPosts(IEnumerable<Post> posts, IEnumerable<Upload> uploads, IEnumerable<Upload> saveduploads)
        {
            this.PostsForUser = posts;
            this.UploadsFromUser = uploads;
            this.UserSavedUploads = saveduploads;
        }

        //UserSaves
        public UserProfileandPosts(IEnumerable<Post> posts, IEnumerable<Upload> uploads, IEnumerable<Upload> saveduploads, IEnumerable<UserSaves> userfavs)
        {
            this.PostsForUser = posts;
            this.UploadsFromUser = uploads;
            this.UserSavedUploads = saveduploads;
            this.SavesForUser = userfavs;
        }

        public UserProfileandPosts(IEnumerable<Post> posts, IEnumerable<Upload> uploads, IEnumerable<Comment> comments, Profile prof)
        {
            this.PostsForUser = posts;
            this.UploadsFromUser = uploads;
            this.CommentsUnderPost = comments;
            this.UserProfile = prof;
        }


        //UserSaves
        public UserProfileandPosts(IEnumerable<Post> posts, IEnumerable<Upload> uploads, IEnumerable<Comment> comments, Profile prof, IEnumerable<UserSaves> userfavs)
        {
            this.PostsForUser = posts;
            this.UploadsFromUser = uploads;
            this.CommentsUnderPost = comments;
            this.UserProfile = prof;
            this.SavesForUser = userfavs;
        }

        //public UserProfileandPosts(IEnumerable<Post> posts, IEnumerable<Upload> uploads, IEnumerable<Upload> savedUploads, IEnumerable<Comment> comments, Profile prof)
        //{
        //    this.PostsForUser = posts;
        //    this.UploadsFromUser = uploads;
        //    this.UserSavedUploads = savedUploads;
        //    this.CommentsUnderPost = comments;
        //    this.UserProfile = prof;
        //}
    }
}
