namespace ModelCreator.CLI.Common
{
    public interface IFileProcessor
    {
        public void CreateFile(string? fileName);
        public void CreateNameSpaceAndClass();
        public void BuildPropertyLine(string lineToBuild);
        public void CompleteClosingBrackets();
        public void Stop();
    }
}