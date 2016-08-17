namespace Reportrello.CLI.ArgumentsParsing
{
    using System;
    using Fclp;

    public class DefaultArgumentsParser : IParsingEngine
    {
        private readonly FluentCommandLineParser<ApplicationArguments> parser;

        public DefaultArgumentsParser(FluentCommandLineParser<ApplicationArguments> parser)
        {
            this.parser = parser;
        }

        public ApplicationArguments Parse(string[] args)
        {
            this.parser.Parse(args);

            return this.parser.Object;
        }
    }
}