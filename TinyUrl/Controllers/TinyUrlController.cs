using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using TinyUrl.Helper;

namespace TinyUrl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinyUrlController : ControllerBase
    {
        Dictionary<string, string> dicShortLohgUrls = new Dictionary<string, string>();

        private readonly IMemoryCache memoryCache;

        public TinyUrlController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        [HttpGet("short/{url}")]
        public string GetShortUrl(string url)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string shortUrl = UrlHelper.GetMd5Hash(md5Hash, url);
                shortUrl = shortUrl.Replace('/', '-').Replace('+', '_').Substring(0, 6);

                Console.WriteLine("The MD5 hash of " + url + " is: " + shortUrl + ".");
                var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(60));
                memoryCache.Set(shortUrl, url, cacheEntryOptions);
                return shortUrl;
            }

        }

        [HttpGet("long/{url}")]
        public string GetLongUrl(string url)
        {
            if(memoryCache.TryGetValue(url, out string longUrl))
            {
                return longUrl;
            }
            return url;

        }
    }
}
