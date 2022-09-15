using TheUKTories;
using TheUKTories.Services.Data.Selfrolled;

ResetText();
WriteNoticeText("Welcome to The UK Tories database backup script!");
WriteNoticeText($"Searching for enviroment variable ({Globals.ConnectionEnvironmentVar})...");
if (String.IsNullOrEmpty(Globals.TryGetConnectionString(Globals.ExpressConnectionString)))
{
    WriteNoticeText("Couldn't find the environment variable to connect to the database, set it up and rerun the script");
    Environment.Exit(0);
}

WriteNoticeText("Connection string found, connecting to database and performing a full backup");
await OldDbBackupService.Backup();
WriteNoticeText("Done!");

// Methods

void ResetText() => Console.ForegroundColor = ConsoleColor.Gray;
void WriteNoticeText(string text)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine(text);
    ResetText();
}