using System;
using System.Collections.Generic;
using Reportrello.CLI.ArgumentsParsing;
using Reportrello.Kanban;
using Reportrello.Report;
using Reportrello.Trello;

namespace Reportrello.CLI
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var parser = ParsingEngineFactory.CreateDefaultArgumentsParser();

            var arguments = parser.Parse(args);

            var account = new TrelloAccount(arguments.Key, arguments.Token);

            var estimateIds = new EstimateIds(
                arguments.OneDayEstimateIds,
                arguments.ThreeDaysEstimateIds,
                arguments.FiveOrMoreDaysEstimateIds);

            var reporter = new Reporter(account, estimateIds);

            var cards = reporter.AllCardsInListAsync(arguments.ListId).Result;

            foreach (var card in cards)
            {
                Console.WriteLine($"{card.Estimate}\n{card.Name}\n{card.ShortUrl}\n\n");
            }
        }
    }
}