namespace Reportrello.CLI
{
    using System;
    using System.Threading.Tasks;
    using Reportrello.CLI.ArgumentsParsing;
    using Reportrello.Kanban;
    using Reportrello.Report;
    using Reportrello.Trello;

    public class ReportConsoleProgram
    {
        private readonly string[] args;

        private readonly IParsingEngine parser;

        public ReportConsoleProgram(string[] args, IParsingEngine parser)
        {
            this.args = args;
            this.parser = parser;
        }

        public async Task ExecuteAsync()
        {
            ApplicationArguments arguments = null;

            try
            {
                arguments = this.parser.Parse(this.args);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ERROR:\n{ex.Message}");
                return;
            }

            var account = new TrelloAccount(arguments.Key, arguments.Token);

            var estimateIds = new EstimateLabelsIds(
                arguments.OneDayEstimateIds,
                arguments.ThreeDaysEstimateIds,
                arguments.FiveOrMoreDaysEstimateIds);

            await this.GenerateReportAsync(account, estimateIds, arguments);
        }

        private async Task GenerateReportAsync(
            TrelloAccount account,
            EstimateLabelsIds estimateIds,
            ApplicationArguments arguments)
        {
            var reporter = new Reporter(account, estimateIds);

            var shouldGenerateCardListReport = !string.IsNullOrWhiteSpace(arguments.ListId);

            if (shouldGenerateCardListReport)
            {
                var cards = await reporter.AllCardsInListAsync(arguments.ListId);

                foreach (var card in cards)
                {
                    Console.WriteLine($"{card.Estimate}\n{card.Name}\n{card.ShortUrl}\n\n");
                }

                return;
            }

            var shouldGenerateCountReport = !string.IsNullOrWhiteSpace(arguments.BoardId);

            if (shouldGenerateCountReport)
            {
                var listsSummaries = await reporter.CardsCountInBoardAsync(arguments.BoardId);

                foreach(var summary in listsSummaries)
                {
                    Console.WriteLine($"{summary.Name}\n------------\n{summary.CardsCount} Cards\n\n");
                }
            }
        }
    }
}