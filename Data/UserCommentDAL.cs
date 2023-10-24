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
            db.Update(comment);
            db.SaveChanges();
        }

        public Comment GetCommentById(int? commentId)
        {
            Comment? foundComment = db.Comments.Where(p =>  p.CommentId == commentId).FirstOrDefault();
            return foundComment;
        }

        public IEnumerable<Comment> GetCommentByUser(string? commentid)
        {
            if (commentid == null)
                GetComments();

            IEnumerable<Comment> ltsUserComments = GetComments().Where(p => p.UserCommentID.Equals(commentid)).ToList();

            if (ltsUserComments.Count() == 0)
                return GetComments();

            return ltsUserComments;
        }

        public IEnumerable<Comment> GetComments()
        {
            return db.Comments.ToList();
        }
    }
}
