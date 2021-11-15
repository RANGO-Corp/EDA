using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Alere.Helpers
{
    public static class SessionHelper
    {
        public static void SetObjectToSession(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromSession<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}