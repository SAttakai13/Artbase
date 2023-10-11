using Artbase.Models;

namespace Artbase.Interfaces
{
    public interface IUserPost
    {
        Task CreatePost(Post post);
        Task DeletePost(string? postId);
        Task EditPost(string? postId, Post post);
        Task<IEnumerable<Post>> GetPosts();
        Task<IEnumerable<Post>> GetPostsByPostId(string? postId);
        Task<Post> GetPostById(string? postId);
        
    }
}
