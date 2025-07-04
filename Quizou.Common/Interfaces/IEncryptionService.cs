namespace Quizou.Common.Interfaces;

public interface IEncryptionService
{
    string Encrypt<T>(T obj);
    T Decrypt<T>(string encryptedText);
}