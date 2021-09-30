namespace Comments.Application.Response
{
    public class CommentsRequestResponse
    {
        public int PostId { get; set; }

        public string PostTitle { get; set; }

        public string PostBody { get; set; }

        public int TotalNumberOfComments { get; set; }
    }
}
