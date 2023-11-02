using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.Extensions.Options;
using System.ComponentModel.Design;

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
            db.Posts.Add(post);
            db.SaveChanges();
        }

        public void DeletePost(int? postId)
        {
            var search = GetPostById(postId);
            if (search != null)
            {
                db.Posts.Remove(search);
                db.SaveChanges();
            }
        }

        public void EditPost(Post post)
        {
            db.Update(post);
            db.SaveChanges();
        }

        public Post GetPostById(int? postId)
        {
            Post? foundPost = db.Posts.Where(p => p.PostId == postId).FirstOrDefault();
            return foundPost;
        }

        public IEnumerable<Post> GetPostById(string? postId)
        {
            if (postId == null)
                GetPosts();

            IEnumerable<Post> lstUserPosts = GetPosts().Where(p => p.PostId.Equals(postId)).ToList();

            if (lstUserPosts.Count() == 0)
                return GetPosts();

            return lstUserPosts;
        }

        public IEnumerable<Post> GetPosts()
        {
            return db.Posts.ToList();
        }
    }
}
