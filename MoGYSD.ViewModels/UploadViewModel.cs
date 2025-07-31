using System.ComponentModel;

namespace MoGYSD.ViewModels;

public class UploadViewModel
{
    public UploadViewModel(string fileName, UploadType uploadType, byte[] data, bool overwrite = false)
    {
        FileName = fileName;
        UploadType = uploadType;
        Data = data;
        Overwrite = overwrite;
    }

    public string FileName { get; set; }
    public string? Extension { get; set; }
    public UploadType UploadType { get; set; }
    public bool Overwrite { get; set; }
    public byte[] Data { get; set; }
    public string? Folder { get; set; }
}

public enum UploadType : byte
{
    [Description(@"Documents")] Document
}