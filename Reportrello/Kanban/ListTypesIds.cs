namespace Reportrello.Kanban
{
	using System;

    public class ListTypesIds : IListTypesIds
    {
        private readonly string doneListId;

        public ListTypesIds(string doneListId)
        {
            this.doneListId = doneListId;
        }

        public string DoneListId
        {
            get
            {
                return this.doneListId;
            }
        }
    }
}