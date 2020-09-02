using System;
using System.Threading.Tasks;
using System.IO;

class Program
{
    public static async Task Main()
    {
        // 1.	Create a new console application;
        // 2.	Create a file and paste your favorite song lyrics inside it. Separate each stanza by an empty line;
        // 3.	For each song stanza, print it to the console and wait 3 seconds until printing the next one;
        // 4.	By the end of the song, inform your user you’re finished and ask him/her if you he wants another song to be printed.
        // 5.	If yes, ask the user to paste another song in the same format, with each stanza separated by an empty line and an END written at the end of the text.
        // 6.	After user did it and press enter, you should erase the file and past the new song;
        // 7.	Go to step number 3 until the user says that he does not want to continue.

        while (true)
        {
            using (var fileStream = new FileStream("song.txt", FileMode.Open, FileAccess.Read))
            {
                await ReadFile(fileStream);
            }

            Console.WriteLine("\n If you wish to stop, please type bye! Otherwise paste here another fav song lyrics with an END on the last line! :)");

            var text = Console.ReadLine();

            if (text.Equals("bye", System.StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            else
            {
                var song = new System.Text.StringBuilder();

                while (!text.Equals("END", StringComparison.OrdinalIgnoreCase))
                {
                    song.AppendLine(text);
                    text = Console.ReadLine();
                }

                using (var file = new StreamWriter("song.txt"))
                {
                    file.Write(song.ToString());
                }
            }
        }
    }

    private static async Task ReadFile(FileStream fileStream)
    {
        using (var reader = new StreamReader(fileStream))
        {
            var content = await reader.ReadToEndAsync();

            var stanzas = content.Split(Environment.NewLine + Environment.NewLine);

            foreach (var stanza in stanzas)
            {
                Console.WriteLine(stanza);
                await Task.Delay(3000);
            }
        }
    }
}