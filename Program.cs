using CommandLine;
using ModelCreator.CLI.Business;

class program
{
    public static void Main(string[] args) 
    {
       var result = Parser.Default.ParseArguments<BuilderOptions>(args)
      .WithParsed((BuilderOptions opts) => {buildClass(opts); });
    }

    static int buildClass(BuilderOptions opts)
    {
        Console.WriteLine($"File Name: {opts.FileName}");
        Console.WriteLine($"comma seperated string {opts.CommaSeperatedString}");
        return 0;
    }
}
