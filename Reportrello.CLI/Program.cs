using System;
using System.Collections.Generic;
using Reportrello.CLI.ArgumentsParsing;

namespace Reportrello.CLI
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var parser = ParsingEngineFactory.CreateDefaultArgumentsParser();

            var reportProgram = new ReportConsoleProgram(args, parser);

            reportProgram.ExecuteAsync().Wait();
        }
    }
}