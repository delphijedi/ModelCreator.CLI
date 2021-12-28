using System.Text;
using Microsoft.Extensions.Logging;

namespace ModelCreator.CLI.Common
{
    public class FileProcessor: IFileProcessor
    {
        private const string NameSpaceHeader = "namespace";
        private const string PublicDeclaration = "public";
        private const string GetterSetter = "{ get; set; }";
       private readonly ILogger _logger;
       private FileStream? fs;
       private string? _fileName;
        public FileProcessor(ILogger<FileProcessor> logger)
        {
            _logger = logger;
        }

        public void CreateFile(string? fileName)
        {
            _logger.LogInformation("starting the process");
            fs = (!string.IsNullOrWhiteSpace(fileName)) ? CreateFileFromFileName(fileName) : CreateFileFromRandom();
        }

        public void CreateNameSpaceAndClass()
        {
             string path = System.IO.Directory.GetCurrentDirectory();
             string currentDirectory = new System.IO.DirectoryInfo(path).Name;
             string? fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(_fileName);
            ProcessLine($"{NameSpaceHeader} {currentDirectory}");
            ProcessLine("\n{");
            ProcessLine($"\n    {PublicDeclaration} class {fileNameWithoutExtension}");
            ProcessLine("\n    {");
        }

        public void BuildPropertyLine(string lineToBuild)
        {
            ProcessLine($"\n        {PublicDeclaration} string? {lineToBuild} {GetterSetter}");
        }
    
        private void ProcessLine(string lineToWrite)
        {
            ReadOnlySpan<byte> line = Encoding.UTF8.GetBytes(lineToWrite);
            fs?.Write(line);
        }

        public void Stop()
        {
            fs?.Close();
            _logger.LogInformation("finished the process");
        }

        public void CompleteClosingBrackets()
        {
             ProcessLine("\n    }");
             ProcessLine("\n}");
        }

        private FileStream CreateFileFromFileName(string filename)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            _fileName = filename;
            string pathFileName = System.IO.Path.Combine(path, filename);
            return System.IO.File.Create(pathFileName);
        }
        
        private FileStream CreateFileFromRandom()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string randomFileName = System.IO.Path.GetRandomFileName();
            _fileName = randomFileName;
            randomFileName = System.IO.Path.ChangeExtension(randomFileName, "cs");
            string pathFileName = System.IO.Path.Combine(path, randomFileName);
            return System.IO.File.Create(pathFileName);
        }
        
    }
}