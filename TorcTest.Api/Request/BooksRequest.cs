using System.Reflection.Metadata.Ecma335;

namespace TorcTest.Api.Request
{
    public class BooksRequest
    {
        public int BookId { get; set; }
        public string Tittle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalCopies { get; set; }
        public int CopiesInUse { get; set; }
        public string Type { get; set; }
        public string Isbn { get; set; }
        public string Category { get; set; }
    }

    public class BooksResponse
    {
        
    }
}
