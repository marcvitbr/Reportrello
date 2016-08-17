namespace Reportrello.CLI.ArgumentsParsing
{
    using System;
    using System.Collections.Generic;
    using Fclp;

    public static class ParsingEngineFactory
    {
        public static IParsingEngine CreateDefaultArgumentsParser()
        {
            var fluentParser = new FluentCommandLineParser<ApplicationArguments>();

            fluentParser.Setup(arg => arg.Key)
                        .As('k', "key")
                        .Required();

            fluentParser.Setup(arg => arg.Token)
                        .As('a', "token")
                        .Required();

            fluentParser.Setup(arg => arg.OneDayEstimateIds)
                        .As('o', "one-day-ids")
                        .Required();

            fluentParser.Setup(arg => arg.ThreeDaysEstimateIds)
                        .As('t', "three-days-ids")
                        .Required();

            fluentParser.Setup(arg => arg.FiveOrMoreDaysEstimateIds)
                        .As('f', "five-days-ids")
                        .Required();

            fluentParser.Setup(arg => arg.ListId)
                        .As('l', "list")
                        .Required();

            var defaultParser = new DefaultArgumentsParser(fluentParser);

            return defaultParser;
        }
    }
}