using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.Extensions.Options;

namespace Artbase.Data
{
    public class UserPostDAL : IUserPost
    {
        private AppDbContext db;

        public UserPostDAL(AppDbContext artbaseSettings)
        {
            this.db = artbaseSettings;
        }

        public void CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int? postId)
        {
            throw new NotImplementedException();
        }

        public void EditPost(Post post)
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(int? postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostById(string? postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPosts()
        {
            throw new NotImplementedException();
        }
    }
}
