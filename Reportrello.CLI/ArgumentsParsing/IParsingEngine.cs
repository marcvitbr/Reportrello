namespace Reportrello.CLI.ArgumentsParsing
{
    using System;

    public interface IParsingEngine
    {
        ApplicationArguments Parse(string[] args);
    }
}