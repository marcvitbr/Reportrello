namespace Reportrello.Kanban
{
    using System;
    using System.Collections.Generic;

    public interface IEstimateIds
    {
        IEnumerable<string> OneDayIds { get; }
        IEnumerable<string> ThreeDaysIds { get; }
        IEnumerable<string> FiveOrMoreDaysIds { get; }
    }
}