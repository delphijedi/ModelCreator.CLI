namespace ModelCreator.CLI.Common
{
    public interface IModelBuilder
    {
        public int Execute(string fileName, string commaSeperatedValues);
    }
}