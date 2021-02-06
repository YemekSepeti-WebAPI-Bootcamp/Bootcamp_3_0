using Microsoft.Extensions.DependencyInjection;
using SuggestionSOLID.Enums;
using SuggestionSOLID.Interfaces;
using SuggestionSOLID.Suggestions;
using System;
using System.Linq;
using static SuggestionSOLID.ProductResolverDelegate;

namespace SuggestionSOLID
{
    class Program
    {



        static void Main(string[] args)
        {
            #region FindServiceCustomize

            //var serviceProvider = new ServiceCollection()
            //      .AddTransient<IProductSuggestion, GuestProductSuggestion>()
            //      .AddTransient<IProductSuggestion, UserProductSuggestion>()
            //      .AddTransient<IChannelSuggestion, ChannelSuggestion>()
            //      .BuildServiceProvider();


            //var suggestionType = SuggestionType.Guest;

            //IProductSuggestion productSuggestion = null;
            //IChannelSuggestion channelSuggestion = null;
            //var serviceProducts = serviceProvider.GetServices<IProductSuggestion>();
            //switch (suggestionType)
            //{
            //    case SuggestionType.None:
            //        break;
            //    case SuggestionType.Guest:
            //        productSuggestion = serviceProducts.First(x => x.GetType() == typeof(GuestProductSuggestion));
            //        break;
            //    case SuggestionType.User:
            //        productSuggestion = serviceProducts.First(x => x.GetType() == typeof(UserProductSuggestion));
            //        break;
            //    default:
            //        break;
            //}

            //channelSuggestion = serviceProvider.GetService<IChannelSuggestion>();

            //Suggestion suggestion = new Suggestion(productSuggestion, channelSuggestion);

            //suggestion.OpenChannel();

            //suggestion.Suggest();

            //suggestion.CloseChannel();


            //Console.WriteLine("Hello World!");
            #endregion FindServiceCustomize


            #region FindServiceResolver

            //setup our DI
            var serviceProviderCollection = new ServiceCollection()
                  .AddTransient<GuestProductSuggestion>()
                  .AddTransient<UserProductSuggestion>()
                  .AddTransient<SuggestionForResolver>()
                  .AddTransient<IChannelSuggestion, ChannelSuggestion>();

            serviceProviderCollection.AddTransient<ProductSuggestionResolver>(suggestProvider => key =>
            {
                switch (key)
                {
                    case SuggestionType.User:
                        return suggestProvider.GetService<UserProductSuggestion>();
                    case SuggestionType.Guest:
                        return suggestProvider.GetService<GuestProductSuggestion>();
                    case SuggestionType.None:
                        throw new NotImplementedException();
                    default:
                        throw new NotImplementedException();
                }
            });

            var resolveMapping = ((ServiceProvider)serviceProviderCollection.BuildServiceProvider())
                .GetRequiredService<SuggestionForResolver>();

            resolveMapping.OpenChannel();
            var res = resolveMapping.Suggest(SuggestionType.Guest);

            Console.WriteLine(res.Message);
            res.Products.ForEach(x => Console.WriteLine(x));

            resolveMapping.CloseChannel();


            #endregion FindServiceResolver
        }
    }
}
