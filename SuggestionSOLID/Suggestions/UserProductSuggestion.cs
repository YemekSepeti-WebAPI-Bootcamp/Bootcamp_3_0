using SuggestionSOLID.Interfaces;
using SuggestionSOLID.Models;
using System.Collections.Generic;

namespace SuggestionSOLID.Suggestions

{
    public class UserProductSuggestion : IProductSuggestion
    {
        // Logic

        public ProductSuggestionResponse GetProductSuggestion() 
        {
            return new ProductSuggestionResponse
            {
                Message = "User Suggestion",
                Products = new List<string> { "Android", "IPhone" }
            };
        }

    }
}
