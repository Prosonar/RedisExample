namespace ProductApi.Utilities.Cache
{
    public interface ICacheService
    {
        bool SetValue(string key, object value);
        T? GetValue<T>(string key);
    }
}
