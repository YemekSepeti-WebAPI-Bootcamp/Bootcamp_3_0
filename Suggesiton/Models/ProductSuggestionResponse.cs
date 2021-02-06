using System.Collections.Generic;

namespace Suggesiton.Models
{
    public class ProductSuggestionResponse
    {
        public string Message { get; set; }
        public List<string> Products { get; set; }
    }
}
