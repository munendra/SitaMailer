namespace Mailer.Logic.Interface
{
    public interface IFileSerializer
    {
        string Type { get; }
        T DeserializeFile<T>(string path);
    }
}