namespace Reportrello.Trello
{
    using System;

    public class ListSummary
    {
        public ListSummary(string id, string name, int cardsCount)
        {
            this.Id = id;
            this.Name = name;
            this.CardsCount = cardsCount;
        }

        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int CardsCount
        {
            get;
            set;
        }
    }
}