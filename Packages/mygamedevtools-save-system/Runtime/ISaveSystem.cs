namespace MyGameDevTools.Persistence
{
    public interface ISaveSystem
    {
        void Set<T>(string key, T value);

        T Get<T>(string key);
    }
}