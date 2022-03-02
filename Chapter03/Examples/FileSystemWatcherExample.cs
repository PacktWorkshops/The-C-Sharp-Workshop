using System;
using System.IO;

class FileSystemWatcherExample
{
    public static void Main()
    {
        using var watcher = new FileSystemWatcher
        {
            Path = @"c:\temp\",
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName,
            Filter = "*.txt"
        };

        watcher.Changed += (sender, e) 
            => Console.WriteLine($"Changed: {e.FullPath}");

        watcher.Created += (sender, e) 
            => Console.WriteLine($"Created: {e.FullPath}");

        watcher.Deleted += (sender, e) 
            => Console.WriteLine($"Deleted: {e.FullPath}");
        
        watcher.Renamed += (sender, e) =>
            Console.WriteLine($"Renamed: {e.FullPath}");

        // Begin watching.
        watcher.EnableRaisingEvents = true;

        Console.WriteLine($"Press ENTER to stop listening to {watcher.Path} {watcher.Filter}");
        Console.ReadLine();
    }
}
