# ftpuploader

Example usage

```bash
./ftpuploader -host "some.ftp.site.com" -port 21 -username "some name" -password "some password" -src "/path/to/some/file.txt" -dest "/path/to/upload/some/file/txt"
```


linux

```bash
dotnet publish -c Release -r linux-x64 -p:PublishReadyToRun=true --self-contained true -p:PublishSingleFile=true -p:EnableCompressionInSingleFile=true
```

mac

```bash
dotnet publish -c Release -r osx-x64 -p:PublishReadyToRun=true --self-contained true -p:PublishSingleFile=true -p:EnableCompressionInSingleFile=true
```

