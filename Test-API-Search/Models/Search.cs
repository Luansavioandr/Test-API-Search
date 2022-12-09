using System.ComponentModel.DataAnnotations.Schema;

namespace Test_API_Search.Models
{
    [Table("Search")]
    public class Search
    {
        public string Titulo { get; set; }
        public string Link { get; set; }
    }
}
