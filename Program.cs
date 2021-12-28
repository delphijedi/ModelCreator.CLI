using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ModelCreator.CLI.Business;
using ModelCreator.CLI.Common;

class program
{
    
    public static void Main(string[] args) 
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider serviceProvider = services.BuildServiceProvider();
         ModelBuilder? builder = serviceProvider.GetService<ModelBuilder>();
         FileProcessor? app = serviceProvider.GetService<FileProcessor>();
       var result = Parser.Default.ParseArguments<BuilderOptions>(args)
      .WithParsed((BuilderOptions opts) => {buildClass(builder, opts); });
    }

    static int? buildClass(ModelBuilder? builder, BuilderOptions opts)
    {
        Console.WriteLine($"File Name: {opts.FileName}");
        Console.WriteLine($"comma seperated string {opts.CommaSeperatedString}");
        var result = builder?.Execute(opts?.FileName, opts?.CommaSeperatedString);
        Console.ReadLine();
        return result;
    }

    private static void ConfigureServices(ServiceCollection services)
        {
           
             services.AddLogging(configure => configure.AddConsole());
             services.AddTransient(typeof(IFileProcessor), typeof(FileProcessor));
             services.AddTransient(provider => new ModelBuilder(provider.GetService<IFileProcessor>(), provider.GetService<ILogger<ModelBuilder>>()));
             
            
        }
}
