using SuggestionSOLID.Enums;
using SuggestionSOLID.Interfaces;

namespace SuggestionSOLID
{
    public class ProductResolverDelegate
    {
        public delegate IProductSuggestion ProductSuggestionResolver(SuggestionType key);

    }
}
