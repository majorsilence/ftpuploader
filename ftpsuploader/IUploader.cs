namespace ftpuploader;

public interface IUploader : IDisposable
{
    Task UploadFileAsync(string srcPath, string dest);
}