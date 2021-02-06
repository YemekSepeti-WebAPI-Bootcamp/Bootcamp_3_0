using System.Collections.Generic;

namespace SuggestionSOLID.Models
{
    public class ProductSuggestionResponse
    {
        public string Message { get; set; }
        public List<string> Products { get; set; }
    }
}
