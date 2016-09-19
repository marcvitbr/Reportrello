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

            var arguments = this.parser.Object;

            var hasBoardAndList = !string.IsNullOrWhiteSpace(arguments.BoardId)
                               && !string.IsNullOrWhiteSpace(arguments.ListId);

            if(hasBoardAndList)
            {
                throw new ArgumentException("You can specify the board id OR list id, but not both.");
            }

            return this.parser.Object;
        }
    }
}