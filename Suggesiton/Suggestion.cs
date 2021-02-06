using Suggesiton.Enums;
using Suggesiton.Models;
using Suggesiton.Suggestions;
using System;

namespace Suggesiton
{
    public class Suggestion
    {

        private readonly GuestProductSuggestion _guestProductSuggestion;
        private readonly UserProductSuggestion _userProductSuggestion;

        public Suggestion(GuestProductSuggestion guestProductSuggestion, UserProductSuggestion userProductSuggestion)
        {
            _guestProductSuggestion = guestProductSuggestion;
            _userProductSuggestion = userProductSuggestion;
        }


        public ProductSuggestionResponse Suggest(SuggestionType suggestionType)
        {
            ProductSuggestionResponse response = new ProductSuggestionResponse();

            if (suggestionType == SuggestionType.Guest)
                response = _guestProductSuggestion.GetProductSuggesion();
            else if (suggestionType == SuggestionType.User)
                response = _userProductSuggestion.GetProductSuggesion();
            else
                throw new NotImplementedException();

            return response;

        }



        public void OpenSuggestionChannel()
        {

            // business
            Console.WriteLine("Channel openned");
        }

        public void CloseSuggestionChannel()
        {
            // besinesss
            Console.WriteLine("Channel closed");
        }


    }
}
