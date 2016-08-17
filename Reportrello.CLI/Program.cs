using System;
using System.Collections.Generic;
using Reportrello.Kanban;
using Reportrello.Report;
using Reportrello.Trello;

namespace Reportrello.CLI
{
    class MainClass
    {
        private const string Key = "YOUR_KEY";

        private const string Token = "YOUR_TOKEN";

        private static readonly IEnumerable<string> OneDayEstimateIds =
            new[] { "57290990b0dfecc6d1276aab", "57279be0b0dfecc6d122a011" };

        private static readonly IEnumerable<string> ThreeDaysEstimateIds =
            new[] { "57290990b0dfecc6d1276aac", "57279be0b0dfecc6d122a012" };

        private static readonly IEnumerable<string> FiveOrMoreDaysEstimateIds =
            new[] { "57290990b0dfecc6d1276aad", "57279be0b0dfecc6d122a013" };
        
        public static void Main(string[] args)
        {
            var account = new TrelloAccount(Key, Token);

            var listTypesIds = new ListTypesIds(args[0]);

            var estimateIds = new EstimateIds(
                OneDayEstimateIds,
                ThreeDaysEstimateIds,
                FiveOrMoreDaysEstimateIds);

            var reporter = new Reporter(account, estimateIds);

            var cards = reporter.AllCardsInListAsync(listTypesIds.DoneListId).Result;

            foreach (var card in cards)
            {
                Console.WriteLine($"{card.Estimate}\n{card.Name}\n{card.ShortUrl}\n\n");
            }
        }
    }
}
