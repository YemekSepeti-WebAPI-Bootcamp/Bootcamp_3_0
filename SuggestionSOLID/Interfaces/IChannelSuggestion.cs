using System;

namespace SuggestionSOLID.Interfaces
{

    public class ChannelSuggestion : IChannelSuggestion
    {
        public void OpenSuggestion()
        {
            // Logic

            Console.WriteLine("Open Channel");
        }

        public void CloseSuggestion()
        {
            // logic

            Console.WriteLine("Close channel");
        }
    }




    public interface IChannelSuggestion
    {
        void OpenSuggestion();
        void CloseSuggestion();
    }
}
