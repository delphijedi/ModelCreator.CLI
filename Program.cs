class ModelCreatorCLI
{
    public static void Main(string[] args) 
    { 
        if (args.Length == 0)
        {
            System.Console.WriteLine("Please enter some arguments to continue.");
            Environment.Exit(0);
        }
        var command = args[0];
        if (!commandMap.ContainsKey(command))
	{
		Console.WriteLine("Invalid command");
	}

	commandMap[command](args.Skip(1).ToArray());

    }

    private static readonly Dictionary<string, Action<string[]>> commandMap = new Dictionary<string, Action<string[]>>(StringComparer.InvariantCultureIgnoreCase)
    {
        [nameof(FileName)] = FileName,
        [nameof(CommaSeperatedString)] = CommaSeperatedString
    };


    static void FileName(string[] args)
    {
        System.Console.WriteLine("Executing Filename");
    }

    static void CommaSeperatedString(string[] args)
    {
        System.Console.WriteLine("Comma Seperated String");
    }
}
