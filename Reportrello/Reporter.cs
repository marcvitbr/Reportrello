namespace Reportrello.Report
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Reportrello.Infrastructure.Http;
    using Reportrello.Kanban;
    using Reportrello.Trello;

    public class Reporter
    {
        private const string TrelloBaseUrl = "https://api.trello.com/1/";
        private const string ResourceForCardsInList = "lists/{listId}/cards?key={key}&token={token}";
        private const string ResourceForListsInBoard = "boards/{boardId}/lists?key={key}&token={token}";

        private readonly ITrelloAccount trelloAcount;
        private readonly IEstimateIds estimateIds;
        private readonly IHttpClient httpClient;

        private readonly IEnumerable<KeyValuePair<IEnumerable<string>, string>> estimates;

        public Reporter(ITrelloAccount trelloAcount, IEstimateIds estimateIds)
        {
            this.trelloAcount = trelloAcount;
            this.estimateIds = estimateIds;

            this.estimates = new[]
            {
                new KeyValuePair<IEnumerable<string>, string>(this.estimateIds.OneDayIds, "1 Day"),
                new KeyValuePair<IEnumerable<string>, string>(this.estimateIds.ThreeDaysIds, "3 Days"),
                new KeyValuePair<IEnumerable<string>, string>(this.estimateIds.FiveOrMoreDaysIds, "5 Days")
            };

            this.httpClient = new RestSharpHttpClient(TrelloBaseUrl);
        }

        public async Task<IEnumerable<Card>> AllCardsInListAsync(string listId)
        {
            var segments = new[]
            {
                new KeyValuePair<string, string>("listId", listId),
                new KeyValuePair<string, string>("key", this.trelloAcount.Key),
                new KeyValuePair<string, string>("token", this.trelloAcount.Token)
            };

            var cards = await this.httpClient.GetAsync<IEnumerable<Card>>(ResourceForCardsInList, segments);

            foreach(var card in cards)
            {
                card.Estimate = this.estimates
                                    .Where(e => e.Key.Any(card.IdLabels.Contains))
                                    .Select(e => e.Value).FirstOrDefault();
            }

            return cards;
        }

        public async Task<IEnumerable<ListSummary>> CardsCountInBoardAsync(string boardId)
        {
            var segments = new[]
            {
                new KeyValuePair<string, string>("boardId", boardId),
                new KeyValuePair<string, string>("key", this.trelloAcount.Key),
                new KeyValuePair<string, string>("token", this.trelloAcount.Token)
            };

            var lists = await this.httpClient.GetAsync<IEnumerable<List>>(ResourceForListsInBoard, segments);

            var listsSummaries = new System.Collections.Generic.List<ListSummary>();

            foreach(var list in lists)
            {
                var cards = await this.AllCardsInListAsync(list.Id);

                listsSummaries.Add(
                    new ListSummary(
                            list.Id,
                            list.Name,
                            cards.Count()));
            }

            return listsSummaries;
        }
    }
}