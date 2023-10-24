using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserPost
    {
        void CreatePost(Post post);
        void DeletePost(int? postId);
        void EditPost(Post post);
        IEnumerable<Post> GetPosts();
        Post GetPostById(int? postId);
        IEnumerable<Post> GetPostById(string? postId);
        
    }
}
