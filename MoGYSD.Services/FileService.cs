using System.Security.Cryptography;
using System.Text;

namespace MoGYSD.Services;
public interface IFileService
{
    string ComputeHashSha1(string filename);

    string ComputeHashSha256(string filename);
}

public class FileService : IFileService
{
    private string GetContentType(string path)
    {
        var types = GetMimeTypes();
        var ext = Path.GetExtension(path).ToLowerInvariant();
        return types[ext];
    }

    private Dictionary<string, string> GetMimeTypes()
    {
        return new Dictionary<string, string>
        {
            {".txt", "text/plain"},
            {".pdf", "application/pdf"},
            {".doc", "application/vnd.ms-word"},
            {".docx", "application/vnd.ms-word"},
            {".xls", "application/vnd.ms-excel"},
            {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
            {".png", "image/png"},
            {".jpg", "image/jpeg"},
            {".jpeg", "image/jpeg"},
            {".gif", "image/gif"},
            {".csv", "text/csv"}
        };
    }
    

    public static string GenerateSHA256String(string inputString)
    {
        var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(inputString);
        var hash = sha256.ComputeHash(bytes);
        return GetStringFromHash(hash);
    }

    public static string GenerateSHA512String(string inputString)
    {
        var sha512 = SHA512.Create();
        var bytes = Encoding.UTF8.GetBytes(inputString);
        var hash = sha512.ComputeHash(bytes);
        return GetStringFromHash(hash);
    }

    public string ComputeHashSha1(string filename)
    {
        using (var sha = SHA1.Create())
        {
            using (var stream = File.OpenRead(filename))
            {
                return Encoding.Default.GetString(sha.ComputeHash(stream));
            }
        }
    }

    public string ComputeHashSha256(string filename)
    {
        using (var sha = SHA256.Create())
        {
            using (var stream = File.OpenRead(filename))
            {
                return Encoding.Default.GetString(sha.ComputeHash(stream));
            }
        }
    }

    public string GetChecksum(string file)
    {
        using (var stream = File.OpenRead(file))
        {
            var sha = new SHA256Managed();
            var checksum = sha.ComputeHash(stream);
            return BitConverter.ToString(checksum).Replace("-", string.Empty);
        }
    }

    public string GetChecksumBuffered(Stream stream)
    {
        using (var bufferedStream = new BufferedStream(stream, 1024 * 32))
        {
            var sha = new SHA256Managed();
            var checksum = sha.ComputeHash(bufferedStream);
            return BitConverter.ToString(checksum).Replace("-", string.Empty);
        }
    }

    public string sha256(string randomString)
    {
        var crypt = new SHA256Managed();
        var hash = new StringBuilder();
        var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
        foreach (var theByte in crypto)
        {
            hash.Append(theByte.ToString("x2"));
        }

        return hash.ToString();
    }

    private static string GetStringFromHash(byte[] hash)
    {
        var result = new StringBuilder();
        for (var i = 0; i < hash.Length; i++)
        {
            result.Append(hash[i].ToString("X2"));
        }

        return result.ToString();
    }
}
