namespace Artbase.Data
{
    public class ArtbaseDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string AccountCollectionName { get; set; }
        public string CommentsCollectionName { get; set; }
        public string PostsCollectionName { get; set; }
        public string ProfileCollectionName { get; set; }
        public string UploadsCollectionName { get; set; }
    }
}
