using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Extensions
{
    public static class SessionExtensionMethods
    {
        /// <summary>
        /// SetObject metodu verilen nesneyi string karaktere çevirip bir anahtar vasıtası ile session.SetString metodunu kullanmamıza imkan sağlamaktadır.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetObject(this ISession session,string key, object value)
        {
            string objectString = JsonConvert.SerializeObject(value);
            session.SetString(key,objectString);
        }
        /// <summary>
        /// GetObject metodu belirli anahtar vasıtası ile eriştiğimiz string değeri belirli bir nesneye doldurmamızı sağlamaktadır.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetObject<T>(this ISession session, string key) where T: class
        {
            string objectString = session.GetString(key);
            if (string.IsNullOrEmpty(objectString))
            {
                return null;
            }
            else
            {
                T value = JsonConvert.DeserializeObject<T>(objectString);
                return value;
            }
        }
    }
}
