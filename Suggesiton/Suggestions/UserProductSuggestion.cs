using Suggesiton.Models;
using System.Collections.Generic;

namespace Suggesiton.Suggestions
{
    public class UserProductSuggestion
    {
        // Logic

        public ProductSuggestionResponse GetProductSuggesion()
        {
            return new ProductSuggestionResponse
            {
                Message = "User Suggestion",
                Products = new List<string> { "Android", "IPhone" }
            };
        }

    }
}
