namespace Reportrello.Trello
{
    using System;
    using System.Collections.Generic;

    public class Card
    {
        public Card()
        {
        }

        public string Name
        {
            get;
            set;
        }

        public string ShortUrl
        {
            get;
            set;
        }

        public IEnumerable<string> IdLabels
        {
            get;
            set;
        }

        public string Estimate
        {
            get;
            set;
        }
    }
}