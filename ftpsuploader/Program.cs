// See https://aka.ms/new-console-template for more information


using ftpuploader;

string src = string.Empty;
string dest = string.Empty;
string host = string.Empty;
int port = 0;
string username = string.Empty;
string password = string.Empty;

if (args.Length > 0)
{
    for (int i = 0; i < args.Length; i++)
    {
        switch (args[i])
        {
            case "-src":
                src = args[i + 1];
                break;
            case "-dest":
                dest = args[i + 1];
                break;
            case "-host":
                host = args[i + 1];
                break;
            case "-port":
                port = int.Parse(args[i + 1]);
                break;
            case "-username":
                username = args[i + 1];
                break;
            case "-password":
                password = args[i + 1];
                break;
        }
    }
}
else
{
    Console.WriteLine("No arguments");
    Environment.Exit(1);
}

using var up = new Uploader(host, port, username, password);
await up.UploadFileAsync(src, dest);

Console.WriteLine("😊");