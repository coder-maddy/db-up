using DbUp;
using DbUp_Demo.PreProcessors;
using System.Reflection;

var connectionString = "Server=localhost;Port=5432;User Id=root;Password=root;Database=demo_db_1;";

var upgrader =
    DeployChanges.To
        .PostgresqlDatabase(connectionString)
        .WithScriptsAndCodeEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .WithTransaction() //Upgrade will be done in transaction
        .WithPreprocessor(new TypeSubstituteProcessor())
        .JournalToPostgresqlTable("public","journal")
        .LogToConsole()
        .Build();

//Below line ensures that database created, if not it will create.
EnsureDatabase.For.PostgresqlDatabase(connectionString);

var result = upgrader.PerformUpgrade();

if (!result.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(result.Error);
    Console.ResetColor();
#if DEBUG
    Console.ReadLine();
#endif
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Success!");
Console.ResetColor();
