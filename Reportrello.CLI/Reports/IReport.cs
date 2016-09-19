namespace Reportrello.CLI.Reports
{
    using System;
    using Reportrello.CLI.ArgumentsParsing;

    public interface IReport
    {
        void Generate(ApplicationArguments arguments);
    }
}