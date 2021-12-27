using CommandLine;

namespace ModelCreator.CLI.Business
{
    [Verb("build", HelpText = "create a new public class based on the commma seperated string")]
    public class BuilderOptions 
    {
        [Option('o',"outFileName", Required = false, HelpText = "creates the file based on your choosing otherwise will default to folder name")]
        public string? FileName { get; set; }
        [Option('s', "commaSeperatedString", Required = true, HelpText = "the string that will create the model based on comma seperated strings")]
        public string? CommaSeperatedString { get; set; }
       
    }
}