using Newtonsoft.Json;

namespace DoggyFoody.Contracts.Database.Utils
{
    public static class SerializationExtensions
    {
        public static string SerializeNullable<TValue>(this TValue value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return JsonConvert.SerializeObject(value);
            }
        }

        public static TResult DeserializeNullable<TResult>(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return default(TResult);
            }
            else
            {
                return JsonConvert.DeserializeObject<TResult>(value);
            }
        }
    }
}
