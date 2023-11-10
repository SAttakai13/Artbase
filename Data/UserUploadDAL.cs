using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;

namespace Artbase.Data
{
    public class UserUploadDAL : IUserUpload
    {
        private AppDbContext db;

        public UserUploadDAL(AppDbContext artbaseSettings)
        {
            this.db = artbaseSettings;
        }


        public void AddUpload(Upload upload)
        {
            db.Uploads.Add(upload);
            db.SaveChanges();
            //try
            //{
            //    byte[] img = Convert.FromBase64String(upload.fileUrl);
            //    string insertFile = @"insert into Uploads(fileUrl, UserID) values (@img," + upload.UserID + ")";
            //    using (SqlConnection connection = new SqlConnection("DefaultConnection"))
            //    {
            //        connection.Open();
            //        using (SqlCommand command = new SqlCommand())
            //        {
            //            command.Connection = connection;
            //            command.CommandText = insertFile;
            //            command.Parameters.AddWithValue("@img", img);
            //            command.ExecuteNonQuery();
            //        }
            //    }
            //} catch (Exception ex)
            //{
            //    Trace.WriteLine(ex.Message);
            //}

        }

        public void DeleteUpload(int? userId)
        {
            //var search = GetUploadById(userId);
            //if (search != null)
            //{
            //    db.Uploads.Remove(search);
            //    db.SaveChanges();
            //}

            throw new NotImplementedException();
        }

        public IEnumerable<Upload> GetAllUploadsByUser(string? userid)
        {
            //if (userid == null)
            //    userid = "";

            //if (userid == "")
            //    GetUploads();

            //IEnumerable<Upload> lstUserUploads = GetUploads().Where(p => p.UserID.Contains(userid));

            //if (lstUserUploads.Count() == 0)
            //{
            //    return GetUploads();
            //}

            //return lstUserUploads;
            throw new NotImplementedException();
        }

        public IEnumerable<Upload> GetUploads()
        {
            //IEnumerable<Upload> uploads = new List<Upload>();
            //DataTable dataTable = new DataTable();
            //using (SqlConnection connection = new SqlConnection("DefaultConnection"))
            //{
            //    connection.Open();
            //    using (SqlDataAdapter adapter = new SqlDataAdapter("select * from Uploads", connection.))
            //    {
            //        adapter.Fill(dataTable);
            //        foreach (DataRow row in dataTable.Rows)
            //        {
            //            Upload upload = new Upload();
            //            upload.UploadId = Convert.ToInt32(row[0]);
            //            byte[] img = (byte[])row[1];
            //            upload.fileUrl = Convert.ToBase64String(img);
            //            upload.UserID = row[2].ToString();
            //        }
            //    }
            //}

            //return db.Uploads.ToList();
            throw new NotImplementedException();
        }
        public Upload GetUploadById(int? uploadId)
        {
            //Upload? foundUpload = db.Uploads.Where(p => p.UploadId == uploadId).FirstOrDefault();
            //return foundUpload;
            throw new NotImplementedException();
        }
    }
}
