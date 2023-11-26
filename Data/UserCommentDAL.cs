using Artbase.Interfaces;
using Artbase.Models;

namespace Artbase.Data
{
    public class UserCommentDAL : IUserComment
    {
        private AppDbContext db;

        public UserCommentDAL(AppDbContext artbaseSettings)
        {
            this.db = artbaseSettings;
        }

        public void AddComment(Comment comment)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
        }

        public void DeleteComment(int? commentId)
        {
            var search = GetCommentById(commentId);
            if (search != null)
            {
                db.Comments.Remove(search);
                db.SaveChanges();
            }
        }

        public void EditComment(Comment comment)
        {
            db.Comments.Update(comment);
            db.SaveChanges();
        }

        public Comment GetCommentById(int? commentId)
        {
            Comment? foundComment = db.Comments.Where(p =>  p.CommentId == commentId).FirstOrDefault();
            return foundComment;
        }

        public IEnumerable<Comment> GetCommentByUser(string? userid)
        {
            if (userid == null)
                GetComments();

            IEnumerable<Comment> ltsUserComments = GetComments().Where(p => p.UserCommentID == userid).ToList();

            if (ltsUserComments.Count() == 0)
                return null;

            return ltsUserComments;
        }
        public IEnumerable<Comment> GetAllCommentsByPost(int? postid)
        {
            if (postid == null)
                GetComments();

            IEnumerable<Comment> ltsUserComments = GetComments().Where(p => p.PostID.Equals(postid)).ToList();

            if (ltsUserComments.Count() == 0)
                return null;

            return ltsUserComments;
        }

        public IEnumerable<Comment> GetComments()
        {
            return db.Comments.ToList();
        }
    }
}
