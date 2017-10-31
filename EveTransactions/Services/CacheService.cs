using System;
using System.Linq;
using System.Net;
using EveTransactions.Domain;
using EveTransactions.Repository;

namespace EveTransactions.Services
{
    public static class CacheService
    {
        public static bool IsUrlCached(string url, bool testMode)
        {
            if (testMode)
            {
                // Turning off caching
                return false;
            }

            EveRepository repository = new EveRepository();

            var cacheitem = repository.UrlCaches.FirstOrDefault(x => x.Url == url);

            if (cacheitem != null)
            {
                if (cacheitem.CacheUntil > DateTime.Now) return true; 
            }

            return false;
        }

        public static void SaveUrlCache(string url, DateTime cacheUntil)
        {
            var repository = new EveRepository();
            var cacheitem = repository.UrlCaches.FirstOrDefault(x => x.Url == url);

            if (cacheitem != null)
            {
                cacheitem.CacheUntil = cacheUntil;
            }
            else
            {
                UrlCache cache = new UrlCache
                {
                    Url = url,
                    CacheUntil = cacheUntil
                };
                repository.UrlCaches.Add(cache);
            }

            repository.SaveChanges();
        }

        public static void CheckCacheResponse(HttpWebResponse response)
        {
            string maxAge = response.GetResponseHeader("Access-Control-Max-Age");
            if (!string.IsNullOrEmpty(maxAge))
            {
                int age;
                if (int.TryParse(maxAge, out age))
                {
                    DateTime chachedUntil = DateTime.Now.AddSeconds(age);
                    SaveUrlCache(response.ResponseUri.AbsoluteUri, chachedUntil);
                }
            }
        }

    }
}
