// See https://aka.ms/new-console-template for more information
using HHM.Homework.AdoDotNet;

AdoDotNetService adoDotNetService = new AdoDotNetService();

Console.WriteLine("Reading Data...");
adoDotNetService.Read();

Console.WriteLine("Adding Data");
adoDotNetService.Create();

Console.WriteLine("Updating Data");
adoDotNetService.Update();

Console.WriteLine("Deleting Data");
adoDotNetService.Delete();

Console.WriteLine("Done");
Console.ReadLine();
