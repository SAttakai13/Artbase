using Artbase.Interfaces;
using Artbase.Models;

namespace Artbase.Data
{
    public class UserPostDAL : IUserPost
    {
        public void CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(string? postId)
        {
            throw new NotImplementedException();
        }

        public void EditPost(Post post)
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(string? postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPosts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostsByPostId(string? postId)
        {
            throw new NotImplementedException();
        }
    }
}
