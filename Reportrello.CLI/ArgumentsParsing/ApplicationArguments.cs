namespace Reportrello.CLI.ArgumentsParsing
{
    using System;
    using System.Collections.Generic;

    public class ApplicationArguments
    {
        public string Key { get; set; }
        public string Token { get; set; }
        public List<string> OneDayEstimateIds { get; set; }
        public List<string> ThreeDaysEstimateIds { get; set; }
        public List<string> FiveOrMoreDaysEstimateIds { get; set; }
        public string ListId { get; set; }
    }
}