using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserPost
    {
        void CreatePost(Post post);
        void DeletePost(string? postId);
        void EditPost(Post post);
        IEnumerable<Post> GetPosts();
        Post GetPostById(string? postId);
        IEnumerable<Post> GetPostsByPostId(string? postId);
    }
}
