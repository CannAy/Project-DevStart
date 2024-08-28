using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevStart_Service.Extensions
{
    public static class SessionExtensions //class STATIC olmak zorunda Extension yazmak için!!1. kural bu
    {
        public static void SetJson<T>(this ISession session, string key, T value) //2. kural, ilk parametre this ile başlayacak.
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T? GetJson<T>(this ISession session, string key)   //2. kural, ilk parametre this ile başlayacak.
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
