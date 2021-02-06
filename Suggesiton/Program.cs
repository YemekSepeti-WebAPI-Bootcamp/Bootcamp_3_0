using Suggesiton.Enums;
using Suggesiton.Suggestions;
using System;

namespace Suggesiton
{
    class Program
    {
        static void Main(string[] args)
        {
            GuestProductSuggestion guestProductSuggestion = new GuestProductSuggestion();
            UserProductSuggestion userProductSuggestion = new UserProductSuggestion();

            Suggestion suggestion = new Suggestion(guestProductSuggestion, userProductSuggestion);

            SuggestionType sType = SuggestionType.Guest;

            suggestion.OpenSuggestionChannel();

            var suggestResponse = suggestion.Suggest(sType);
            suggestion.CloseSuggestionChannel();

            Console.WriteLine(suggestResponse.Message);
            suggestResponse.Products.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
