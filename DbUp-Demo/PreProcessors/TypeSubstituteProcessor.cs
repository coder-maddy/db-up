using DbUp.Engine;

namespace DbUp_Demo.PreProcessors
{
    internal class TypeSubstituteProcessor : IScriptPreprocessor
    {
        public string Process(string contents)
        {
            return contents.Replace("nvarchar(max)", "text", StringComparison.OrdinalIgnoreCase);
        }
    }
}
