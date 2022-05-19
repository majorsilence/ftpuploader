namespace ftpuploader;

public sealed class ScpUploader : IUploader
{
    Renci.SshNet.SftpClient client;

    public ScpUploader(string host, int port, string username, string password)
    {
        client = new Renci.SshNet.SftpClient(host, port, username, password);
        client.ConnectionInfo.RetryAttempts = 3;
        client.ConnectionInfo.Timeout = TimeSpan.FromSeconds(60);
    }

    public Task UploadFileAsync(string srcPath, string dest)
    {
        if (!client.IsConnected)
        {
            client.Connect();
        }

        string destDirectory = System.IO.Path.GetDirectoryName(dest);
        string destFilename = System.IO.Path.GetFileName(dest);

        using var file = File.OpenRead(srcPath);
        client.ChangeDirectory(destDirectory);
        client.UploadFile(file, destFilename);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        if (client.IsConnected)
        {
            client.Disconnect();
        }

        client.Dispose();
    }
}