namespace Reportrello.Trello
{
	using System;

    public interface ITrelloAccount
    {
        string Key{ get; }
        string Token{ get; }
    }
}