using FluentFTP;
using System.IO;
using FluentFTP.Helpers;

namespace ftpuploader;

public sealed class Uploader : IUploader
{
    FtpClient client;

    public Uploader(string host, int port, string username, string password)
    {
        client = new FtpClient(host, port, username, password);
        client.RetryAttempts = 100;
        client.EncryptionMode = FtpEncryptionMode.Explicit;
    }

    public async Task UploadFileAsync(string srcPath, string dest)
    {
        if (!client.IsConnected)
        {
            await client.ConnectAsync();
        }

        var status = client.UploadFile(srcPath, dest, FtpRemoteExists.Overwrite,
            true, FtpVerify.OnlyChecksum);

        if (!status.IsSuccess())
        {
            // try one more time
            await client.UploadFileAsync(srcPath, dest, FtpRemoteExists.Overwrite,
                true, FtpVerify.OnlyChecksum);
        }
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