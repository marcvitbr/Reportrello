namespace Reportrello.Trello
{
	using System;

    public class TrelloAccount : ITrelloAccount
    {
        private readonly string key;
        private readonly string token;

        public TrelloAccount(string key, string token)
        {
            this.key = key;
            this.token = token;
        }

        public string Key
        {
            get
            {
                return this.key;
            }
        }

        public string Token
        {
            get
            {
                return this.token;
            }
        }
    }
}