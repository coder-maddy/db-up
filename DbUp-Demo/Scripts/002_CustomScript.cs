using DbUp.Engine;
using System.Data;

namespace DbUp_Demo.Scripts
{
    internal class _002_CustomScript : IScript
    {
        public string ProvideScript(Func<IDbCommand> dbCommandFactory)
        {
            return "ALTER TABLE COMPANY ALTER COLUMN ADDRESS TYPE CHAR(100);";
        }
    }
}
