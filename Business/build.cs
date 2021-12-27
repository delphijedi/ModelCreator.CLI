using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;

namespace ModelCreator.CLI.Business
{
    [Verb("build", HelpText = "create a new public class based on the commma seperated string")]
    public class build : ICommand
    {
        [Option('o',"outFileName", Required = false, HelpText = "creates the file based on your choosing otherwise will default to folder name")]
        public string? FileName { get; set; }
        [Option('c', "commaSeperatedString", Required = true, HelpText = "the string that will create the model based on comma seperated strings")]
        public string? CommaSeperatedString { get; set; }
        public void Execute()
        {
            Console.WriteLine($"Executing the following: {FileName}, with the following seperated values: {CommaSeperatedString}");
        }
    }
}