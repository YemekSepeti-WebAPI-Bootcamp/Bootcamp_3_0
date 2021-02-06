using Suggesiton.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suggesiton.Suggestions
{
    public class GuestProductSuggestion
    {
        // Logic

        public ProductSuggestionResponse GetProductSuggesion()
        {
            return new ProductSuggestionResponse
            {
                Message = "Guest Suggestion",
                Products = new List<string> { "Klavye", "Kulaklık" }
            };
        }

    }
}
