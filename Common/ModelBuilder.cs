using Microsoft.Extensions.Logging;

namespace ModelCreator.CLI.Common
{
    public class ModelBuilder : IModelBuilder
    {
        private readonly ILogger _logger;
        private readonly IFileProcessor _fileProcessor;
        public ModelBuilder(IFileProcessor fileProcessor, ILogger<ModelBuilder> logger)
        {
            _logger = logger;
             _fileProcessor = fileProcessor;
        }
        public int Execute(string? fileName, string? commaSeperatedValues)
        {
           _logger.LogInformation("Starting the creation of the model");
            if (string.IsNullOrWhiteSpace(commaSeperatedValues)) return -1;
            ReadOnlySpan<string> fieldspan = commaSeperatedValues.Replace(" ", "")
                .Replace("'", "")
                .Replace("\"", "")
                .Split(",");
            if (fieldspan.Length == 0) return -1;
            try
            {
                _fileProcessor.CreateFile(fileName);
                _logger.LogInformation("File Created");
                _fileProcessor.CreateNameSpaceAndClass();
               for (int i = 0; i < fieldspan.Length; i++)
               {
                   _fileProcessor.BuildPropertyLine(fieldspan[i].ToString());
               }
               _fileProcessor.CompleteClosingBrackets();
               _logger.LogInformation("finished building model");
                _fileProcessor.Stop();
                _logger.LogInformation("closing file");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.HResult;
            }
           return 0;
        }

    }
}