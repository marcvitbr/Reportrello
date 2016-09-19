namespace Reportrello.Kanban
{
    using System;
    using System.Collections.Generic;

    public class EstimateLabelsIds : IEstimateIds
    {
        private readonly IEnumerable<string> oneDayIds;
        private readonly IEnumerable<string> threeDaysIds;
        private readonly IEnumerable<string> fiveOrMoreDaysIds;

        public EstimateLabelsIds(IEnumerable<string> oneDayIds,
                           IEnumerable<string> threeDaysIds,
                           IEnumerable<string> fiveOrMoreDaysIds)
        {
            this.oneDayIds = oneDayIds;
            this.threeDaysIds = threeDaysIds;
            this.fiveOrMoreDaysIds = fiveOrMoreDaysIds;
        }

        public IEnumerable<string> OneDayIds
        {
            get
            {
                return this.oneDayIds;
            }
        }

        public IEnumerable<string> ThreeDaysIds
        {
            get
            {
                return this.threeDaysIds;
            }
        }

        public IEnumerable<string> FiveOrMoreDaysIds
        {
            get
            {
                return this.fiveOrMoreDaysIds;
            }
        }
    }
}