using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Quizou.Common.Interfaces;

public class EncryptionService : IEncryptionService
{
    private readonly byte[] key;
    private readonly byte[] iv;

    public EncryptionService(string keyString, string ivString)
    {
        key = Encoding.UTF8.GetBytes(keyString);
        iv = Encoding.UTF8.GetBytes(ivString);
    }
    public string Encrypt<T>(T obj)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        var json = JsonSerializer.Serialize(obj, options);
        using Aes aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        using var ms = new MemoryStream();
        using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs))
        {
            sw.Write(json);
        }

        return Convert.ToBase64String(ms.ToArray());
    }

    public T Decrypt<T>(string encryptedText)
    {
        var buffer = Convert.FromBase64String(encryptedText);
        using Aes aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        using var ms = new MemoryStream(buffer);
        using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        var json = sr.ReadToEnd();

        return JsonSerializer.Deserialize<T>(json)!;
    }
}